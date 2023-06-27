using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;

namespace FurnitureSQL
{
    public partial class LoginWindow : Window
    {
        static string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog=FurnitureDB; Integrated Security=true;";
        public static User currentUser { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            Capcha();
            RegistrationWindow.conString = conString;
            CustomerWindow.conString = conString;
            MasterWindow.conString = conString;
            DirectorWindow.conString = conString;
            ManagerWindow.conString = conString;
            DeputyDirectorWindow.conString = conString;
            WorkshopElementsWindow.conString = conString;
            MachineListWindow.conString = conString;
            MachineRedactAddWindow.conString = conString;
            MaterialsListWindow.conString = conString;
            CharRedactAddWindow.conString = conString;
            MaterialRedactAddWindow.conString = conString;
            FurnitureListWindow.conString = conString;
            FurnitureRedactAddWindow.conString = conString;
        }

        public int FailCount = 0;
        public bool CapchaShowing = true;
        public void HideCapcha()
        {
            CapchaButton.Visibility = Visibility.Hidden;
            CapchaLable.Visibility = Visibility.Hidden;
            GeneratedCapchaLabel.Visibility = Visibility.Hidden;
            capcha_box.Visibility = Visibility.Hidden;
        }

        public void ShowCapcha()
        {
            CapchaButton.Visibility = Visibility.Visible;
            CapchaLable.Visibility = Visibility.Visible;
            GeneratedCapchaLabel.Visibility = Visibility.Visible;
            capcha_box.Visibility = Visibility.Visible;
        }

        const string capchaNotSolvedError = "Для продолжения необходимо решить капчу";

        public string GenerateCapcha()
        {
            string capcha = string.Empty;
            string letters = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            for (var i = 0; i < 4; i++)
            {
                int num = rand.Next(0, letters.Length);
                capcha += letters[num];
            }
            return capcha;
        }
        public void Capcha()
        {
            CapchaShowing = true;
            ShowCapcha();
            GeneratedCapchaLabel.Content = GenerateCapcha();
        }

        public bool ValidateBoxes()
        {
            bool result = false;
            const string emptyFieldsError = "Все оля должны быть заполнены";
            const string tooManySymbolsMessage = "Одно или несколько полей содержит более 255 символов";

            try
            {
                if (login_box.Text == "" || password_box.Text == "")
                {
                    throw new Exception(emptyFieldsError);
                }
                if (login_box.Text.Length > 255 || password_box.Text.Length > 255)
                {
                    throw new Exception(tooManySymbolsMessage);
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }
        public bool CheckUserValid()
        {
            bool output = false;
            string cmdString = "CheckUserValid";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login_box.Text
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = password_box.Text
                };
                cmd.Parameters.Add(Param1);

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

        public void GetUserByLogin()
        {
            string cmdString = "GetUserByLogin";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login_box.Text
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = password_box.Text
                };
                cmd.Parameters.Add(Param1);

                con.Open();
                User st = new User();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    st.ID = (int)reader[0];
                    st.Surname = reader[1].ToString();
                    st.Name = reader[2].ToString();
                    st.Lastname = reader[3].ToString();
                    st.Login = reader[4].ToString();
                    st.Password = reader[5].ToString();
                    st.RoleID = (int)reader[6];
                }
                reader.Close();

                currentUser = st;

                con.Close();
            }
        }

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (!CapchaShowing)
            {
                if (ValidateBoxes())
                {
                    if (CheckUserValid())
                    {
                        GetUserByLogin();
                        if (currentUser.RoleID == 1)
                        {
                            CustomerWindow.currentUser = currentUser;
                            CustomerWindow customerWindow = new CustomerWindow();
                            customerWindow.Show();
                            Close();
                        }
                        if (currentUser.RoleID == 2)
                        {
                            MasterWindow.currentUser = currentUser;
                            MasterWindow masterWindow = new MasterWindow();
                            masterWindow.Show();
                            Close();
                        }
                        if (currentUser.RoleID == 3)
                        {
                            DirectorWindow.currentUser = currentUser;
                            DirectorWindow directorWindow = new DirectorWindow();
                            directorWindow.Show();
                            Close();
                        }
                        if (currentUser.RoleID == 4)
                        {
                            ManagerWindow.currentUser = currentUser;
                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                            Close();
                        }
                        if (currentUser.RoleID == 5)
                        {
                            DeputyDirectorWindow.currentUser = currentUser;
                            DeputyDirectorWindow deputyDirectorWindow = new DeputyDirectorWindow();
                            deputyDirectorWindow.Show();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                        FailCount++;
                        if (FailCount > 2)
                        {
                            Capcha();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(capchaNotSolvedError);
            }
        }
        private void CapchaButton_Click(object sender, RoutedEventArgs e)
        {
            if (GeneratedCapchaLabel.Content.ToString() == capcha_box.Text)
            {
                FailCount = 0;
                HideCapcha();
                CapchaShowing = false;
                capcha_box.Text = "";
            }
            else
            {
                Capcha();
            }
        }

        private void Reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (!CapchaShowing)
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                registrationWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show(capchaNotSolvedError);
            }
        }
    }
}
