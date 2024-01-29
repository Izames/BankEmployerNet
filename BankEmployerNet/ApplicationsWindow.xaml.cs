using BankEmployerNet.BANKDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace BankEmployerNet
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsWindow.xaml
    /// </summary>
    public partial class ApplicationsWindow : Window
    {
        CreditDataTableAdapter adapter = new CreditDataTableAdapter();
        public ICommand AcceptCommand { get; set; }
        public ICommand RejectCommand { get; set; }
        
        public ApplicationsWindow()
        {
            InitializeComponent();
            foreach(DataRow dataRow in adapter.GetData())
            {
                zayavki.Items.Add(dataRow["id_client"] + " | " + dataRow["AmountCredit"]);
            }
            
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = adapter.GetData()[0];
            adapter.UpdateQuery(DateTime.Now, "принят", Convert.ToInt32(row["id_CreditData"]));
            update();
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = adapter.GetData()[0];
            adapter.UpdateQuery(DateTime.Now, "отклонен", Convert.ToInt32(row["id_CreditData"]));
            update();
        }
        private void update()
        {
            zayavki.Items.Clear();
            foreach (DataRow dataRow in adapter.GetData())
            {
                zayavki.Items.Add(dataRow["id_client"] + " | " + dataRow["AmountCredit"]);
            }
        }
    }
}
