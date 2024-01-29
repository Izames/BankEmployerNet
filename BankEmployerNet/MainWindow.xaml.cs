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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.IO;

namespace BankEmployerNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientTableAdapter adapter = new ClientTableAdapter();
        BankAccountTableAdapter accountAdapter = new BankAccountTableAdapter();
        DebitCardTableAdapter debitCardAdapter = new DebitCardTableAdapter();
        FinanceOperationsTableAdapter financeOperationsAdapter = new FinanceOperationsTableAdapter();
        InvestPortfolioTableAdapter investPortfolioTableAdapter = new InvestPortfolioTableAdapter();
        CreditDataTableAdapter creditDataTableAdapter = new CreditDataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            BankAccounts.ItemsSource = accountAdapter.GetData();
            Cards.ItemsSource = debitCardAdapter.GetData();
            Finances.ItemsSource = financeOperationsAdapter.GetData();
            Portfolios.ItemsSource = investPortfolioTableAdapter.GetData();
            Credits.ItemsSource = creditDataTableAdapter.GetData();
        }

        private void AcceptSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach(DataRow row in adapter.GetData())
            {
                if (row["id_client"].ToString() == Search.Text)
                {
                    Surname.Text = row["UserSurname"].ToString();
                    name.Text = row["UserName"].ToString();
                    Thirdname.Text = row["UserPatronymic"].ToString();
                    Passport.Text = row["PassportData"].ToString();
                    BirthDate.Text = row["DateOfBirth"].ToString();
                }
            }
        }

        private void Applications_Click(object sender, RoutedEventArgs e)
        {
            ApplicationsWindow applicationsWindow = new ApplicationsWindow();
            applicationsWindow.Show();
        }
        private void ExportToTxt(DataGrid dataGrid, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Получаем заголовки столбцов
            foreach (DataGridColumn column in dataGrid.Columns)
            {
                sb.Append(column.Header);
                sb.Append("|");
            }
            sb.AppendLine();

            // Получаем данные ячеек
            foreach (object dataItem in dataGrid.Items)
            {
                if (dataItem is DataRowView rowView)
                {
                    foreach (object cellValue in rowView.Row.ItemArray)
                    {
                        sb.Append(cellValue.ToString());
                        sb.Append("|");
                    }
                    sb.AppendLine();
                }
            }

            // Записываем строку в файл
            File.WriteAllText(filePath, sb.ToString());
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            ExportToTxt(Finances, "C:\\Users\\geday\\OneDrive\\Рабочий стол\\нужные правки.txt");
        }
    }
}
