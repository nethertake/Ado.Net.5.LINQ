using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data.SqlClient;
using System.Data;
namespace Module05LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db = new Model1();
        private string _connectionString = "Data Source =192.168.111.107; Initial Catalog = CRCMS_new; User ID = sa; Password = Mc123456";
        public MainWindow()
        {
            InitializeComponent();

            string[] names = { "Natalia ", "Evgen ", "An ", "Timur " };

            names.First();


            //1 variant Лямбда запрос
            var filterNames1 = names.Where(n => n.Length >= 4).OrderBy(o=>o);


            //2 variant

            IEnumerable<string> filterNames2 = Enumerable.Where(names, n => n.Length >= 4);

            //3 variant Запрос облегченного восприятия

            IEnumerable<string> filterNames3 = from n in names where n.Length >= 4 select n;



            //цепочка запросов

            var qu4 = names.Take(10).Skip(2).Reverse();
            

            //1 element

            var qu5 = names.First();
            var qu7 = names.Last();
            var qu6 = names.ElementAt(2);

            //агрегирование NUMbER

            var qu8 = names.Count();
            var qu9 = names.Min(m => m.Length);


            //квантификаторы TRUE/FALSE

            var qu8_1 = names.Any(a=> a.Length<=2);
            var qu8_2 = names.Contains("e");


            //foreach (string filterName in filterNames1)
            //{
            //    TextBlock1.Text += filterName + "\n";
            //} 
        
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from dic_Model", con);
            DataSet ds = new DataSet();
            da.TableMappings.Add("Table", "dic_Model");
            da.Fill(ds);

            IEnumerable<DataRow> model = ds.Tables["dic_Model"].AsEnumerable();
            
        }

        private void GetDocuments_Click(object sender, RoutedEventArgs e)
        {
            DocumentListView.ItemsSource =
            (from doc in db.Document
             where doc.SmcsCode == "1000"
             group doc by doc.CustomerId).ToList();
        }
    }
}
