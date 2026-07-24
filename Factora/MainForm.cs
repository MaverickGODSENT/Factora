using Factora.Data;
using Factora.Documents;
using Factora.Models;
using QuestPDF.Fluent;        
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;               
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factora
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Задължително за QuestPDF (безплатен лиценз)
            QuestPDF.Settings.License = LicenseType.Community;

            // Инициализация на базата данни
            _db.Setup();

            // Връзваме таблицата с артикулите
            dataGridViewItems.DataSource = _items;
        }

        private BindingList<InvoiceItem> _items = new();
        private Database _db = new();

        // ЕТО ГО ЛИПСВАЩИЯ КОНСТРУКТОР:


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // 1. Събираме данните от екрана
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
                VatRate = numVatRate.Value, // NumericUpDown за ДДС %
                Items = new List<InvoiceItem>(_items)
            };

            if (invoice.Items.Count == 0)
            {
                MessageBox.Show("Моля, добавете поне един артикул!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Записваме в локалната база SQLite
            _db.SaveInvoice(invoice);

            // 3. Генерираме PDF
            Directory.CreateDirectory("Invoices");
            string filePath = Path.Combine("Invoices", $"Invoice_{invoice.InvoiceNumber}.pdf");

            var document = new InvoiceDocument(invoice);
            document.GeneratePdf(filePath);

            // 4. Отваряме готовия PDF веднага
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
