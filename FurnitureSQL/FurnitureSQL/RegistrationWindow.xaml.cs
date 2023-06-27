using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;

namespace FurnitureSQL
{
    public partial class RegistrationWindow : Window
    {
        public static string conString { get; set; }
        public static string password { get; set; }
        public static string login { get; set; }
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        public void AddUser()
        {
            string cmdString = "AddUser";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter surnameParam = new SqlParameter
                {
                    ParameterName = "@surname",
                    Value = Surname_box.Text
                };
                cmd.Parameters.Add(surnameParam);

                SqlParameter firstnameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = First_name_box.Text
                };
                cmd.Parameters.Add(firstnameParam);

                SqlParameter lastnameParam = new SqlParameter
                {
                    ParameterName = "@lastname",
                    Value = Last_name_box.Text
                };
                cmd.Parameters.Add(lastnameParam);

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = password
                };
                cmd.Parameters.Add(Param1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool CheckLoginExists()
        {
            bool output = false;
            string cmdString = "CheckLoginExists";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                cmd.Parameters.Add(Param);

                con.Open();

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                if (result == 1)
                {
                    output = true;
                }
                return output;
            }
        }

        public bool ValidateBoxes()
        {
            bool result = false;
            char[] unacceptable = { '"', '/', '\\', ',', '.', ' ', '$', '*', '#', '№', '&', '!', '?', '(', ')', '{', '}', '[', ']', '`', '~' };

            const string usingUnacceptableCharachtersError = "Использвание служебных символов запрещено";
            const string emptyFieldsError = "Поля 'Имя' и 'Фамилия' должны быть заполнены";
            const string tooManySymbolsMessage = "Одно или несколько полей содержит более 255 символов";

            try
            {
                if (Surname_box.Text == "" || First_name_box.Text == "")
                {
                    throw new Exception(emptyFieldsError);
                }
                if (Surname_box.Text.Length > 255 || First_name_box.Text.Length > 255 || Last_name_box.Text.Length > 255)
                {
                    throw new Exception(tooManySymbolsMessage);
                }
                for (var i = 0; i < unacceptable.Length; i++)
                {
                    if (Surname_box.Text.Contains(unacceptable[i].ToString()) || First_name_box.Text.Contains(unacceptable[i].ToString()) || Last_name_box.Text.Contains(unacceptable[i].ToString()))
                    {
                        throw new Exception(usingUnacceptableCharachtersError);
                    }
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public string passSymbols = "1234567890abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ@/?.,!*&{}|+";
        public void GenerateLogin()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            login = "loginDE";
            Random rand = new Random();
            for (var i = 0; i < 3; i++)
            {
                int num = rand.Next(0, letters.Length);
                login += letters[num];
            }
            login += DateTime.Now.Year;

        }

        public void GeneratePassword()
        {
            string temppass = string.Empty;
            Random rand = new Random();
            for (var i = 0; i < 8; i++)
            {
                int num = rand.Next(0, passSymbols.Length);
                temppass += passSymbols[num];
            }
            password = temppass;
        }

        public void GenerateInfo()
        {
            GenerateLogin();
            while (CheckLoginExists())
            {
                GenerateLogin();
            }
            GeneratePassword();
            while (PasswordCheck.CheckPassword(password) != 4)
            {
                GeneratePassword();
            }
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateBoxes())
            {
                GenerateInfo();
                AddUser();
                MessageBox.Show("Ваш логин: " + login + "\nВаш пароль: " + password);
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
        }
    }
}
