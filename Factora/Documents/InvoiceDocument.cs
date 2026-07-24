using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Factora.Models;
using Factora.Helpers;

namespace Factora.Documents
{
    public class InvoiceDocument : IDocument
    {
        private readonly Invoice _model;

        public InvoiceDocument(Invoice model)
        {
            _model = model;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                // ЛЯВ БЛОК: ПОЛУЧАТЕЛ (Динамичен)
                row.RelativeItem().Border(1).Padding(6).Column(col =>
                {
                    col.Item().Text("ПОЛУЧАТЕЛ:").Bold().FontSize(11);
                    col.Item().PaddingBottom(4).Text(_model.ClientName).Bold().FontSize(11);

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(c => { c.ConstantColumn(90); c.RelativeColumn(); });
                        void AddRow(string lbl, string val)
                        {
                            table.Cell().Text(lbl).FontColor(Colors.Grey.Darken2);
                            table.Cell().Text(val).Bold();
                        }
                        AddRow("Гр./с.:", _model.ClientCity);
                        AddRow("Адрес:", _model.ClientAddress);
                        AddRow("МОЛ:", _model.ClientMol);
                        AddRow("Ид. № по ЗДДС:", string.IsNullOrWhiteSpace(_model.ClientVatId) ? "-" : _model.ClientVatId);
                        AddRow("ЕИК/ЕГН:", _model.ClientEikEgn);
                        AddRow("ДДС/VAT/№:", string.IsNullOrWhiteSpace(_model.ClientVatNumber) ? "-" : _model.ClientVatNumber);
                    });
                });

                // ДЯСЕН БЛОК: ДОСТАВЧИК (Статичен - МЕТАЛ-ХАРТ ЕООД)
                row.RelativeItem().Border(1).Padding(6).Column(col =>
                {
                    col.Item().AlignCenter().Text("ФАКТУРА / INVOICE").FontSize(14).Bold();
                    col.Item().AlignCenter().Text($"№ {_model.InvoiceNumber}").FontSize(12).Bold();
                    col.Item().AlignCenter().Text($"Дата: {_model.IssueDate:dd.MM.yyyy} г.");
                    col.Item().AlignCenter().PaddingBottom(4).Text($"Място: {_model.PlaceOfIssue}");

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    col.Item().PaddingTop(4).Text("ДОСТАВЧИК:").Bold();
                    col.Item().Text("„МЕТАЛ-ХАРТ“ ЕООД").Bold();
                    col.Item().Text("с. Овощник, ул. \"Родопи\" №7");
                    col.Item().Text("МОЛ: Чавдар Войводов");
                    col.Item().Text("ЕИК: 123694428 | ИН по ДДС: BG 123694428");
                    col.Item().Text("IBAN: BG68 PRCB 9230 1023 0016 19").Bold();
                    col.Item().Text("BIC: PRCBBGSF (ПроКредит Банк)");
                });
            });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);  // №
                    columns.RelativeColumn(4);   // Наименование
                    columns.RelativeColumn(1);   // Мярка
                    columns.RelativeColumn(1);   // Кол.
                    columns.RelativeColumn(1.2f);// Ед. цена
                    columns.RelativeColumn(1);   // Отстъпка
                    columns.RelativeColumn(1.5f);// Стойност
                });

                table.Header(header =>
                {
                    void Style(IContainer c, string t) => c.Border(1).Background(Colors.Grey.Lighten3).Padding(3).AlignCenter().Text(t).Bold();
                    Style(header.Cell(), "№");
                    Style(header.Cell(), "НАИМЕНОВАНИЕ НА СТОКИТЕ / УСЛУГИТЕ");
                    Style(header.Cell(), "Мярка");
                    Style(header.Cell(), "Кол.");
                    Style(header.Cell(), "Ед. цена");
                    Style(header.Cell(), "Отст. %");
                    Style(header.Cell(), "Стойност");
                });

                // АКО ИМА ВЪВЕДЕНИ АРТИКУЛИ -> Ги печатаме
                if (_model.Items.Count > 0)
                {
                    int index = 1;
                    foreach (var item in _model.Items)
                    {
                        table.Cell().Border(1).Padding(3).AlignCenter().Text(index++.ToString());
                        table.Cell().Border(1).Padding(3).Text(item.Description);
                        table.Cell().Border(1).Padding(3).AlignCenter().Text(item.Measure);
                        table.Cell().Border(1).Padding(3).AlignRight().Text($"{item.Quantity:0.##}");
                        table.Cell().Border(1).Padding(3).AlignRight().Text($"{item.UnitPrice:0.00}");
                        table.Cell().Border(1).Padding(3).AlignCenter().Text(item.Discount > 0 ? $"{item.Discount}%" : "");
                        table.Cell().Border(1).Padding(3).AlignRight().Text($"{item.Total:0.00}");
                    }
                }
                else
                {
                    // АКО НЯМА АРТИКУЛИ -> Чертаем 10 празни реда за писане с химикал!
                    for (int i = 1; i <= 10; i++)
                    {
                        // MinHeight(24) дава достатъчно място по височина за писане на ръка
                        table.Cell().Border(1).MinHeight(24).Padding(3).AlignCenter().Text(i.ToString()).FontColor(Colors.Grey.Medium);
                        table.Cell().Border(1).MinHeight(24).Text("");
                        table.Cell().Border(1).MinHeight(24).Text("");
                        table.Cell().Border(1).MinHeight(24).Text("");
                        table.Cell().Border(1).MinHeight(24).Text("");
                        table.Cell().Border(1).MinHeight(24).Text("");
                        table.Cell().Border(1).MinHeight(24).Text("");
                    }
                }
            });
        }

        private void ComposeFooter(IContainer container)
        {
            bool isManual = _model.Items.Count == 0; // Проверяваме дали е бланка за химикал

            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    // Ляво: Словом (Ако е на ръка, оставяме точки за писане)
                    row.RelativeItem().PaddingRight(10).Column(left =>
                    {
                        left.Item().Border(1).Padding(5).Text(t =>
                        {
                            t.Span("Словом: ").Bold();
                            t.Span(isManual ? "...................................................................." : NumberToWordsBg.ToWords(_model.GrandTotal));
                        });
                    });

                    // Дясно: Тотали
                    row.ConstantItem(220).Table(table =>
                    {
                        table.ColumnsDefinition(c => { c.RelativeColumn(); c.ConstantColumn(80); });

                        table.Cell().Border(1).Padding(3).Text("Данъчна основа:").Bold();
                        table.Cell().Border(1).Padding(3).AlignRight().Text(isManual ? "........... лв." : $"{_model.SubTotal:0.00} лв.");

                        table.Cell().Border(1).Padding(3).Text($"ДДС ({_model.VatRate}%):");
                        table.Cell().Border(1).Padding(3).AlignRight().Text(isManual ? "........... лв." : $"{_model.VatAmount:0.00} лв.");

                        table.Cell().Border(1).Background(Colors.Grey.Lighten3).Padding(3).Text("СУМА ЗА ПЛАЩАНЕ:").Bold();
                        table.Cell().Border(1).Background(Colors.Grey.Lighten3).Padding(3).AlignRight().Text(isManual ? "........... лв." : $"{_model.GrandTotal:0.00} лв.").Bold();
                    });
                });

                col.Item().PaddingTop(15).Row(row =>
                {
                    row.RelativeItem().Text("Съставил: ............................................").FontSize(9);
                    row.RelativeItem().AlignRight().Text("Получател: ............................................").FontSize(9);
                });
            });
        }
    }
}
