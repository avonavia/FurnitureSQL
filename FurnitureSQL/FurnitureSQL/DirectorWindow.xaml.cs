﻿using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace FurnitureSQL
{
    public partial class DirectorWindow : Window
    {
        public static string conString { get; set; }
        public static User currentUser { get; set; }
        public DirectorWindow()
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

        private void Workshop_button_Click(object sender, RoutedEventArgs e)
        {
            WorkshopElementsWindow workshopElementsWindow = new WorkshopElementsWindow();
            workshopElementsWindow.Show();
            Close();
        }

        private void Machines_button_Click(object sender, RoutedEventArgs e)
        {
            MachineListWindow machineListWindow = new MachineListWindow();
            machineListWindow.Show();
            Close();
        }

        private void Materials_button_Click(object sender, RoutedEventArgs e)
        {
            MaterialsListWindow.currentUser = currentUser;
            MaterialsListWindow materialsListWindow = new MaterialsListWindow();
            materialsListWindow.Show();
            Close();
        }

        private void Furniture_button_Click(object sender, RoutedEventArgs e)
        {
            FurnitureListWindow.currentUser = currentUser;
            FurnitureListWindow furnitureListWindow = new FurnitureListWindow();
            furnitureListWindow.Show();
            Close();
        }
    }
}
