namespace RMGLibrary
{
    namespace Forms
    {
        partial class About
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
                this.pictureBox2 = new System.Windows.Forms.PictureBox();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.changelogButton = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.Location = new System.Drawing.Point(95, 13);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(249, 132);
                this.label1.TabIndex = 2;
                this.label1.Text = "Made by RMGRich.";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // pictureBox2
                // 
                this.pictureBox2.Location = new System.Drawing.Point(13, 95);
                this.pictureBox2.Name = "pictureBox2";
                this.pictureBox2.Size = new System.Drawing.Size(76, 76);
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.pictureBox2.TabIndex = 1;
                this.pictureBox2.TabStop = false;
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(13, 13);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(76, 76);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                // 
                // changelogButton
                // 
                this.changelogButton.Location = new System.Drawing.Point(264, 148);
                this.changelogButton.Name = "changelogButton";
                this.changelogButton.Size = new System.Drawing.Size(75, 23);
                this.changelogButton.TabIndex = 3;
                this.changelogButton.Text = "Changelog";
                this.changelogButton.UseVisualStyleBackColor = true;
                this.changelogButton.Click += new System.EventHandler(this.showChangelog);
                // 
                // About
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(351, 183);
                this.Controls.Add(this.changelogButton);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.pictureBox2);
                this.Controls.Add(this.pictureBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.Name = "About";
                this.Text = "About";
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.PictureBox pictureBox1;
            private System.Windows.Forms.PictureBox pictureBox2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Button changelogButton;
        }
    }
}