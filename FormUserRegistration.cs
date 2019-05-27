using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Libb
{
    public partial class FormUserRegistration : Form
    {
        Reader reader = new Reader();
        string now = Convert.ToString(DateTime.Now.ToShortDateString());
        bool isEmailValid, isPasswordValid, isPhoneNumberValid;
        string hashPass;


        public FormUserRegistration()
        {
            InitializeComponent();
        }


        private void FormUserRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginUser form = new LoginUser();
            this.Hide();
            form.Show();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text) &&
                string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text) &&
                string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text) &&
                string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не сте въвели информация във всички полета!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                reader.Firstname = textBox1.Text.Trim();
                reader.Lastname = textBox2.Text.Trim();
                string phone = textBox3.Text.Trim();
                string email = textBox4.Text.Trim();
                string username = textBox5.Text.Trim();
                string password = textBox6.Text.Trim();
                string rePassword = textBox7.Text.Trim();
                string date = DateTime.Today.ToString("dd-MM-yyyy");
                reader.DateOfRegistration = DateTime.Parse(date);

                isPhoneNumberValid = PhoneNumberValidation(phone);
                isEmailValid = EmailValidation(email);
                isPasswordValid = PasswordValidation(password, rePassword);

                if (isPhoneNumberValid == true){
                    reader.Phone = phone;
                }
                else {
                    MessageBox.Show("Телефонният номер който сте въвели, е НЕвалиден!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (isEmailValid == false) {
                    MessageBox.Show("Имейлът който сте въвели,е НЕвалиден!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (isPasswordValid == true){
                    hashPass = GenerateSHA256String(password);
                }
                else {
                    MessageBox.Show("Няма съвпадение в паролите!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



                if (isPasswordValid == true && isEmailValid == true && isPhoneNumberValid == true)
                {
                    using (var db = new DBModels())
                    {
                        var query = db.Readers.Where(u => u.Username == username).FirstOrDefault();
                        if (query != null)
                        {
                            if (username == query.Username){
                                MessageBox.Show("Акаунт с това потребителско име, съществува.\nМоля въведете друго!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else{
                            reader.Username = username;
                            reader.Password = hashPass;
                            reader.Email = email;

                            using (DBModels lib = new DBModels()){
                                lib.Readers.Add(reader);
                                lib.SaveChanges();
                            }
                            MessageBox.Show("Акаунтът е създаден успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                        }
                    }
                }
            }
        }

        public static string GenerateSHA256String(string inputString) {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash) {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        bool EmailValidation(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch{
                return false;
            }
        }

        private void FormUserRegistration_Load(object sender, EventArgs e)
        {
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
            toolTipSave.SetToolTip(this.buttonRegistration, "Регистрация");
        }

        bool PasswordValidation(string pass1, string pass2) {
            if (pass1 == pass2) {
                return true;
            }
            else {
                return false;
            }
        }

        bool PhoneNumberValidation(string number)
        {
            if (Regex.Match(number,@"^([\+]?61[-]?|[0])?[1-9][0-9]{8}$").Success)
                return true;
            else
                return false;
        }
    }
}
