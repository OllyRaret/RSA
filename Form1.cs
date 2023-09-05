using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    public partial class Form1 : Form
    {
        string encryptData;
        string publicKey;
        string privateKey;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            // �������� ��� ���� ����� ��� ����������
            if (inputText.Text == "")
            {
                MessageBox.Show("����� ��� ���������� �� ������", "���������� �����������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ��������� RSA-������
            GenerateKeys(out publicKey, out privateKey);

            // ���������� ������
            encryptData = RSAEncrypt(publicKey, inputText.Text);
            encryptedText.Text = encryptData;
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            // �������� ��� ���� ����� ��� ����������� 
            if (encryptedText.Text == "")
            {
                MessageBox.Show("����� ��� ����������� �� ������", "���������� ������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ����������� ������
            decryptedText.Text = RSADecrypt(privateKey, encryptData);
        }

        // ��������� ���� ������
        public static void GenerateKeys(out string publicKey, out string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false); // �������� ����
                privateKey = rsa.ToXmlString(true); // �������� ����
            }
        }

        // ����������� �����
        public static string RSAEncrypt(string publicKey, string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext); // ����������� � �����

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey); // ���������� �������� ����

                int maxLength = ((rsa.KeySize / 8) - 11) / 2; // ������� ������������ ����� �����

                if (plaintextBytes.Length <= maxLength) // ���� ��������� ������ ������������ �����, ������� ���
                {
                    return Convert.ToBase64String(rsa.Encrypt(plaintextBytes, true));
                }

                var encryptedBytes = new List<byte>(); // ������� ���������� ��� �������� ����������
                for (int i = 0; i < plaintextBytes.Length; i += maxLength)
                {
                    int currentLength = Math.Min(maxLength, plaintextBytes.Length - i); // ������� ����� �������� �����
                    var currentBytes = new byte[currentLength];
                    Array.Copy(plaintextBytes, i, currentBytes, 0, currentLength); // �������� ������� ���� � �����

                    var encrypted = rsa.Encrypt(currentBytes, true); // ������� ����
                    encryptedBytes.AddRange(encrypted); // ��������� ������������� ���� � ���������� 
                }

                return Convert.ToBase64String(encryptedBytes.ToArray());
            }
        }

        // ����������� ���������
        public static string RSADecrypt(string privateKey, string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText); // ����������� ���� � �����

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey); // ���������� �������� ����

                int maxLength = rsa.KeySize / 8; // ������� ������������ ����� �����

                if (encryptedBytes.Length <= maxLength) // ���� ����� ����� ������ ������������ �����, �������������� ���
                {
                    return Encoding.UTF8.GetString(rsa.Decrypt(encryptedBytes, true));
                }

                var decryptedBytes = new List<byte>(); // ������� ���������� ��� �������� ����������
                for (int i = 0; i < encryptedBytes.Length; i += maxLength)
                {
                    int currentLength = Math.Min(maxLength, encryptedBytes.Length - i); // ������� ����� �������� �����
                    var currentBytes = new byte[currentLength];
                    Array.Copy(encryptedBytes, i, currentBytes, 0, currentLength); // �������� ������� ���� � �����

                    var decrypted = rsa.Decrypt(currentBytes, true); // �������������� ����
                    decryptedBytes.AddRange(decrypted); // ��������� �������������� ���� � ���������� 
                }

                return Encoding.UTF8.GetString(decryptedBytes.ToArray());
            }
        }
    }
}