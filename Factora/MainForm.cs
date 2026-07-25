using Factora.Data;
using Factora.Documents;
using Factora.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.ComponentModel;
using System.Diagnostics;

namespace Factora
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;

            _db.Setup();

            txtInvoiceNumber.Text = _db.GetNextInvoiceNumber();
  

         
            LoadClientsDropdown();
            cmbClients.SelectedIndexChanged += CmbClients_SelectedIndexChanged;

      
        }

        private BindingList<InvoiceItem> _items = new();
        private Database _db = new();

        private void LoadClientsDropdown()
        {
            var clients = _db.GetAllClients();
            cmbClients.DataSource = null;
            cmbClients.DataSource = clients;
            cmbClients.DisplayMember = "ClientName"; 
            cmbClients.SelectedIndex = -1;           
        }

        private void CmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClients.SelectedItem is Invoice client)
            {
                txtClientName.Text = client.ClientName;
                txtClientCity.Text = client.ClientCity;
                txtClientAddress.Text = client.ClientAddress;
                txtClientMol.Text = client.ClientMol;
                txtClientVatId.Text = client.ClientVatId;
                txtClientEik.Text = client.ClientEikEgn;
                txtClientVatNum.Text = client.ClientVatNumber;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = txtInvoiceNumber.Text,
                IssueDate = dtpIssueDate.Value,
                ClientName = txtClientName.Text,
                ClientCity = txtClientCity.Text,
                ClientAddress = txtClientAddress.Text,
                ClientMol = txtClientMol.Text,
                ClientVatId = txtClientVatId.Text,
                ClientEikEgn = txtClientEik.Text,
                ClientVatNumber = txtClientVatNum.Text,
                VatRate = numVatRate.Value,
                Items = new List<InvoiceItem>(_items)
            };


            _db.SaveInvoice(invoice);

            _db.SaveOrUpdateClient(invoice); 
            LoadClientsDropdown();

            txtInvoiceNumber.Text = _db.GetNextInvoiceNumber();
            _items.Clear();

            Directory.CreateDirectory("Invoices");
            string filePath = Path.Combine("Invoices", $"Invoice_{invoice.InvoiceNumber}.pdf");

            var document = new InvoiceDocument(invoice);
            document.GeneratePdf(filePath);

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }


    }
}
