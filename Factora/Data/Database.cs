using Dapper;
using Factora.Models;
using Microsoft.Data.Sqlite;

namespace Factora.Data
{
    public class Database
    {
        private readonly string _connectionString = "Data Source=invoices.db";

        public void Setup()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var sql = @"
                CREATE TABLE IF NOT EXISTS Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientName TEXT UNIQUE NOT NULL,
                    ClientCity TEXT,
                    ClientAddress TEXT,
                    ClientMol TEXT,
                    ClientVatId TEXT,
                    ClientEikEgn TEXT,
                    ClientVatNumber TEXT
                );

                CREATE TABLE IF NOT EXISTS Invoices (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    InvoiceNumber TEXT NOT NULL,
                    IssueDate TEXT NOT NULL,
                    PlaceOfIssue TEXT,
                    ClientName TEXT NOT NULL,
                    ClientCity TEXT,
                    ClientAddress TEXT,
                    ClientMol TEXT,
                    ClientVatId TEXT,
                    ClientEikEgn TEXT,
                    ClientVatNumber TEXT,
                    VatRate REAL
                );

                CREATE TABLE IF NOT EXISTS InvoiceItems (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    InvoiceId INTEGER NOT NULL,
                    Description TEXT NOT NULL,
                    Measure TEXT,
                    Quantity REAL NOT NULL,
                    UnitPrice REAL NOT NULL,
                    Discount REAL NOT NULL,
                    FOREIGN KEY(InvoiceId) REFERENCES Invoices(Id) ON DELETE CASCADE
                );";

            connection.Execute(sql);
        }

        public void SaveInvoice(Invoice invoice)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            var insertInvoiceSql = @"
                INSERT INTO Invoices (InvoiceNumber, IssueDate, PlaceOfIssue, ClientName, ClientCity, ClientAddress, ClientMol, ClientVatId, ClientEikEgn, ClientVatNumber, VatRate)
                VALUES (@InvoiceNumber, @IssueDate, @PlaceOfIssue, @ClientName, @ClientCity, @ClientAddress, @ClientMol, @ClientVatId, @ClientEikEgn, @ClientVatNumber, @VatRate);
                SELECT last_insert_rowid();";

            invoice.Id = connection.ExecuteScalar<int>(insertInvoiceSql, invoice, transaction);

            var insertItemSql = @"
                INSERT INTO InvoiceItems (InvoiceId, Description, Measure, Quantity, UnitPrice, Discount)
                VALUES (@InvoiceId, @Description, @Measure, @Quantity, @UnitPrice, @Discount);";

            foreach (var item in invoice.Items)
            {
                connection.Execute(insertItemSql, new
                {
                    InvoiceId = invoice.Id,
                    item.Description,
                    item.Measure,
                    item.Quantity,
                    item.UnitPrice,
                    item.Discount
                }, transaction);
            }

            transaction.Commit();
        }
        public List<Invoice> GetAllClients()
        {
            using var connection = new SqliteConnection(_connectionString);
            return connection.Query<Invoice>("SELECT * FROM Clients ORDER BY ClientName").ToList();
        }

        public void SaveOrUpdateClient(Invoice inv)
        {
            if (string.IsNullOrWhiteSpace(inv.ClientName)) return;

            using var connection = new SqliteConnection(_connectionString);
            var sql = @"
        INSERT INTO Clients (ClientName, ClientCity, ClientAddress, ClientMol, ClientVatId, ClientEikEgn, ClientVatNumber)
        VALUES (@ClientName, @ClientCity, @ClientAddress, @ClientMol, @ClientVatId, @ClientEikEgn, @ClientVatNumber)
        ON CONFLICT(ClientName) DO UPDATE SET
            ClientCity = excluded.ClientCity,
            ClientAddress = excluded.Address,
            ClientMol = excluded.ClientMol,
            ClientVatId = excluded.ClientVatId,
            ClientEikEgn = excluded.ClientEikEgn,
            ClientVatNumber = excluded.ClientVatNumber;";

            connection.Execute(sql, inv);
        }
    }
}
