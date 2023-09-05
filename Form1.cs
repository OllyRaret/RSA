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
            // Проверка что есть текст для шифрования
            if (inputText.Text == "")
            {
                MessageBox.Show("Текст для шифрования не введен", "Невозможно зашифровать", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Генерация RSA-ключей
            GenerateKeys(out publicKey, out privateKey);

            // Шифрование данных
            encryptData = RSAEncrypt(publicKey, inputText.Text);
            encryptedText.Text = encryptData;
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            // Проверка что есть текст для расшифровки 
            if (encryptedText.Text == "")
            {
                MessageBox.Show("Текст для расшифровки не введен", "Невозможно расшифровать", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Расшифровка данных
            decryptedText.Text = RSADecrypt(privateKey, encryptData);
        }

        // Генерация пары ключей
        public static void GenerateKeys(out string publicKey, out string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false); // Открытый ключ
                privateKey = rsa.ToXmlString(true); // Закрытый ключ
            }
        }

        // Зашифровать текст
        public static string RSAEncrypt(string publicKey, string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext); // Преобразуем в байты

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey); // Используем открытый ключ

                int maxLength = ((rsa.KeySize / 8) - 11) / 2; // Находим максимальную длину блока

                if (plaintextBytes.Length <= maxLength) // Если сообщение короче максимальной длины, шифруем его
                {
                    return Convert.ToBase64String(rsa.Encrypt(plaintextBytes, true));
                }

                var encryptedBytes = new List<byte>(); // Создаем переменную для хранения результата
                for (int i = 0; i < plaintextBytes.Length; i += maxLength)
                {
                    int currentLength = Math.Min(maxLength, plaintextBytes.Length - i); // Находим длину текущего блока
                    var currentBytes = new byte[currentLength];
                    Array.Copy(plaintextBytes, i, currentBytes, 0, currentLength); // Копируем текущий блок в буфер

                    var encrypted = rsa.Encrypt(currentBytes, true); // Шифруем блок
                    encryptedBytes.AddRange(encrypted); // Добавляем зашифрованный блок к результату 
                }

                return Convert.ToBase64String(encryptedBytes.ToArray());
            }
        }

        // Расшифровка сообщения
        public static string RSADecrypt(string privateKey, string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText); // Преобразуем шифр в байты

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey); // Используем закрытый ключ

                int maxLength = rsa.KeySize / 8; // Находим максимальную длину блока

                if (encryptedBytes.Length <= maxLength) // Если длина шифра меньше максимальной длины, расшифровываем его
                {
                    return Encoding.UTF8.GetString(rsa.Decrypt(encryptedBytes, true));
                }

                var decryptedBytes = new List<byte>(); // Создаем переменную для хранения результата
                for (int i = 0; i < encryptedBytes.Length; i += maxLength)
                {
                    int currentLength = Math.Min(maxLength, encryptedBytes.Length - i); // Находим длину текущего блока
                    var currentBytes = new byte[currentLength];
                    Array.Copy(encryptedBytes, i, currentBytes, 0, currentLength); // Копируем текущий блок в буфер

                    var decrypted = rsa.Decrypt(currentBytes, true); // Расшифровываем блок
                    decryptedBytes.AddRange(decrypted); // Добавляем расшифрованный блок к результату 
                }

                return Encoding.UTF8.GetString(decryptedBytes.ToArray());
            }
        }
    }
}