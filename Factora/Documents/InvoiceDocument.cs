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
        private readonly string _documentType;
        public InvoiceDocument(Invoice model, string documentType = "ОРИГИНАЛ")
        {
            _model = model;
            _documentType = documentType;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(10);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Arial));

                page.Content().Column(col =>
                {
                    col.Item().Element(ComposeHeader);
                    col.Item().Element(ComposeContent);
                    col.Item().Element(ComposeFooter);
                });
            });
        }

        #region Горна част (Хедер - 3 колони: Получател | Фактура | Доставчик)
        private void ComposeHeader(IContainer container)
        {
            container.Border(1).BorderColor(Colors.Black).Row(row =>
            {
                row.RelativeItem(4.4f).BorderRight(1).Padding(5).Column(col =>
                {
                    col.Item().Row(r =>
                    {
                        r.RelativeItem().Text("ПОЛУЧАТЕЛ:").Bold().FontSize(10);
                        r.AutoItem().Text("CONSIGNEE").FontSize(7).FontColor(Colors.Grey.Darken2);
                    });

                    col.Item().PaddingTop(2).Text(_model.ClientName).Bold().FontSize(10);
                    col.Item().Text($"Гр./с.: {_model.ClientCity}");
                    col.Item().Text($"Адрес: {_model.ClientAddress}");
                    col.Item().Text($"МОЛ: {_model.ClientMol}");

                    col.Item().PaddingTop(4).Row(r =>
                    {
                        r.AutoItem().PaddingRight(4).Text("Ид. № по ЗДДС:").FontSize(8);
                        r.RelativeItem().Element(c => DrawDigitBoxes(c, _model.ClientVatId, 11));
                    });

                    col.Item().PaddingTop(3).Row(r =>
                    {
                        r.AutoItem().PaddingRight(4).Text("ЕИК/ЕГН:").FontSize(8);
                        r.RelativeItem().Element(c => DrawDigitBoxes(c, _model.ClientEikEgn, 13));
                    });

                    col.Item().PaddingTop(4).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);
                    col.Item().PaddingTop(2).Text("Данни за дистанционна продажба:").FontSize(7).FontColor(Colors.Grey.Darken1);
                    col.Item().Text($"ДДС/VAT/ №: {_model.ClientVatNumber}");

                    col.Item().PaddingTop(2).Row(r =>
                    {
                        r.RelativeItem().Text($"Ставка ДДС: {_model.VatRate}%");
                        r.RelativeItem().Text("Размер на данъка:");
                    });
                });

                row.RelativeItem(2.2f).BorderRight(1).Column(col =>
                {
                    col.Item().Padding(4).Column(c =>
                    {
                        c.Item().AlignCenter().Text("ФАКТУРА").FontSize(15).Bold();
                        c.Item().AlignCenter().Text("INVOICE").FontSize(7.5f).FontColor(Colors.Grey.Darken2);
                        c.Item().AlignCenter().Text($"({_documentType})").FontSize(7.5f).FontColor(Colors.Grey.Darken2);
                        c.Item().PaddingTop(2).AlignCenter().Text($"№ {_model.InvoiceNumber}").FontSize(11).Bold();
                        c.Item().PaddingTop(2).AlignCenter().Text($"Дата: {_model.IssueDate:dd.MM.yyyy} г.").FontSize(8);
                    });

                    col.Item().LineHorizontal(1);

                    col.Item().Padding(3).Column(c =>
                    {
                        c.Item().Text("☐ ДЕБИТНО ИЗВЕСТИЕ").FontSize(7);
                        c.Item().Text("☐ КРЕДИТНО ИЗВЕСТИЕ").FontSize(7);
                        c.Item().Text("към фактура № ............").FontSize(6.5f);
                    });

                    col.Item().LineHorizontal(1);

                    col.Item().Padding(3).Column(c =>
                    {
                        c.Item().Text("Начин на плащане:").FontSize(7.5f).Bold();
                        c.Item().Text("☐ В брой   ☐ платежно").FontSize(7);
                    });
                });

                row.RelativeItem(3.4f).Padding(5).Column(col =>
                {
                    col.Item().Row(r =>
                    {
                        r.RelativeItem().Text("ДОСТАВЧИК:").Bold().FontSize(10);
                        r.AutoItem().Text("DELIVERER").FontSize(7).FontColor(Colors.Grey.Darken2);
                    });
                    col.Item().PaddingTop(2).Text("„МЕТАЛ-ХАРТ“ ЕООД").Bold().FontSize(10);
                    col.Item().Text("с. Овощник, ул. \"Родопи\" №7");
                    col.Item().Text("МОЛ: Чавдар Войводов");
                    col.Item().Text("ЕИК: 123694428");
                    col.Item().Text("ИН по ДДС: BG 123694428");
                    col.Item().PaddingTop(3).Text("ПроКредит Банк").FontSize(8.5f);
                    col.Item().Text("IBAN: BG68 PRCB 9230 1023 0016 19").Bold().FontSize(8.5f);
                    col.Item().Text("BIC: PRCBBGSF").FontSize(8.5f);
                });
            });
        }
        #endregion

        #region Средна част (Таблица с артикули)
        private void ComposeContent(IContainer container)
        {
            container.BorderLeft(1).BorderRight(1).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(22);  // №
                    columns.RelativeColumn(4);   // Наименование
                    columns.RelativeColumn(1);   // Мярка
                    columns.RelativeColumn(1);   // Кол.
                    columns.RelativeColumn(1.2f);// Ед. цена
                    columns.RelativeColumn(1);   // Отстъпка
                    columns.RelativeColumn(1.5f);// Стойност
                });

                table.Header(header =>
                {
                    void Style(IContainer c, string t) => c.Border(1).Background(Colors.Grey.Lighten3).Padding(3).AlignCenter().Text(t).Bold().FontSize(8);

                    Style(header.Cell(), "№");
                    Style(header.Cell(), "НАИМЕНОВАНИЕ НА СТОКИТЕ ИЛИ УСЛУГИТЕ");
                    Style(header.Cell(), "Мярка");
                    Style(header.Cell(), "Количество");
                    Style(header.Cell(), "Единична цена");
                    Style(header.Cell(), "Отстъпка");
                    Style(header.Cell(), "Стойност");
                });

                bool isManual = _model.Items.Count == 0;
                int rowsToDraw = isManual ? 10 : Math.Max(_model.Items.Count, 10);

                for (int i = 0; i < rowsToDraw; i++)
                {
                    var item = i < _model.Items.Count ? _model.Items[i] : null;

                    void CellStyle(IContainer c, string t, bool alignRight = false)
                    {
                        var cell = c.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).BorderLeft(0.5f).BorderRight(0.5f).MinHeight(16).Padding(2);
                        if (alignRight) cell.AlignRight().Text(t).FontSize(8.5f);
                        else cell.Text(t).FontSize(8.5f);
                    }

                    CellStyle(table.Cell().AlignCenter(), (i + 1).ToString());
                    CellStyle(table.Cell(), item?.Description ?? "");
                    CellStyle(table.Cell().AlignCenter(), item?.Measure ?? "");
                    CellStyle(table.Cell(), item != null ? $"{item.Quantity:0.##}" : "", true);
                    CellStyle(table.Cell(), item != null ? $"{item.UnitPrice:0.00}" : "", true);
                    CellStyle(table.Cell().AlignCenter(), item != null && item.Discount > 0 ? $"{item.Discount}%" : "");
                    CellStyle(table.Cell(), item != null ? $"{item.Total:0.00}" : "", true);
                }
            });
        }
        #endregion

        #region Долна част (Тотали, Подписи и Счетоводна справка)
        private void ComposeFooter(IContainer container)
        {
            bool isManual = _model.Items.Count == 0;

            container.Border(1).Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().BorderRight(1).Padding(5).Column(c =>
                    {
                        c.Item().Text(t =>
                        {
                            t.Span("Словом: ").Bold();
                            t.Span(isManual ? "..................................................................." : NumberToWordsBg.ToWords(_model.GrandTotal));
                        });

                        c.Item().PaddingTop(2).Text("☐ Обстоятелства, които определят стоката като нова    ☐ ДДС е осигурено от получателя").FontSize(6.5f);
                        c.Item().Text("☐ Неначисляване на ДДС - чл. 86(3) от ЗДДС / чл. 114 от ЗДДС").FontSize(6.5f);

                        c.Item().PaddingTop(2).Row(r =>
                        {
                            r.RelativeItem().Column(sub =>
                            {
                                sub.Item().Text("Получател: ............................").Bold();
                                sub.Item().Text($"Дата на данъчното събитие: {_model.IssueDate:dd.MM.yyyy} г.");
                                sub.Item().Text("Дата на плащане: ....................");
                                sub.Item().Text("Стоката получена на: ...............");
                            });

                            r.RelativeItem().Column(sub =>
                            {
                                sub.Item().Text("Съставил: ............................").Bold();
                                sub.Item().Text("Име и фамилия: ....................");
                                sub.Item().Text("Подпис: ................................");
                            });
                        });
                    });

                    row.ConstantItem(185).Table(table =>
                    {
                        table.ColumnsDefinition(c => { c.RelativeColumn(); c.ConstantColumn(65); });

                        void TotalRow(string label, string val, bool bold = false, bool bg = false)
                        {
                            void StyleAndPrint(IContainer cellContainer, string text, bool alignRight)
                            {
                                var c = cellContainer.BorderBottom(1).BorderColor(Colors.Grey.Lighten1);

                                if (bg) c = c.Background(Colors.Grey.Lighten3);
                                c = c.Padding(2.5f);
                                if (alignRight) c = c.AlignRight();

                                if (bold) c.Text(text).Bold();
                                else c.Text(text);
                            }

                            StyleAndPrint(table.Cell(), label, false);
                            StyleAndPrint(table.Cell(), val, true);
                        }

                        TotalRow("Данъчна основа:", isManual ? "........... EUR." : $"{_model.SubTotal:0.00} EUR.");
                        TotalRow($"ДДС / VAT ({_model.VatRate}%):", isManual ? "........... EUR." : $"{_model.VatAmount:0.00} EUR.");
                        TotalRow("Сума за плащане:", isManual ? "........... EUR." : $"{_model.GrandTotal:0.00} EUR.", true, true);
                    });
                });

                // НАЙ-ДОЛЕН РЕД - Счетоводна справка
                col.Item().BorderTop(1).Row(row =>
                {
                    row.ConstantItem(120).BorderRight(1).Padding(2).AlignCenter().Text("Счетоводна справка").FontSize(7).Bold();
                    row.RelativeItem().Table(t =>
                    {
                        t.ColumnsDefinition(c => { c.RelativeColumn(); c.RelativeColumn(); c.RelativeColumn(); });
                        t.Cell().BorderRight(1).Padding(2).AlignCenter().Text("с/ка дебит").FontSize(7);
                        t.Cell().BorderRight(1).Padding(2).AlignCenter().Text("с/ка кредит").FontSize(7);
                        t.Cell().Padding(2).AlignCenter().Text("СУМА").FontSize(7);
                    });
                });
            });
        }
        #endregion

        #region Помощни методи (Генериране на квадратчета за цифри)
        private void DrawDigitBoxes(IContainer container, string text, int count)
        {
            container.Row(row =>
            {
                string cleanText = (text ?? "").Trim();
                for (int i = 0; i < count; i++)
                {
                    string charToPrint = i < cleanText.Length ? cleanText[i].ToString() : "";
                    row.AutoItem()
                       .Width(9.5f) 
                       .Height(12)
                       .Border(0.5f)
                       .BorderColor(Colors.Black)
                       .AlignCenter()
                       .AlignMiddle()
                       .Text(charToPrint)
                       .FontSize(7.5f)
                       .Bold();
                }
            });
        }
        #endregion
    }
}
