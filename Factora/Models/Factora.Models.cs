using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factora.Models
{
    public class InvoiceItem
    {
        public string Description { get; set; } = string.Empty;
        public string Measure { get; set; } = "бр.";
        public decimal Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; } // в проценти (%)

        // Стойност = (Количество * Цена) - Отстъпка
        public decimal Total => (Quantity * UnitPrice) * (1 - (Discount / 100m));
    }
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = "0000000001";
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public string PlaceOfIssue { get; set; } = "с. Овощник";

        // Полета за ПОЛУЧАТЕЛ (според бланката)
        public string ClientName { get; set; } = string.Empty;
        public string ClientCity { get; set; } = string.Empty;
        public string ClientAddress { get; set; } = string.Empty;
        public string ClientMol { get; set; } = string.Empty;
        public string ClientVatId { get; set; } = string.Empty;     // Ид. № по ЗДДС
        public string ClientEikEgn { get; set; } = string.Empty;    // ЕИК/ЕГН
        public string ClientVatNumber { get; set; } = string.Empty; // ДДС/VAT/№

        // Ставка ДДС и артикули
        public decimal VatRate { get; set; } = 20m;
        public List<InvoiceItem> Items { get; set; } = new();

        // Автоматични изчисления
        public decimal SubTotal => Items.Sum(i => i.Total);
        public decimal VatAmount => SubTotal * (VatRate / 100m);
        public decimal GrandTotal => SubTotal + VatAmount;
    }
}
