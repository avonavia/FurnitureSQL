using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace FurnitureSQL
{
    public partial class WorkshopElementsWindow : Window
    {
        public static string conString { get; set; }
        private Point? _p;
        public static int workshopID { get; set; }
        private Image movingImage { get; set; }

        private string FEX { get; set; }
        private string FEY { get; set; }
        private string MedkitX { get; set; }
        private string MedkitY { get; set; }
        private string ExitX { get; set; }
        private string ExitY { get; set; }
        public WorkshopElementsWindow()
        {
            InitializeComponent();
            GetWorkshops();
        }

        public void SetCoordinates()
        {
            FE.SetValue(Canvas.LeftProperty, Convert.ToDouble(FEX));
            FE.SetValue(Canvas.TopProperty, Convert.ToDouble(FEY));

            Medkit.SetValue(Canvas.LeftProperty, Convert.ToDouble(MedkitX));
            Medkit.SetValue(Canvas.TopProperty, Convert.ToDouble(MedkitY));

            Exit.SetValue(Canvas.LeftProperty, Convert.ToDouble(ExitX));
            Exit.SetValue(Canvas.TopProperty, Convert.ToDouble(ExitY));
        }

        public void GetCoordinates()
        {
            string cmdString = "GetCoordinates";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = workshopID
                };
                cmd.Parameters.Add(Param);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FEX = reader[0].ToString();
                    FEY = reader[1].ToString();
                    ExitX = reader[2].ToString();
                    ExitY = reader[3].ToString();
                    MedkitX = reader[4].ToString();
                    MedkitY = reader[5].ToString();
                }
                reader.Close();

                con.Close();
            }
        }

        public void GetNewCoordinates()
        {
            FEX = FE.GetValue(Canvas.LeftProperty).ToString();
            FEY = FE.GetValue(Canvas.TopProperty).ToString();
            MedkitX = Medkit.GetValue(Canvas.LeftProperty).ToString();
            MedkitY = Medkit.GetValue(Canvas.TopProperty).ToString();
            ExitX = Exit.GetValue(Canvas.LeftProperty).ToString();
            ExitY = Exit.GetValue(Canvas.TopProperty).ToString();
        }
        public void InsertCoordinates()
        {
            string cmdString = "InsertCoordinates";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = workshopID
                };
                cmd.Parameters.Add(Param);

                SqlParameter Param1 = new SqlParameter
                {
                    ParameterName = "@ox",
                    Value = Convert.ToDouble(FEX)
                };
                cmd.Parameters.Add(Param1);

                SqlParameter Param2 = new SqlParameter
                {
                    ParameterName = "@oy",
                    Value = Convert.ToDouble(FEY)
                };
                cmd.Parameters.Add(Param2);

                SqlParameter Param3 = new SqlParameter
                {
                    ParameterName = "@dx",
                    Value = Convert.ToDouble(ExitX)
                };
                cmd.Parameters.Add(Param3);

                SqlParameter Param4 = new SqlParameter
                {
                    ParameterName = "@dy",
                    Value = Convert.ToDouble(ExitY)
                };
                cmd.Parameters.Add(Param4);

                SqlParameter Param5 = new SqlParameter
                {
                    ParameterName = "@ax",
                    Value = Convert.ToDouble(MedkitX)
                };
                cmd.Parameters.Add(Param5);

                SqlParameter Param6 = new SqlParameter
                {
                    ParameterName = "@ay",
                    Value = Convert.ToDouble(MedkitY)
                };
                cmd.Parameters.Add(Param6);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void Scheme_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (movingImage != null)
            {
                _p = e.GetPosition(movingImage);
                movingImage.CaptureMouse();
            }
        }

        private void Scheme_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (movingImage != null)
            {
                if (_p == null)
                    return;
                var p = e.GetPosition(this) - (Vector)_p.Value;
                Canvas.SetLeft(movingImage, p.X);
                Canvas.SetTop(movingImage, p.Y);
            }
        }

        private void Scheme_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (movingImage != null)
            {
                _p = null;
                movingImage.ReleaseMouseCapture();
            }
        }

        private void FE_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            movingImage = FE;
        }

        private void Medkit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            movingImage = Medkit;
        }

        private void Exit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            movingImage = Exit;
        }
        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            if (SchemeBox.SelectedItem != null)
            {
                GetNewCoordinates();
                InsertCoordinates();
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("Схема не выбрана");
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            DirectorWindow directorWindow = new DirectorWindow();
            directorWindow.Show();
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

        List<int> workshoplist = new List<int>();

        public void GetWorkshops()
        {
            SchemeBox.ItemsSource = null;
            workshoplist.Clear();
            string cmdString = "GetWorkshops";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    workshoplist.Add((int)reader[0]);
                }
                reader.Close();

                con.Close();

                SchemeBox.ItemsSource = workshoplist;
            }
        }

        private void SchemeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            workshopID = (int)SchemeBox.SelectedItem;
            SchemeImage.ImageSource = ImageWorker.ShowImage(conString, "CPlanPic", "Workshops", "ID", workshopID.ToString());
            GetCoordinates();
            SetCoordinates();
        }
    }
}
