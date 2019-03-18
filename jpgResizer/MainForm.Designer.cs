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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.longEdgeBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resizeLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.longEdgeRadioButton = new System.Windows.Forms.RadioButton();
            this.percentageRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.debugLocation = new System.Windows.Forms.TextBox();
            this.debugButton = new System.Windows.Forms.Button();
            this.debugCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longEdgeBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.openButton.Location = new System.Drawing.Point(348, 10);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(41, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // resizePercentageSlider
            // 
            this.resizePercentageSlider.LargeChange = 10;
            this.resizePercentageSlider.Location = new System.Drawing.Point(130, 19);
            this.resizePercentageSlider.Maximum = 100;
            this.resizePercentageSlider.Minimum = 1;
            this.resizePercentageSlider.Name = "resizePercentageSlider";
            this.resizePercentageSlider.Size = new System.Drawing.Size(200, 45);
            this.resizePercentageSlider.TabIndex = 5;
            this.resizePercentageSlider.Value = 1;
            this.resizePercentageSlider.Scroll += new System.EventHandler(this.resizePercentageSlider_Scroll);
            // 
            // jpegQualitySlider
            // 
            this.jpegQualitySlider.LargeChange = 10;
            this.jpegQualitySlider.Location = new System.Drawing.Point(130, 25);
            this.jpegQualitySlider.Maximum = 100;
            this.jpegQualitySlider.Name = "jpegQualitySlider";
            this.jpegQualitySlider.Size = new System.Drawing.Size(200, 45);
            this.jpegQualitySlider.TabIndex = 6;
            this.jpegQualitySlider.Scroll += new System.EventHandler(this.jpegQualitySlider_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "JPEG Quality:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(348, 282);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(41, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveLocation
            // 
            this.saveLocation.Location = new System.Drawing.Point(130, 284);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.ReadOnly = true;
            this.saveLocation.Size = new System.Drawing.Size(212, 20);
            this.saveLocation.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Save Location:";
            // 
            // resizeButton
            // 
            this.resizeButton.Location = new System.Drawing.Point(12, 311);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(380, 25);
            this.resizeButton.TabIndex = 12;
            this.resizeButton.Text = "Resize!";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // resizePercentageBox
            // 
            this.resizePercentageBox.Location = new System.Drawing.Point(336, 20);
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
            this.jpegQualityBox.Location = new System.Drawing.Point(336, 25);
            this.jpegQualityBox.Name = "jpegQualityBox";
            this.jpegQualityBox.Size = new System.Drawing.Size(40, 20);
            this.jpegQualityBox.TabIndex = 14;
            this.jpegQualityBox.ValueChanged += new System.EventHandler(this.jpegQualityBox_ValueChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(325, 339);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(67, 13);
            this.versionLabel.TabIndex = 15;
            this.versionLabel.Text = "VERSION__";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.longEdgeBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.longEdgeRadioButton);
            this.groupBox1.Controls.Add(this.percentageRadioButton);
            this.groupBox1.Controls.Add(this.resizePercentageSlider);
            this.groupBox1.Controls.Add(this.resizePercentageBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 126);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize Mode";
            // 
            // longEdgeBox
            // 
            this.longEdgeBox.Enabled = false;
            this.longEdgeBox.Location = new System.Drawing.Point(130, 55);
            this.longEdgeBox.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.longEdgeBox.Name = "longEdgeBox";
            this.longEdgeBox.Size = new System.Drawing.Size(244, 20);
            this.longEdgeBox.TabIndex = 16;
            this.longEdgeBox.ValueChanged += new System.EventHandler(this.longEdgeBox_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resizeLabel);
            this.groupBox2.Controls.Add(this.sizeLabel);
            this.groupBox2.Location = new System.Drawing.Point(4, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 38);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resulting Size:";
            // 
            // resizeLabel
            // 
            this.resizeLabel.AutoSize = true;
            this.resizeLabel.Location = new System.Drawing.Point(182, 16);
            this.resizeLabel.Name = "resizeLabel";
            this.resizeLabel.Size = new System.Drawing.Size(37, 13);
            this.resizeLabel.TabIndex = 1;
            this.resizeLabel.Text = "SIZE_";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(7, 16);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(37, 13);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "SIZE_";
            // 
            // longEdgeRadioButton
            // 
            this.longEdgeRadioButton.AutoSize = true;
            this.longEdgeRadioButton.Location = new System.Drawing.Point(6, 58);
            this.longEdgeRadioButton.Name = "longEdgeRadioButton";
            this.longEdgeRadioButton.Size = new System.Drawing.Size(115, 17);
            this.longEdgeRadioButton.TabIndex = 1;
            this.longEdgeRadioButton.Text = "Resize Long Edge:";
            this.longEdgeRadioButton.UseVisualStyleBackColor = true;
            this.longEdgeRadioButton.CheckedChanged += new System.EventHandler(this.longEdgeRadioButton_CheckedChanged);
            // 
            // percentageRadioButton
            // 
            this.percentageRadioButton.AutoSize = true;
            this.percentageRadioButton.Checked = true;
            this.percentageRadioButton.Location = new System.Drawing.Point(7, 20);
            this.percentageRadioButton.Name = "percentageRadioButton";
            this.percentageRadioButton.Size = new System.Drawing.Size(118, 17);
            this.percentageRadioButton.TabIndex = 0;
            this.percentageRadioButton.TabStop = true;
            this.percentageRadioButton.Text = "Resize Percentage:";
            this.percentageRadioButton.UseVisualStyleBackColor = true;
            this.percentageRadioButton.CheckedChanged += new System.EventHandler(this.percentageRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.debugLocation);
            this.groupBox3.Controls.Add(this.debugButton);
            this.groupBox3.Controls.Add(this.debugCheckbox);
            this.groupBox3.Controls.Add(this.jpegQualitySlider);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.jpegQualityBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 100);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resize Settings";
            // 
            // debugLocation
            // 
            this.debugLocation.Location = new System.Drawing.Point(118, 75);
            this.debugLocation.Name = "debugLocation";
            this.debugLocation.ReadOnly = true;
            this.debugLocation.Size = new System.Drawing.Size(212, 20);
            this.debugLocation.TabIndex = 18;
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(336, 75);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(41, 23);
            this.debugButton.TabIndex = 16;
            this.debugButton.Text = "Open";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.debugCheckbox.Location = new System.Drawing.Point(4, 77);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(88, 17);
            this.debugCheckbox.TabIndex = 15;
            this.debugCheckbox.Text = "Debug Mode";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            this.debugCheckbox.CheckedChanged += new System.EventHandler(this.debugCheckbox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 361);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.openLocation);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 400);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "JPEG Resizer";
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualitySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePercentageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longEdgeBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox openLocation;
        private System.Windows.Forms.Button openButton;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton longEdgeRadioButton;
        private System.Windows.Forms.RadioButton percentageRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown longEdgeBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox debugCheckbox;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.TextBox debugLocation;
        private System.Windows.Forms.Label resizeLabel;
    }
}

