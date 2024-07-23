namespace HashAndSalt_FormApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbHashAlgorithms;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblHashAlgorithm;
        private System.Windows.Forms.TextBox txtDecodedResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbHashAlgorithms = new ComboBox();
            btnHash = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblHashAlgorithm = new Label();
            txtDecodedResult = new TextBox();
            SuspendLayout();
            // 
            // cmbHashAlgorithms
            // 
            cmbHashAlgorithms.FormattingEnabled = true;
            cmbHashAlgorithms.Location = new Point(7, 87);
            cmbHashAlgorithms.Name = "cmbHashAlgorithms";
            cmbHashAlgorithms.Size = new Size(121, 28);
            cmbHashAlgorithms.TabIndex = 0;
            cmbHashAlgorithms.SelectedIndexChanged += cmbHashAlgorithms_SelectedIndexChanged;
            // 
            // btnHash
            // 
            btnHash.Location = new Point(151, 56);
            btnHash.Name = "btnHash";
            btnHash.Size = new Size(121, 37);
            btnHash.TabIndex = 1;
            btnHash.Text = "Encrypt";
            btnHash.UseVisualStyleBackColor = true;
            btnHash.Click += btnHash_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(7, 34);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(121, 27);
            txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(7, 11);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // lblHashAlgorithm
            // 
            lblHashAlgorithm.AutoSize = true;
            lblHashAlgorithm.ForeColor = Color.White;
            lblHashAlgorithm.Location = new Point(7, 64);
            lblHashAlgorithm.Name = "lblHashAlgorithm";
            lblHashAlgorithm.Size = new Size(79, 20);
            lblHashAlgorithm.TabIndex = 4;
            lblHashAlgorithm.Text = "Algorithm:";
            // 
            // txtDecodedResult
            // 
            txtDecodedResult.Location = new Point(7, 162);
            txtDecodedResult.Name = "txtDecodedResult";
            txtDecodedResult.Size = new Size(263, 27);
            txtDecodedResult.TabIndex = 5;
            // 
            // Form1
            // 
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(282, 231);
            Controls.Add(txtDecodedResult);
            Controls.Add(lblHashAlgorithm);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnHash);
            Controls.Add(cmbHashAlgorithms);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}