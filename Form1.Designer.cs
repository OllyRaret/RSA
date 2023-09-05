namespace RSA
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
            inputText = new TextBox();
            encryptedText = new TextBox();
            decryptedText = new TextBox();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            buttonEncrypt = new Button();
            buttonDecrypt = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // inputText
            // 
            inputText.BackColor = SystemColors.InactiveBorder;
            inputText.Location = new Point(6, 26);
            inputText.MaximumSize = new Size(348, 100);
            inputText.MinimumSize = new Size(348, 100);
            inputText.Multiline = true;
            inputText.Name = "inputText";
            inputText.Size = new Size(348, 100);
            inputText.TabIndex = 7;
            // 
            // encryptedText
            // 
            encryptedText.BackColor = SystemColors.InactiveBorder;
            encryptedText.Location = new Point(6, 26);
            encryptedText.MaximumSize = new Size(348, 100);
            encryptedText.MinimumSize = new Size(348, 100);
            encryptedText.Multiline = true;
            encryptedText.Name = "encryptedText";
            encryptedText.ReadOnly = true;
            encryptedText.Size = new Size(348, 100);
            encryptedText.TabIndex = 8;
            // 
            // decryptedText
            // 
            decryptedText.BackColor = SystemColors.InactiveBorder;
            decryptedText.Location = new Point(6, 26);
            decryptedText.MaximumSize = new Size(348, 100);
            decryptedText.MinimumSize = new Size(348, 100);
            decryptedText.Multiline = true;
            decryptedText.Name = "decryptedText";
            decryptedText.ReadOnly = true;
            decryptedText.Size = new Size(348, 100);
            decryptedText.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inputText);
            groupBox1.Location = new Point(22, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 134);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод текста:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(decryptedText);
            groupBox3.Location = new Point(22, 310);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(362, 141);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Расшифрованный текст:";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(encryptedText);
            groupBox2.Location = new Point(22, 152);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(362, 152);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Зашифрованный текст:";
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(58, 471);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(132, 32);
            buttonEncrypt.TabIndex = 14;
            buttonEncrypt.Text = "Зашифровать";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += buttonEncrypt_Click;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(211, 471);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(132, 32);
            buttonDecrypt.TabIndex = 15;
            buttonDecrypt.Text = "Расшифровать";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(408, 515);
            Controls.Add(buttonDecrypt);
            Controls.Add(buttonEncrypt);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            MaximumSize = new Size(426, 562);
            MinimumSize = new Size(426, 562);
            Name = "Form1";
            Text = "Шифрование RSA";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox inputText;
        private TextBox encryptedText;
        private TextBox decryptedText;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Button buttonEncrypt;
        private Button buttonDecrypt;
    }
}