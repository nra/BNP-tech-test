using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace PaymentManager
{
    public partial class SavePayments : Form
    {
        public SavePayments()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string portfolio = cmbPortfolios.SelectedItem.ToString();
            string filename = txtDestinationFile.Text;
            WebRequest request = WebRequest.Create("https://localhost:44344/api/Payments/" + portfolio);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responseText = reader.ReadToEnd();

            var payments = JsonConvert.DeserializeObject<List<Payment>>(responseText);

            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(payments);
            }
            lblResult.Text = string.Format("{0} saved for portfolio {1}", filename, portfolio);
        }
    }
}
