using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Collections.Generic;

namespace FurnitureSQL
{
    public partial class MachineListWindow : Window
    {
        public static string conString { get; set; }
        public static Machine currentMachine { get; set; }
        public MachineListWindow()
        {
            InitializeComponent();
            GetMachineList();
        }

        List<Machine> machinelist = new List<Machine>();

        public void GetMachineList()
        {
            MachineGrid.ItemsSource = null;
            machinelist.Clear();
            string cmdString = "GetMachineList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Machine st = new Machine();
                    st.ID = (int)reader[0];
                    st.Name = reader[1].ToString();
                    st.Type = reader[2].ToString();
                    st.Status = reader[3].ToString();
                    machinelist.Add(st);
                }
                reader.Close();

                con.Close();
                MachineGrid.ItemsSource = machinelist;
            }
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
            DirectorWindow directorWindow = new DirectorWindow();
            directorWindow.Show();
            Close();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            MachineRedactAddWindow.IsRedacting = false;
            MachineRedactAddWindow machineRedactAddWindow = new MachineRedactAddWindow();
            machineRedactAddWindow.Show();
            Close();
        }

        private void Redact_button_Click(object sender, RoutedEventArgs e)
        {
            if (MachineGrid.SelectedItem != null)
            {
                MachineRedactAddWindow.IsRedacting = true;
                MachineRedactAddWindow.redactingMachine = currentMachine;
                MachineRedactAddWindow machineRedactAddWindow = new MachineRedactAddWindow();
                machineRedactAddWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Оборудование не выбрано");
            }
        }

        private void MachineGrid_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            Machine item = new Machine();
            foreach (var obj in MachineGrid.SelectedItems)
            {
                item = obj as Machine;
                currentMachine = item;
            }
        }

        public void GetCharacteristics()
        {
            string cmdString = "GetCharacteristics";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = currentMachine.ID
                };
                cmd.Parameters.Add(Param);

                con.Open();

                string chars = string.Empty;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chars += reader[1].ToString() + ": " + reader[2].ToString() + "\n";
                }
                reader.Close();

                con.Close();

                MessageBox.Show(chars);
            }
        }

        private void Add_char_button_Click(object sender, RoutedEventArgs e)
        {
            if (MachineGrid.SelectedItem != null)
            {
                CharRedactAddWindow.redactingMachine = currentMachine;
                CharRedactAddWindow charRedactAddWindow = new CharRedactAddWindow();
                charRedactAddWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Оборудование не выбрано");
            }
        }

        private void Show_char_button_Click(object sender, RoutedEventArgs e)
        {
            if (MachineGrid.SelectedItem != null)
            {
                GetCharacteristics();
            }
            else
            {
                MessageBox.Show("Оборудование не выбрано");
            }
        }
    }
}
