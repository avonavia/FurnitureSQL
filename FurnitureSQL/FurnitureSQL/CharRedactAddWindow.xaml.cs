using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Collections.Generic;
using System;

namespace FurnitureSQL
{
    public partial class CharRedactAddWindow : Window
    {
        public static string conString { get; set; }
        public static Machine redactingMachine { get; set; }
        public CharRedactAddWindow()
        {
            InitializeComponent();
        }

        public void AddCharacteristic()
        {
            string cmdString = "AddCharacteristic";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = redactingMachine.ID
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name_box.Text
                };
                cmd.Parameters.Add(Param1);

                SqlParameter Param2 = new SqlParameter
                {
                    ParameterName = "@value",
                    Value = value_box.Text
                };
                cmd.Parameters.Add(Param2);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
        public bool ValidateBoxes()
        {
            bool result = false;
            try
            {
                if (name_box.Text == "" || value_box.Text == "")
                {
                    throw new Exception("Не все поля заполнены");
                }
                if (name_box.Text.Length > 255 || value_box.Text.Length > 255)
                {
                    throw new Exception("Превышено количество символов");
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
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

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MachineListWindow machineListWindow = new MachineListWindow();
            machineListWindow.Show();
            Close();
        }

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateBoxes())
            {
                AddCharacteristic();
                MessageBox.Show("Успешно");
                MachineListWindow machineListWindow = new MachineListWindow();
                machineListWindow.Show();
                Close();
            }
        }
    }
}
