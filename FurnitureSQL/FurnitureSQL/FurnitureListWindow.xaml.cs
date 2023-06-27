using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FurnitureSQL
{
    public partial class FurnitureListWindow : Window
    {
        public static string conString { get; set; }
        public static User currentUser { get; set; }
        public static Furniture currentFurniture { get; set; }
        public FurnitureListWindow()
        {
            InitializeComponent();
            CheckRole();
            GetQualityList();
            GetFurnitureList();
        }

        public void CheckRole()
        {
            if (currentUser.RoleID == 2 || currentUser.RoleID == 4)
            {
                Redact_button.Visibility = Visibility.Hidden;
                Add_button.Visibility = Visibility.Hidden;
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser.RoleID == 2)
            {
                MasterWindow masterWindow = new MasterWindow();
                masterWindow.Show();
                Close();
            }
            if (currentUser.RoleID == 3)
            {
                DirectorWindow directorWindow = new DirectorWindow();
                directorWindow.Show();
                Close();
            }
            if (currentUser.RoleID == 4)
            {
                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                Close();
            }
            if (currentUser.RoleID == 5)
            {
                DeputyDirectorWindow deputyDirectorWindow = new DeputyDirectorWindow();
                deputyDirectorWindow.Show();
                Close();
            }
        }

        List<Furniture> furniturelist = new List<Furniture>();
        List<Furniture> sortedlist = new List<Furniture>();
        List<string> qualitylist = new List<string>();

        public void GetQualityList()
        {
            QualityBox.ItemsSource = null;
            qualitylist.Clear();
            string cmdString = "GetQualityList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qualitylist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();

                QualityBox.ItemsSource = qualitylist;
            }
        }

        public void GetFurnitureList()
        {
            FurnitureGrid.ItemsSource = null;
            furniturelist.Clear();
            string cmdString = "GetFurnitureList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Furniture st = new Furniture();
                    st.ID = (int)reader[0];
                    st.Number = reader[1].ToString();
                    st.Name = reader[2].ToString();
                    st.Measure = reader[3].ToString();
                    st.Length = reader[4].ToString();
                    st.Type = reader[5].ToString();
                    st.Cost = reader[6].ToString();
                    st.Criteria = reader[7].ToString();
                    st.Quan = reader[8].ToString();
                    st.Supplier = reader[9].ToString();
                    st.DeliverTime = reader[10].ToString();
                    st.Quality = reader[11].ToString();
                    st.Status = (int)reader[12];
                    furniturelist.Add(st);
                }
                reader.Close();

                con.Close();

                FurnitureGrid.ItemsSource = furniturelist;
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

        private void FurnitureGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Furniture item = new Furniture();
            foreach (var obj in FurnitureGrid.SelectedItems)
            {
                item = obj as Furniture;
                currentFurniture = item;
            }
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            FurnitureRedactAddWindow.IsRedacting = false;
            FurnitureRedactAddWindow furnitureRedactAddWindow = new FurnitureRedactAddWindow();
            furnitureRedactAddWindow.Show();
            Close();
        }

        private void Redact_button_Click(object sender, RoutedEventArgs e)
        {
            if (FurnitureGrid.SelectedItem != null)
            {
                FurnitureRedactAddWindow.IsRedacting = true;
                FurnitureRedactAddWindow.redactingFurniture = currentFurniture;
                FurnitureRedactAddWindow furnitureRedactAddWindow = new FurnitureRedactAddWindow();
                furnitureRedactAddWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Материал не выбран");
            }
        }
        public void Sort()
        {
            sortedlist.Clear();
            foreach (var item in furniturelist)
            {
                if (item.Quality == QualityBox.SelectedItem.ToString())
                {
                    sortedlist.Add(item);
                }
            }
            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = sortedlist;
        }
        private void QualityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
    }
}
