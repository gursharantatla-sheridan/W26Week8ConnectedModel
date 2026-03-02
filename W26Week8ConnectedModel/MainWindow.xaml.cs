using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace W26Week8ConnectedModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // read the conn str
        string connStr = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(connStr);

            string query = "select EmployeeID, FirstName, LastName, City, Country from Employees";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader);
            grdEmployees.ItemsSource = tbl.DefaultView;

            conn.Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}