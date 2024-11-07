
namespace QRCodeCreater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreateQRCode = new System.Windows.Forms.Button();
            txtInput = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCreateQRCode
            // 
            btnCreateQRCode.Location = new System.Drawing.Point(8, 8);
            btnCreateQRCode.Margin = new System.Windows.Forms.Padding(2);
            btnCreateQRCode.Name = "btnCreateQRCode";
            btnCreateQRCode.Size = new System.Drawing.Size(63, 22);
            btnCreateQRCode.TabIndex = 0;
            btnCreateQRCode.Text = "Create";
            btnCreateQRCode.UseVisualStyleBackColor = true;
            btnCreateQRCode.Click += btnCreateQRCode_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new System.Drawing.Point(74, 10);
            txtInput.Margin = new System.Windows.Forms.Padding(2);
            txtInput.Name = "txtInput";
            txtInput.Size = new System.Drawing.Size(117, 23);
            txtInput.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(25, 78);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(300, 300);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(381, 398);
            Controls.Add(pictureBox1);
            Controls.Add(txtInput);
            Controls.Add(btnCreateQRCode);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Form1";
            Text = "QRCodeCreater";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnCreateQRCode;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

