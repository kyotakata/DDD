namespace DDD.WinForm.Views
{
    partial class WeatherListView
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
            this.WeathersDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // WeathersDataGrid
            // 
            this.WeathersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeathersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeathersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.WeathersDataGrid.Name = "WeathersDataGrid";
            this.WeathersDataGrid.RowHeadersWidth = 51;
            this.WeathersDataGrid.RowTemplate.Height = 24;
            this.WeathersDataGrid.Size = new System.Drawing.Size(640, 335);
            this.WeathersDataGrid.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(633, 150);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // WeatherListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 335);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.WeathersDataGrid);
            this.Name = "WeatherListView";
            this.Text = "WeatherListView";
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeathersDataGrid;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}