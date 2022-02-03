using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Anomaly_Finder_CSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

            string outfilename;
            string line;
            int counter = 0;
            int columncount = 0;
            string[] header;
            double[][] dvalues;
            string[] oneline;
            double[] avg;
            double[] sd;
            double zthreshold;
            int timestamp;
            List<int> nzt = new List<int>();
            List<int> ignore = new List<int>();
            List<string> timestamptext = new List<string>();
            Stream fileStream;

            try
            {
                zthreshold = Convert.ToDouble(txtZThreshold.Text);
            }
            catch { return; }

            try
            {
                string[] n = txtNZT.Text.Split(',');
                if (n.Length > 0)
                {
                    for (int i = 0; i < n.Length; i++) nzt.Add(Convert.ToInt32(n[i]) - 1);
                }
                else
                    nzt = null;
            }
            catch { nzt = null; }

            try
            {
                timestamp = Convert.ToInt32(txtTimestamp.Text);
            }
            catch { timestamp = 0; }

            try
            {
                string[] n = txtIgnore.Text.Split(',');
                if (n.Length > 0)
                {
                    for (int i = 0; i < n.Length; i++) ignore.Add(Convert.ToInt32(n[i]) - 1);
                }
                else
                    ignore = null;
                if (timestamp > 0) ignore.Add(timestamp - 1); // Automatically skip timestamp if it exists
            }
            catch { ignore = null; }

 
            btnAnalyze.Enabled = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outfilename = openFileDialog.FileName + "-results.csv";

                    try 
                    { 
                        if (File.Exists(outfilename)) File.Delete(outfilename); // Make sure the old file is gone
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("File Write Error", "Error", MessageBoxButtons.OK);
                        btnAnalyze.Enabled = true;
                        return;
                    }

                    try
                    {
                        fileStream = openFileDialog.OpenFile();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("File Read Error", "Error", MessageBoxButtons.OK);
                        btnAnalyze.Enabled = true;
                        return;
                    }

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while (reader.ReadLine() != null) // Count lines
                        {
                            counter++;
                        }

                        fileStream.Position = 0; // Reset to beginning of the file
                        reader.DiscardBufferedData(); 

                        line = reader.ReadLine(); // Read the header and number of columns
                        header = line.Split(',');
                        columncount = header.Length;

                        dvalues = new double[columncount][]; // Make space for the converted data
                        for (int x = 0; x < columncount; x++)
                        {
                            dvalues[x] = new double[counter];
                        }

                        avg = new double[columncount]; 
                        sd = new double[columncount];

                        for (int y = 0; y < counter - 1; y++) // Read in convert lines to double data
                        {
                            if ((line = reader.ReadLine()) == null) break;

                            oneline = line.Split(',');

                            for (int x = 0; x < columncount; x++)
                            {
                                try
                                {
                                    if (timestamp - 1 == x) timestamptext.Add(oneline[x]);
                                    dvalues[x][y] = Convert.ToDouble(oneline[x]);
                                }
                                catch { dvalues[x][y] = 0.0; } // Make any non numbers 0.0
                            }
                        }
                    }

                    using (StreamWriter sw = File.AppendText(outfilename))
                    {
                        try
                        {
                            sw.WriteLine(",Z Score Threshold +/-: " + zthreshold.ToString());
                            sw.WriteLine(",Ignored Columns: " + txtIgnore.Text.Replace(',', '|'));
                            sw.WriteLine(",Binary Data Columns: " + txtNZT.Text.Replace(',', '|'));
                            sw.WriteLine(",Time Stamp Column: " + timestamp.ToString());
                            sw.WriteLine();
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("File Write Error", "Error", MessageBoxButtons.OK);
                        }

                        for (int x = 0; x < columncount; x++)  // Calculate AVG and SD for all data
                        {
                            avg[x] = Avg(dvalues[x], counter - 1);
                            sd[x] = SDPop(dvalues[x], counter - 1, avg[x]);
                        }

                        int lastreading = 0;
                        for (int y = 0; y < counter - 1; y++) // Cycle through and output results
                        {
                            string fileline = String.Empty;

                            int first = 0;
                            for (int x = 0; x < columncount; x++)
                            {
                                if (ignore != null) // Skip ignored columns
                                {
                                    if (ignore.Contains(x)) continue;
                                }

                                if (nzt != null)
                                {
                                    if (nzt.Contains(x)) // If this is a NON ZERO trigger field, process it
                                    {
                                        if (dvalues[x][y] != 0.0)
                                        {
                                            if ((y - lastreading) >= 5) sw.WriteLine(); // make blank lines if it has been more than 5 readings since the last anomaly

                                            if (first == 0)
                                            {
                                                if (timestamp > 0)
                                                    fileline += (y + 1).ToString() + "," + timestamptext[y] + "," + header[x] + ": V= " + dvalues[x][y].ToString();
                                                else
                                                    fileline += (y + 1).ToString() + "," + header[x] + ": V= " + dvalues[x][y].ToString();
                                            }
                                            else
                                                fileline += "," + header[x] + ": V= " + dvalues[x][y].ToString();

                                            first++;

                                            lastreading = y;

                                            continue; // don't further process if NZT
                                        }
                                    }
                                }

                                double z = (dvalues[x][y] - avg[x]) / sd[x]; // Calculate Z score

                                if (Math.Abs(z) >= zthreshold) // Output only if it is big enough
                                {
                                    if ((y - lastreading) >= 5) sw.WriteLine(); // make blank lines if it has been more than 5 readings since the last anomaly

                                    if (first == 0)
                                        if (timestamp > 0)
                                            fileline += (y+1).ToString() + "," + timestamptext[y] + "," + header[x] + ": V= " + dvalues[x][y].ToString() + "   Z= " + Math.Round(z, 1).ToString();
                                        else
                                            fileline += (y + 1).ToString() + "," + header[x] + ": V= " + dvalues[x][y].ToString() + "   Z= " + Math.Round(z, 1).ToString();
                                    else
                                        fileline += "," + header[x] + ": V= " + dvalues[x][y].ToString() + "   Z= " + Math.Round(z, 1).ToString();

                                    first++;

                                    lastreading = y;
                                }
                            }

                            try
                            {
                                if (fileline != String.Empty) sw.WriteLine(fileline);

                            }
                            catch (IOException)
                            {
                                MessageBox.Show("File Write Error", "Error", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }

            btnAnalyze.Enabled = true;
        }

        // Calculate average
        public double Avg(double[] buffer, int size)
        {
            int i;
            double total = 0;

            for (i = 0; i < size; i++)
                total += buffer[i];

            return total / size;
        }

        // Calculate Standard Deviation of Population
        public double SDPop(double[] buffer, int size, double mean)
        {
            double standardDeviation = 0.0;
            int i;

            for (i = 0; i < size; ++i)
                standardDeviation += Math.Pow(buffer[i] - mean, 2);

            return Math.Sqrt(standardDeviation / size);
        }
    }
}
