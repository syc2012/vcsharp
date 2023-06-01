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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWav = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonFile = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartWav)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWav
            // 
            chartArea2.Name = "ChartArea1";
            this.chartWav.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartWav.Legends.Add(legend2);
            this.chartWav.Location = new System.Drawing.Point(12, 43);
            this.chartWav.Name = "chartWav";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartWav.Series.Add(series2);
            this.chartWav.Size = new System.Drawing.Size(768, 513);
            this.chartWav.TabIndex = 0;
            this.chartWav.Text = "chart1";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(178, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(100, 23);
            this.buttonFile.TabIndex = 1;
            this.buttonFile.Text = "Open File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(284, 11);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(496, 25);
            this.textBoxFile.TabIndex = 2;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Location = new System.Drawing.Point(12, 12);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(160, 23);
            this.comboBoxFormat.TabIndex = 3;
            // 
            // FormPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 568);
            this.Controls.Add(this.comboBoxFormat);
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
        private System.Windows.Forms.ComboBox comboBoxFormat;
    }
}

