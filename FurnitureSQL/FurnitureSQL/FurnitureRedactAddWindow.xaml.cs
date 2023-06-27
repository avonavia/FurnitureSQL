using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;
using System.Collections.Generic;


namespace FurnitureSQL
{
    public partial class FurnitureRedactAddWindow : Window
    {
        public static string conString { get; set; }
        public static bool IsRedacting { get; set; }
        public static Furniture redactingFurniture { get; set; }
        public FurnitureRedactAddWindow()
        {
            InitializeComponent();
            FillLists();
            StatusBox.ItemsSource = statuslist;
            InitialCheck();
        }

        public void InitialCheck()
        {
            if (IsRedacting)
            {
                number_box.Text = redactingFurniture.Number;
                name_box.Text = redactingFurniture.Name;
                MeasureBox.SelectedItem = redactingFurniture.Measure;
                length_box.Text = redactingFurniture.Length;
                TypeBox.SelectedItem = redactingFurniture.Type;
                cost_box.Text = redactingFurniture.Cost;
                criteria_box.Text = redactingFurniture.Criteria;
                quan_box.Text = redactingFurniture.Quan;
                SupplierBox.SelectedItem = redactingFurniture.Supplier;
                QualityBox.SelectedItem = redactingFurniture.Quality;
                StatusBox.SelectedItem = redactingFurniture.Status;
            }
        }

        List<string> measurelist = new List<string>();
        List<string> typelist = new List<string>();
        List<string> supplist = new List<string>();
        List<string> quallist = new List<string>();
        List<int> statuslist = new List<int>();

        public void FillLists()
        {
            statuslist.Add(0);
            statuslist.Add(1);
            GetMeasureList();
            GetFTypeList();
            GetSupplierList();
            GetQualityList();
        }

        public void GetMeasureList()
        {
            MeasureBox.ItemsSource = null;
            measurelist.Clear();
            string cmdString = "GetMeasureList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    measurelist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();
                MeasureBox.ItemsSource = measurelist;
            }
        }

        public void GetFTypeList()
        {
            TypeBox.ItemsSource = null;
            typelist.Clear();
            string cmdString = "GetFTypeList";

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

        public void AddFurniture()
        {
            string cmdString = "AddFurniture";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = number_box.Text
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
                    ParameterName = "@mID",
                    Value = furnitureInfoIDs.mID
                };
                cmd.Parameters.Add(Param2);

                SqlParameter Param3 = new SqlParameter
                {
                    ParameterName = "@length",
                    Value = Convert.ToDouble(length_box.Text)
                };
                cmd.Parameters.Add(Param3);

                SqlParameter Param4 = new SqlParameter
                {
                    ParameterName = "@quan",
                    Value = quan_box.Text
                };
                cmd.Parameters.Add(Param4);

                SqlParameter Param5 = new SqlParameter
                {
                    ParameterName = "@tID",
                    Value = furnitureInfoIDs.tID
                };
                cmd.Parameters.Add(Param5);

                SqlParameter Param6 = new SqlParameter
                {
                    ParameterName = "@cost",
                    Value = cost_box.Text
                };
                cmd.Parameters.Add(Param6);

                SqlParameter Param7 = new SqlParameter
                {
                    ParameterName = "@criteria",
                    Value = criteria_box.Text
                };
                cmd.Parameters.Add(Param7);

                SqlParameter Param8 = new SqlParameter
                {
                    ParameterName = "@sID",
                    Value = furnitureInfoIDs.sID
                };
                cmd.Parameters.Add(Param8);

                SqlParameter Param9 = new SqlParameter
                {
                    ParameterName = "@qID",
                    Value = furnitureInfoIDs.qID
                };
                cmd.Parameters.Add(Param9);

                SqlParameter Param10 = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = (int)StatusBox.SelectedItem
                };
                cmd.Parameters.Add(Param10);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void RedactFurniture()
        {
            string cmdString = "RedactFurniture";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param0 = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = redactingFurniture.ID
                };
                cmd.Parameters.Add(Param0);

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = number_box.Text
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
                    ParameterName = "@mID",
                    Value = furnitureInfoIDs.mID
                };
                cmd.Parameters.Add(Param2);

                SqlParameter Param3 = new SqlParameter
                {
                    ParameterName = "@length",
                    Value = Convert.ToDouble(length_box.Text)
                };
                cmd.Parameters.Add(Param3);

                SqlParameter Param4 = new SqlParameter
                {
                    ParameterName = "@quan",
                    Value = quan_box.Text
                };
                cmd.Parameters.Add(Param4);

                SqlParameter Param5 = new SqlParameter
                {
                    ParameterName = "@tID",
                    Value = furnitureInfoIDs.tID
                };
                cmd.Parameters.Add(Param5);

                SqlParameter Param6 = new SqlParameter
                {
                    ParameterName = "@cost",
                    Value = cost_box.Text
                };
                cmd.Parameters.Add(Param6);

                SqlParameter Param7 = new SqlParameter
                {
                    ParameterName = "@criteria",
                    Value = criteria_box.Text
                };
                cmd.Parameters.Add(Param7);

                SqlParameter Param8 = new SqlParameter
                {
                    ParameterName = "@sID",
                    Value = furnitureInfoIDs.sID
                };
                cmd.Parameters.Add(Param8);

                SqlParameter Param9 = new SqlParameter
                {
                    ParameterName = "@qID",
                    Value = furnitureInfoIDs.qID
                };
                cmd.Parameters.Add(Param9);

                SqlParameter Param10 = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = (int)StatusBox.SelectedItem
                };
                cmd.Parameters.Add(Param10);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public FurnitureInfoIDs furnitureInfoIDs = new FurnitureInfoIDs();

        public void GetFurnitureInfoIDs()
        {
            string cmdString = "GetFurnitureInfoIDs";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@mname",
                    Value = MeasureBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@tname",
                    Value = TypeBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param1);

                SqlParameter Param2 = new SqlParameter
                {
                    ParameterName = "@sname",
                    Value = SupplierBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param2);

                SqlParameter Param3 = new SqlParameter
                {
                    ParameterName = "@qname",
                    Value = QualityBox.SelectedItem.ToString()
                };
                cmd.Parameters.Add(Param3);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    furnitureInfoIDs.mID = (int)reader[0];
                    furnitureInfoIDs.tID = (int)reader[1];
                    furnitureInfoIDs.sID = (int)reader[2];
                    furnitureInfoIDs.qID = (int)reader[3];
                }
                reader.Close();

                con.Close();
            }
        }

        public void GetSupplierList()
        {
            SupplierBox.ItemsSource = null;
            supplist.Clear();
            string cmdString = "GetSupplierList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    supplist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();
                SupplierBox.ItemsSource = supplist;
            }
        }

        public void GetQualityList()
        {
            QualityBox.ItemsSource = null;
            quallist.Clear();
            string cmdString = "GetQualityList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    quallist.Add(reader[0].ToString());
                }
                reader.Close();

                con.Close();
                QualityBox.ItemsSource = quallist;
            }
        }

        public bool ValidateBoxes()
        {
            bool result = false;
            try
            {
                if (number_box.Text == "" || name_box.Text == "" || MeasureBox.SelectedItem == null || length_box.Text == "" || TypeBox.SelectedItem == null || cost_box.Text == "" || criteria_box.Text == "" || quan_box.Text == "" || SupplierBox.SelectedItem == null || QualityBox.SelectedItem == null || StatusBox.SelectedItem == null)
                {
                    throw new Exception("Не все поля заполнены");
                }
                if (number_box.Text.Length > 255 || name_box.Text.Length > 255 || length_box.Text.Length > 255 ||cost_box.Text.Length > 255 || criteria_box.Text.Length > 255 || quan_box.Text.Length > 255)
                {
                    throw new Exception("Превышено количество символов");
                }
                if (!float.TryParse(length_box.Text, out float r) || length_box.Text.Contains("."))
                {
                    throw new Exception("Неверный формат длины (возможно, вы поставили '.' вместо ',')");
                }
                if (!float.TryParse(cost_box.Text, out float rr) || cost_box.Text.Contains("."))
                {
                    throw new Exception("Неверный формат цены (возможно, вы поставили '.' вместо ',')");
                }
                if (!criteria_box.Text.Contains("ГОСТ"))
                {
                    throw new Exception("В названии ГОСТ'а должно использоваться 'ГОСТ'");
                }
                if (!int.TryParse(quan_box.Text, out int rrr))
                {
                    throw new Exception("Неверный формат количества");
                }
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            FurnitureListWindow furnitureListWindow = new FurnitureListWindow();
            furnitureListWindow.Show();
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
                GetFurnitureInfoIDs();
                if (!IsRedacting)
                {
                    AddFurniture();
                }
                else
                {
                    RedactFurniture();
                }
                MessageBox.Show("Успешно");
                FurnitureListWindow furnitureListWindow = new FurnitureListWindow();
                furnitureListWindow.Show();
                Close();
            }
        }
    }
}
