using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex1_JennyAndYael.View.Controls
{
    /// <summary>
    /// Interaction logic for DataTable.xaml
    /// </summary>
    public partial class DataTable : UserControl
    {
        public DataTable()
        {
            InitializeComponent();
        }
        public void fillingData()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            //configuring the headers data columns
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn value = new DataColumn("value", typeof(double));
            //adding columns to table
            dt.Columns.Add(name);
            dt.Columns.Add(value);

            //first row - indicated-heading-deg
            DataRow firstRow = dt.NewRow();
            firstRow[0] = "heading";
            firstRow[1] = 0.0;
            //second row - gps_indicated-vertical-speed
            DataRow secondRow = dt.NewRow();
            secondRow[0] = "vertical-speed";
            secondRow[1] = 0.0;
            //third row - gps_indicated-ground-speed-kt
            DataRow thirdRow = dt.NewRow();
            thirdRow[0] = "ground-speed";
            thirdRow[1] = 0.0;
            //fourth row - airspeed-indicator_indicated-speed-kt
            DataRow fourthRow = dt.NewRow();
            fourthRow[0] = "airspeed";
            fourthRow[1] = 0.0;
            //fifth row - gps_indicated-altitude-ft
            DataRow fifthRow = dt.NewRow();
            fifthRow[0] = "gps-altitude";
            fifthRow[1] = 0.0;
            //sixth row - attitude-indicator_internal-roll-deg
            DataRow sixthRow = dt.NewRow();
            sixthRow[0] = "attitude-roll";
            sixthRow[1] = 0.0;
            //seventh row - attitude-indicator_internal-pitch-deg
            DataRow seventhRow = dt.NewRow();
            seventhRow[0] = "attitude-pitch";
            seventhRow[1] = 0.0;
            //eighth row - altimeter_indicated-altitude-ft
            DataRow eighthRow = dt.NewRow();
            eighthRow[0] = "altimeter-altitude";
            eighthRow[1] = 0.0;
            //adding rows to the table
            dt.Rows.Add(firstRow);
            dt.Rows.Add(secondRow);
            dt.Rows.Add(thirdRow);
            dt.Rows.Add(fourthRow);
            dt.Rows.Add(fifthRow);
            dt.Rows.Add(sixthRow);
            dt.Rows.Add(seventhRow);
            dt.Rows.Add(eighthRow);

            simulatorData.ItemsSource = dt.DefaultView;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingData();
        }
    }
}
