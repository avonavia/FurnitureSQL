using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FurnitureSQL
{
    public partial class MaterialsListWindow : Window
    {
        public static string conString { get; set; }
        public static User currentUser { get; set; }
        public static Material currentMaterial { get; set; }
        public MaterialsListWindow()
        {
            InitializeComponent();
            CheckRole();
            GetQualityList();
            GetMaterialList();
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

        List<Material> materiallist = new List<Material>();
        List<Material> sortedlist = new List<Material>();
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

        public void GetMaterialList()
        {
            MaterialGrid.ItemsSource = null;
            materiallist.Clear();
            string cmdString = "GetMaterialList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material st = new Material();
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
                    materiallist.Add(st);
                }
                reader.Close();

                con.Close();

                MaterialGrid.ItemsSource = materiallist;
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

        private void MaterialGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Material item = new Material();
            foreach (var obj in MaterialGrid.SelectedItems)
            {
                item = obj as Material;
                currentMaterial = item;
            }
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            MaterialRedactAddWindow.IsRedacting = false;
            MaterialRedactAddWindow materialRedactAddWindow = new MaterialRedactAddWindow();
            materialRedactAddWindow.Show();
            Close();
        }

        private void Redact_button_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialGrid.SelectedItem != null)
            {
                MaterialRedactAddWindow.IsRedacting = true;
                MaterialRedactAddWindow.redactingMaterial = currentMaterial;
                MaterialRedactAddWindow materialRedactAddWindow = new MaterialRedactAddWindow();
                materialRedactAddWindow.Show();
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
            foreach (var item in materiallist)
            {
                if (item.Quality == QualityBox.SelectedItem.ToString())
                {
                    sortedlist.Add(item);
                }
            }
            MaterialGrid.ItemsSource = null;
            MaterialGrid.ItemsSource = sortedlist;
        }
        private void QualityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
    }
}
