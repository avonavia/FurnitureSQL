using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;
using System.Collections.Generic;


namespace FurnitureSQL
{
    public partial class MachineRedactAddWindow : Window
    {
        public static string conString { get; set; }
        public static bool IsRedacting { get; set; }
        public static Machine redactingMachine { get; set; }
        public MachineRedactAddWindow()
        {
            InitializeComponent();
            GetMachineTypes();
            GetMachineStatusList();
            FillBoxes();
        }

        public void FillBoxes()
        {
            if (IsRedacting)
            {
                name_box.Text = redactingMachine.Name;
                TypeBox.SelectedItem = redactingMachine.Type;
                StatusBox.SelectedItem = redactingMachine.Status;
            }
        }

        public bool ValidateBoxes()
        {
            bool result = false;
            char[] unacceptable = { '"', '/', '\\', ',', '$', '*', '#', '&', '!', '?', '{', '}', '[', ']', '`', '~' };
            try
            {
                if (name_box.Text == "" || TypeBox.SelectedItem == null || StatusBox.SelectedItem == null)
                {
                    throw new Exception("Не все поля заполнены");
                }
                foreach (var item in unacceptable)
                {
                    if (name_box.Text.Contains(item.ToString()))
                    {
                        throw new Exception("В названии содержатся запрещённые символы");
                    }
                }
                if (name_box.Text.Length > 255)
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

        List<string> typelist = new List<string>();
        List<string> statuslist = new List<string>();

        public void GetMachineTypes()
        {
            TypeBox.ItemsSource = null;
            typelist.Clear();
            string cmdString = "GetMachineTypes";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    typelist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();
                TypeBox.ItemsSource = typelist;
            }
        }

        public void GetMachineStatusList()
        {
            StatusBox.ItemsSource = null;
            statuslist.Clear();
            string cmdString = "GetMachineStatusList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    statuslist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();
                StatusBox.ItemsSource = statuslist;
            }
        }

        public int GetMachineTypeIDFromName()
        {
            string cmdString = "GetMachineTypeIDFromName";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = TypeBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param);

                con.Open();

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result;
            }
        }

        public int GetMachineStatusIDFromName()
        {
            string cmdString = "GetMachineStatusIDFromName";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = StatusBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param);

                con.Open();

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result;
            }
        }

        public void AddMachine()
        {
            string cmdString = "AddMachine";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name_box.Text
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@typeID",
                    Value = GetMachineTypeIDFromName()
                };
                cmd.Parameters.Add(Param1);

                SqlParameter Param2 = new SqlParameter
                {
                    ParameterName = "@statusID",
                    Value = GetMachineStatusIDFromName()
                };
                cmd.Parameters.Add(Param2);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void RedactMachine()
        {
            string cmdString = "RedactMachine";

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
                    ParameterName = "@typeID",
                    Value = GetMachineTypeIDFromName()
                };
                cmd.Parameters.Add(Param2);

                SqlParameter Param3 = new SqlParameter
                {
                    ParameterName = "@statusID",
                    Value = GetMachineStatusIDFromName()
                };
                cmd.Parameters.Add(Param3);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MachineListWindow machineListWindow = new MachineListWindow();
            machineListWindow.Show();
            Close();
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

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateBoxes())
            {
                if (!IsRedacting)
                {
                    AddMachine();
                }
                else
                {
                    RedactMachine();
                }
                MessageBox.Show("Успешно");
                MachineListWindow machineListWindow = new MachineListWindow();
                machineListWindow.Show();
                Close();
            }
        }
    }
}
