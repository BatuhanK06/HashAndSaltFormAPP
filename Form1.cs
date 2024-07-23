using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HashAndSalt_FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbHashAlgorithms.Items.AddRange(new string[] { "SHA-256", "MD5", "Batu Encrypt", "Batu Decrypt" });
            cmbHashAlgorithms.SelectedIndex = 0; 
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string selectedAlgorithm = cmbHashAlgorithms.SelectedItem.ToString();
            string result = string.Empty;

            if (selectedAlgorithm == "SHA-256")
            {
                string salt = GenerateSalt();
                result = HashPasswordSha256(password, salt);
                //result komutu yürütme-baþlatma
            }
            else if (selectedAlgorithm == "MD5")
            {
                string salt = GenerateSalt();
                result = HashPasswordMD5(password, salt);
            }
            else if (selectedAlgorithm == "Batu Encrypt")
            {
                result = BatuEncrypt(password);
            }
            else if (selectedAlgorithm == "Batu Decrypt")
            {
                txtDecodedResult.Text = BatuDecrypt(password);
                return;
                //iþlem bittikten sonra lazým yere geri dönmesine yarar
            }

            MessageBox.Show($"Original text: {password}\nResult ({selectedAlgorithm}): {result}", "Results");
        }


        private string GenerateSalt()
        {
            int saltLength = 16;
            byte[] saltBytes = new byte[saltLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPasswordSha256(string password, string salt)
        {
            string saltedPassword = salt + password;
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private string HashPasswordMD5(string password, string salt)
        {
            string saltedPassword = salt + password;
            using (var md5 = MD5.Create())
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = md5.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private string CustomBinaryHash(string input)
        {
            return string.Empty; 
        }

        private string BatuEncrypt(string input)
        {
            var charToBinaryMap = new Dictionary<char, string>
            {
                { 'A', "0" },{ 'B', "1" }, { 'C', "2" },{ 'D', "3" },{ 'E', "4" },{ 'F', "5" },
                { 'G', "6" },{ 'H', "7" },{ 'I', "8" },{ 'J', "9" },{ 'K', "10" },
                { 'L', "11" },{ 'M', "12" },{ 'N', "13" },{ 'O', "14" },{ 'P', "15" },
                { 'Q', "16" },{ 'R', "17" },{ 'S', "18" },{ 'T', "19" },{ 'U', "20" },
                { 'V', "21" },{ 'W', "22" },{ 'X', "23" },{ 'Y', "24" },{ 'Z', "25" }
            };

            var builder = new StringBuilder();

            foreach (var ch in input.ToUpper())
            {
                if (charToBinaryMap.ContainsKey(ch))
                {
                    builder.Append(charToBinaryMap[ch] + " ");
                }
                else
                {
                    builder.Append(" ");
                    //dize oluþturucusunun dize gösterimini ekler
                }
            }

            return builder.ToString().TrimEnd();
        }

        private string BatuDecrypt(string input)
        {
            var binaryToCharMap = new Dictionary<string, char>
            {
                {"0",'A'},{"1",'B'},{"2",'C'},{"3",'D'},{"4",'E'},{"5",'F'},
                {"6",'G'},{"7",'H'},{"8",'I'},{"9",'J'},{"10",'K'},{"11",'L'},
                {"12",'M'},{"13",'N'},{"14",'O'},{"15",'P'},{"16", 'Q'},
                {"17",'R'},{"18",'S'},{"19",'T'},{"20",'U'},{"21",'V'},
                {"22",'W'},{"23",'X'},{"24",'Y'},{"25",'Z'}
            };

            var builder = new StringBuilder();
            var binaryParts = input.Split(' ');

            foreach (var binary in binaryParts)
            {
                if (binaryToCharMap.ContainsKey(binary))
                {
                    builder.Append(binaryToCharMap[binary]);
                }
                else
                {
                    builder.Append(' ');
                }
            }

            return builder.ToString();
        }

        private void cmbHashAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}