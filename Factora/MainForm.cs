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
            dataGridViewItems.EndEdit();
            dataGridViewItems.CurrentCell = null;

            var actualItems = new List<InvoiceItem>();
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.DataBoundItem is InvoiceItem boundItem)
                {
                    actualItems.Add(boundItem);
                }
                else
                {
                    string description = row.Cells["colDescription"].Value?.ToString() ?? "";
                    string measure = row.Cells["colMeasure"].Value?.ToString() ?? "бр.";

                    string qtyStr = (row.Cells["colQuantity"].Value?.ToString() ?? "0").Replace(".", ",");
                    string priceStr = (row.Cells["colUnitPrice"].Value?.ToString() ?? "0").Replace(".", ",");
                    string discountStr = (row.Cells["colDiscount"].Value?.ToString() ?? "0").Replace(".", ",");

                    decimal.TryParse(qtyStr, out decimal qty);
                    decimal.TryParse(priceStr, out decimal price);
                    decimal.TryParse(discountStr, out decimal discount);

                    if (!string.IsNullOrWhiteSpace(description) || qty > 0 || price > 0)
                    {
                        actualItems.Add(new InvoiceItem
                        {
                            Description = description.Trim(),
                            Measure = string.IsNullOrWhiteSpace(measure) ? "бр." : measure.Trim(),
                            Quantity = qty,
                            UnitPrice = price,
                            Discount = discount
                        });
                    }
                }
            }


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
                Items = actualItems
            };

            _db.SaveInvoice(invoice);
            _db.SaveOrUpdateClient(invoice);
            LoadClientsDropdown();

            txtInvoiceNumber.Text = _db.GetNextInvoiceNumber();

            _items.Clear();
            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = _items; 

            Directory.CreateDirectory("Invoices");
            string OriginalFilePath = Path.Combine("Invoices", $"Invoice_{invoice.InvoiceNumber}_Original.pdf");
            string CopyFilePath = Path.Combine("Invoices", $"Invoice_{invoice.InvoiceNumber}_Copy.pdf");

            var originalDocument = new InvoiceDocument(invoice);
            originalDocument.GeneratePdf(OriginalFilePath);
            var copyDocument = new InvoiceDocument(invoice, "КОПИЕ");
            copyDocument.GeneratePdf(CopyFilePath);

            Process.Start(new ProcessStartInfo(OriginalFilePath) { UseShellExecute = true });
        }
    }
}
