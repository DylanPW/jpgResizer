namespace jpgResizer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.openLocation = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resizePercentageSlider = new System.Windows.Forms.TrackBar();
            this.jpegQualitySlider = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resizeButton = new System.Windows.Forms.Button();
            this.resizePercentageBox = new System.Windows.Forms.NumericUpDown();
            this.jpegQualityBox = new System.Windows.Forms.NumericUpDown();
            this.versionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File to Open:";
            // 
            // openLocation
            // 
            this.openLocation.Location = new System.Drawing.Point(130, 10);
            this.openLocation.Name = "openLocation";
            this.openLocation.ReadOnly = true;
            this.openLocation.Size = new System.Drawing.Size(212, 20);
            this.openLocation.TabIndex = 1;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(348, 8);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(41, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resize Percentage:";
            // 
            // resizePercentageSlider
            // 
            this.resizePercentageSlider.LargeChange = 10;
            this.resizePercentageSlider.Location = new System.Drawing.Point(130, 36);
            this.resizePercentageSlider.Maximum = 100;
            this.resizePercentageSlider.Minimum = 1;
            this.resizePercentageSlider.Name = "resizePercentageSlider";
            this.resizePercentageSlider.Size = new System.Drawing.Size(212, 45);
            this.resizePercentageSlider.TabIndex = 5;
            this.resizePercentageSlider.Value = 1;
            this.resizePercentageSlider.Scroll += new System.EventHandler(this.resizePercentageSlider_Scroll);
            // 
            // jpegQualitySlider
            // 
            this.jpegQualitySlider.LargeChange = 10;
            this.jpegQualitySlider.Location = new System.Drawing.Point(130, 87);
            this.jpegQualitySlider.Maximum = 100;
            this.jpegQualitySlider.Name = "jpegQualitySlider";
            this.jpegQualitySlider.Size = new System.Drawing.Size(212, 45);
            this.jpegQualitySlider.TabIndex = 6;
            this.jpegQualitySlider.Scroll += new System.EventHandler(this.jpegQualitySlider_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "JPEG Quality:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(348, 136);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(41, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveLocation
            // 
            this.saveLocation.Location = new System.Drawing.Point(130, 138);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.ReadOnly = true;
            this.saveLocation.Size = new System.Drawing.Size(212, 20);
            this.saveLocation.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Save Location:";
            // 
            // resizeButton
            // 
            this.resizeButton.Location = new System.Drawing.Point(16, 165);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(373, 23);
            this.resizeButton.TabIndex = 12;
            this.resizeButton.Text = "Resize!";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // resizePercentageBox
            // 
            this.resizePercentageBox.Location = new System.Drawing.Point(348, 38);
            this.resizePercentageBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resizePercentageBox.Name = "resizePercentageBox";
            this.resizePercentageBox.Size = new System.Drawing.Size(40, 20);
            this.resizePercentageBox.TabIndex = 13;
            this.resizePercentageBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resizePercentageBox.ValueChanged += new System.EventHandler(this.resizePercentageBox_ValueChanged);
            // 
            // jpegQualityBox
            // 
            this.jpegQualityBox.Location = new System.Drawing.Point(348, 88);
            this.jpegQualityBox.Name = "jpegQualityBox";
            this.jpegQualityBox.Size = new System.Drawing.Size(40, 20);
            this.jpegQualityBox.TabIndex = 14;
            this.jpegQualityBox.ValueChanged += new System.EventHandler(this.jpegQualityBox_ValueChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(329, 191);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(67, 13);
            this.versionLabel.TabIndex = 15;
            this.versionLabel.Text = "VERSION__";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 211);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.jpegQualityBox);
            this.Controls.Add(this.resizePercentageBox);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jpegQualitySlider);
            this.Controls.Add(this.resizePercentageSlider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.openLocation);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 250);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "JPEG Resizer";
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualitySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox openLocation;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar resizePercentageSlider;
        private System.Windows.Forms.TrackBar jpegQualitySlider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.TextBox saveLocation;
        private System.Windows.Forms.NumericUpDown resizePercentageBox;
        private System.Windows.Forms.NumericUpDown jpegQualityBox;
        private System.Windows.Forms.Label versionLabel;
    }
}

