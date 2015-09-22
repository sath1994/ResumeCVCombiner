namespace PDFCombinerApplication
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
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.CombineButton = new System.Windows.Forms.Button();
            this.CoverLetterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(13, 13);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(429, 13);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "Select the resume and then all the respective Coverletters. Out comes the combine" +
    "d pdfs.";
            // 
            // ResumeButton
            // 
            this.ResumeButton.Location = new System.Drawing.Point(16, 29);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(75, 23);
            this.ResumeButton.TabIndex = 1;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // CombineButton
            // 
            this.CombineButton.Location = new System.Drawing.Point(444, 29);
            this.CombineButton.Name = "CombineButton";
            this.CombineButton.Size = new System.Drawing.Size(95, 23);
            this.CombineButton.TabIndex = 2;
            this.CombineButton.Text = "CombineButton";
            this.CombineButton.UseVisualStyleBackColor = true;
            this.CombineButton.Click += new System.EventHandler(this.CombineButton_Click);
            // 
            // CoverLetterButton
            // 
            this.CoverLetterButton.Location = new System.Drawing.Point(239, 29);
            this.CoverLetterButton.Name = "CoverLetterButton";
            this.CoverLetterButton.Size = new System.Drawing.Size(75, 23);
            this.CoverLetterButton.TabIndex = 3;
            this.CoverLetterButton.Text = "CoverLetters";
            this.CoverLetterButton.UseVisualStyleBackColor = true;
            this.CoverLetterButton.Click += new System.EventHandler(this.CoverLetterButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 58);
            this.Controls.Add(this.CoverLetterButton);
            this.Controls.Add(this.CombineButton);
            this.Controls.Add(this.ResumeButton);
            this.Controls.Add(this.InstructionLabel);
            this.Name = "Form1";
            this.Text = "Resume + CoverLetter PDF Combiner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button CombineButton;
        private System.Windows.Forms.Button CoverLetterButton;
    }
}

