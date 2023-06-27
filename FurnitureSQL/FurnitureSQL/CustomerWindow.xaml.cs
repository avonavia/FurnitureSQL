using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace FurnitureSQL
{
    public partial class CustomerWindow : Window
    {
        public static string conString { get; set; }
        public static User currentUser { get; set; }
        public CustomerWindow()
        {
            InitializeComponent();
            FillLables();
        }

        public string GetRoleByID()
        {
            string cmdString = "GetRoleByID";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = currentUser.RoleID
                };
                cmd.Parameters.Add(Param);

                con.Open();

                string result = cmd.ExecuteScalar().ToString();

                con.Close();

                return result;
            }
        }
        public void FillLables()
        {
            HelloLabel.Content = HelloLabel.Content + currentUser.Surname.Trim(' ') + " " + currentUser.Name + " " + currentUser.Lastname + "\n\n" + "Ваша роль: " + GetRoleByID();
        }
        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
        }
    }
}
