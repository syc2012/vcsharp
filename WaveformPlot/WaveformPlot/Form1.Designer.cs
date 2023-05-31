namespace WaveformPlot
{
    partial class FormPlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWav = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonFile = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartWav)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWav
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWav.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWav.Legends.Add(legend1);
            this.chartWav.Location = new System.Drawing.Point(12, 41);
            this.chartWav.Name = "chartWav";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWav.Series.Add(series1);
            this.chartWav.Size = new System.Drawing.Size(608, 395);
            this.chartWav.TabIndex = 0;
            this.chartWav.Text = "chart1";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(12, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(100, 23);
            this.buttonFile.TabIndex = 1;
            this.buttonFile.Text = "Open File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(118, 10);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(502, 25);
            this.textBoxFile.TabIndex = 2;
            // 
            // FormPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 448);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.chartWav);
            this.Name = "FormPlot";
            this.Text = "WaveformPlot";
            this.Load += new System.EventHandler(this.FormPlot_Load);
            this.Resize += new System.EventHandler(this.FormPlot_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartWav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWav;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.TextBox textBoxFile;
    }
}

