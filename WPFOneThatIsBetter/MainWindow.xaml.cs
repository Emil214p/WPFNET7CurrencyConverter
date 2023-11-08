using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPFOneThatIsBetter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearControls();
            BindCurrency();
        }

        public void ReadXML()
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load("https://www.nationalbanken.dk/api/currencyratesxml?lang=da");

            //XmlNodeList codeNodes = doc.SelectNodes("//currency/@code");
            //XmlNodeList rateNodes = doc.SelectNodes("//currency/@rate");

            //string[] codes = new string[codeNodes.Count];
            //double[] rates = new double[rateNodes.Count];

            //for (int i = 0; i < codeNodes.Count; i++)
            //{
            //    codes[i] = codeNodes[i].Value;
            //    rates[i] = double.Parse(rateNodes[i].Value);
            //}

            // Now you have the codes and rates in arrays. You can print them out to verify.
            //for (int i = 0; i < codes.Length; i++)
            //{
            //    Console.WriteLine("Code: " + codes[i] + ", Rate: " + rates[i]);
            //}
        }
        private void BindCurrency()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("https://www.nationalbanken.dk/api/currencyratesxml?lang=da");

            XmlNodeList codeNodes = doc.SelectNodes("//currency/@code");
            XmlNodeList rateNodes = doc.SelectNodes("//currency/@rate");

            string[] codes = new string[codeNodes.Count];
            double[] rates = new double[rateNodes.Count];

            for (int i = 0; i < codeNodes.Count; i++)
            {
                codes[i] = codeNodes[i].Value;
                rates[i] = double.Parse(rateNodes[i].Value);
            }

            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");

            dtCurrency.Rows.Add("SELECT", "SELECT");
            dtCurrency.Rows.Add(codes[0], rates[0]);
            dtCurrency.Rows.Add(codes[1], rates[1]);
            dtCurrency.Rows.Add(codes[2], rates[2]);
            dtCurrency.Rows.Add(codes[3], rates[3]);
            dtCurrency.Rows.Add(codes[4], rates[4]);
            dtCurrency.Rows.Add(codes[5], rates[5]);
            dtCurrency.Rows.Add(codes[6], rates[6]);
            dtCurrency.Rows.Add(codes[7], rates[7]);
            dtCurrency.Rows.Add(codes[8], rates[8]);
            dtCurrency.Rows.Add(codes[9], rates[9]);
            dtCurrency.Rows.Add(codes[10], rates[10]);
            dtCurrency.Rows.Add(codes[11], rates[11]);
            dtCurrency.Rows.Add(codes[12], rates[12]);
            dtCurrency.Rows.Add(codes[13], rates[13]);
            dtCurrency.Rows.Add(codes[14], rates[14]);
            dtCurrency.Rows.Add(codes[15], rates[15]);
            dtCurrency.Rows.Add(codes[16], rates[16]);
            dtCurrency.Rows.Add(codes[17], rates[17]);
            dtCurrency.Rows.Add(codes[18], rates[18]);
            dtCurrency.Rows.Add(codes[19], rates[19]);
            dtCurrency.Rows.Add(codes[20], rates[20]);
            dtCurrency.Rows.Add(codes[21], rates[21]);
            dtCurrency.Rows.Add(codes[22], rates[22]);
            dtCurrency.Rows.Add(codes[23], rates[23]);
            dtCurrency.Rows.Add(codes[24], rates[24]);
            dtCurrency.Rows.Add(codes[25], rates[25]);
            dtCurrency.Rows.Add(codes[26], rates[26]);
            dtCurrency.Rows.Add(codes[27], rates[27]);
            dtCurrency.Rows.Add(codes[28], rates[28]);
            dtCurrency.Rows.Add(codes[29], rates[29]);
            dtCurrency.Rows.Add(codes[30], rates[30]);
            dtCurrency.Rows.Add(codes[31], rates[31]);

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }
        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbFromCurrency.Focus();
                return;
            }
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbToCurrency.Focus();
                return;
            }
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                ConvertedValue = double.Parse(txtCurrency.Text);
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }
    }
}