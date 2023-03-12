﻿namespace DDD.WinForm.Views
{
    partial class WeatherSaveView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AreaIdComboBox = new System.Windows.Forms.ComboBox();
            this.ConditionComboBox = new System.Windows.Forms.ComboBox();
            this.DateTimeTextBox = new System.Windows.Forms.DateTimePicker();
            this.TemperatureTextBox = new System.Windows.Forms.TextBox();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "地域";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "日時";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "温度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "状態";
            // 
            // AreaIdComboBox
            // 
            this.AreaIdComboBox.FormattingEnabled = true;
            this.AreaIdComboBox.Location = new System.Drawing.Point(91, 48);
            this.AreaIdComboBox.Name = "AreaIdComboBox";
            this.AreaIdComboBox.Size = new System.Drawing.Size(121, 23);
            this.AreaIdComboBox.TabIndex = 5;
            // 
            // ConditionComboBox
            // 
            this.ConditionComboBox.FormattingEnabled = true;
            this.ConditionComboBox.Location = new System.Drawing.Point(91, 122);
            this.ConditionComboBox.Name = "ConditionComboBox";
            this.ConditionComboBox.Size = new System.Drawing.Size(121, 23);
            this.ConditionComboBox.TabIndex = 6;
            // 
            // DateTimeTextBox
            // 
            this.DateTimeTextBox.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DateTimeTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeTextBox.Location = new System.Drawing.Point(91, 83);
            this.DateTimeTextBox.Name = "DateTimeTextBox";
            this.DateTimeTextBox.Size = new System.Drawing.Size(200, 22);
            this.DateTimeTextBox.TabIndex = 7;
            // 
            // TemperatureTextBox
            // 
            this.TemperatureTextBox.Location = new System.Drawing.Point(91, 158);
            this.TemperatureTextBox.Name = "TemperatureTextBox";
            this.TemperatureTextBox.Size = new System.Drawing.Size(100, 22);
            this.TemperatureTextBox.TabIndex = 8;
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(212, 165);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(25, 15);
            this.UnitLabel.TabIndex = 9;
            this.UnitLabel.Text = "XX";
            // 
            // WeatherSaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 321);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.TemperatureTextBox);
            this.Controls.Add(this.DateTimeTextBox);
            this.Controls.Add(this.ConditionComboBox);
            this.Controls.Add(this.AreaIdComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WeatherSaveView";
            this.Text = "WeatherSaveView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AreaIdComboBox;
        private System.Windows.Forms.ComboBox ConditionComboBox;
        private System.Windows.Forms.DateTimePicker DateTimeTextBox;
        private System.Windows.Forms.TextBox TemperatureTextBox;
        private System.Windows.Forms.Label UnitLabel;
    }
}