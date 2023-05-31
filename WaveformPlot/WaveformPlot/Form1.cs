using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WaveformPlot
{
    public partial class FormPlot : Form
    {
        private Rectangle orgFormSize;
        private Rectangle orgChartSize;
        private Rectangle orgTextBoxSize;

        public FormPlot()
        {
            InitializeComponent();

            chartWav.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartWav.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void PlotWaveform(string fileName)
        {
            byte[] data = File.ReadAllBytes( fileName );
            Int32 samples = data.Length / 4;
            if (samples > 1600000) samples = 1600000;

            chartWav.Series[0].Points.Clear();
            chartWav.ChartAreas[0].AxisX.LabelStyle.Format = "N0";
            chartWav.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            for (Int32 i = 0; i < samples; i++)
            {
                Int32 x = i + 1;
                Int16 y = System.BitConverter.ToInt16(data, (i * 4));
                chartWav.Series[0].Points.AddXY(x, y);
            }
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select file";
                dlg.InitialDirectory = ".\\";
                dlg.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    textBoxFile.Text = dlg.FileName;
                    PlotWaveform(dlg.FileName);

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void FormPlot_Load(object sender, EventArgs e)
        {
            orgFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            orgChartSize = new Rectangle(chartWav.Location.X, chartWav.Location.Y, chartWav.Size.Width, chartWav.Size.Height);
            orgTextBoxSize = new Rectangle(textBoxFile.Location.X, textBoxFile.Location.Y, textBoxFile.Size.Width, textBoxFile.Size.Height);
        }

        private void FormPlot_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)(this.Size.Width) / (float)(orgFormSize.Width);
            float yRatio = (float)(this.Size.Height) / (float)(orgFormSize.Height);
            int newWidth;
            int newHeight;

            //newWidth = (int)(orgTextBoxSize.Width * xRatio);
            //textBoxFile.Size = new Size(newWidth, orgTextBoxSize.Height);

            newWidth = (int)(orgChartSize.Width * xRatio);
            newHeight = (int)(orgChartSize.Height * yRatio);
            chartWav.Size = new Size(newWidth, newHeight);

            newWidth = chartWav.Size.Width - (textBoxFile.Location.X - chartWav.Location.X);
            textBoxFile.Size = new Size(newWidth, orgTextBoxSize.Height);
        }
    }
}
