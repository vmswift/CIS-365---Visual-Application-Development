namespace Lab12App
{
    partial class Form1
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
            this.tbxSampleText = new System.Windows.Forms.RichTextBox();
            this.Fonts = new System.Windows.Forms.GroupBox();
            this.cbUnderline = new System.Windows.Forms.CheckBox();
            this.cbBold = new System.Windows.Forms.CheckBox();
            this.cbitalic = new System.Windows.Forms.CheckBox();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.btnFontChange = new System.Windows.Forms.Button();
            this.Fonts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxSampleText
            // 
            this.tbxSampleText.Location = new System.Drawing.Point(12, 24);
            this.tbxSampleText.Name = "tbxSampleText";
            this.tbxSampleText.Size = new System.Drawing.Size(506, 444);
            this.tbxSampleText.TabIndex = 0;
            this.tbxSampleText.Text = "Now is the time for all good men to come to the aid of their country.";
            this.tbxSampleText.TextChanged += new System.EventHandler(this.tbxSampleText_TextChanged);
            // 
            // Fonts
            // 
            this.Fonts.Controls.Add(this.btnFontChange);
            this.Fonts.Controls.Add(this.nudFontSize);
            this.Fonts.Controls.Add(this.cbUnderline);
            this.Fonts.Controls.Add(this.cbBold);
            this.Fonts.Controls.Add(this.cbitalic);
            this.Fonts.Location = new System.Drawing.Point(524, 46);
            this.Fonts.Name = "Fonts";
            this.Fonts.Size = new System.Drawing.Size(190, 389);
            this.Fonts.TabIndex = 1;
            this.Fonts.TabStop = false;
            this.Fonts.Text = "Fonts";
            // 
            // cbUnderline
            // 
            this.cbUnderline.AutoSize = true;
            this.cbUnderline.Location = new System.Drawing.Point(7, 66);
            this.cbUnderline.Name = "cbUnderline";
            this.cbUnderline.Size = new System.Drawing.Size(71, 17);
            this.cbUnderline.TabIndex = 2;
            this.cbUnderline.Text = "Underline";
            this.cbUnderline.UseVisualStyleBackColor = true;
            // 
            // cbBold
            // 
            this.cbBold.AutoSize = true;
            this.cbBold.Location = new System.Drawing.Point(7, 43);
            this.cbBold.Name = "cbBold";
            this.cbBold.Size = new System.Drawing.Size(47, 17);
            this.cbBold.TabIndex = 1;
            this.cbBold.Text = "Bold";
            this.cbBold.UseVisualStyleBackColor = true;
            // 
            // cbitalic
            // 
            this.cbitalic.AutoSize = true;
            this.cbitalic.Location = new System.Drawing.Point(7, 20);
            this.cbitalic.Name = "cbitalic";
            this.cbitalic.Size = new System.Drawing.Size(48, 17);
            this.cbitalic.TabIndex = 0;
            this.cbitalic.Text = "Italic";
            this.cbitalic.UseVisualStyleBackColor = true;
            this.cbitalic.CheckedChanged += new System.EventHandler(this.cbitalic_CheckedChanged);
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(7, 265);
            this.nudFontSize.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(120, 20);
            this.nudFontSize.TabIndex = 3;
            this.nudFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // btnFontChange
            // 
            this.btnFontChange.Location = new System.Drawing.Point(17, 291);
            this.btnFontChange.Name = "btnFontChange";
            this.btnFontChange.Size = new System.Drawing.Size(100, 23);
            this.btnFontChange.TabIndex = 4;
            this.btnFontChange.Text = "Set Font Size";
            this.btnFontChange.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 507);
            this.Controls.Add(this.Fonts);
            this.Controls.Add(this.tbxSampleText);
            this.Name = "Form1";
            this.Text = "Lab12 Application";
            this.Fonts.ResumeLayout(false);
            this.Fonts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbxSampleText;
        private System.Windows.Forms.GroupBox Fonts;
        private System.Windows.Forms.CheckBox cbitalic;
        private System.Windows.Forms.CheckBox cbUnderline;
        private System.Windows.Forms.CheckBox cbBold;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.Button btnFontChange;
    }
}

