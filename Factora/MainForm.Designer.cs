using Factora.Data;
using Factora.Documents;
using Factora.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.ComponentModel;
using System.Diagnostics;

namespace Factora
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupClient = new GroupBox();
            label10 = new Label();
            cmbClients = new ComboBox();
            label7 = new Label();
            txtClientVatNum = new TextBox();
            label6 = new Label();
            txtClientEik = new TextBox();
            label5 = new Label();
            txtClientVatId = new TextBox();
            label4 = new Label();
            txtClientMol = new TextBox();
            label3 = new Label();
            txtClientAddress = new TextBox();
            label2 = new Label();
            txtClientCity = new TextBox();
            label1 = new Label();
            txtClientName = new TextBox();
            groupInvoice = new GroupBox();
            label9 = new Label();
            numVatRate = new NumericUpDown();
            label8 = new Label();
            dtpIssueDate = new DateTimePicker();
            lblInvNum = new Label();
            txtInvoiceNumber = new TextBox();
            groupItems = new GroupBox();
            dataGridViewItems = new DataGridView();
            colDescription = new DataGridViewTextBoxColumn();
            colMeasure = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colDiscount = new DataGridViewTextBoxColumn();
            btnGenerate = new Button();
            groupClient.SuspendLayout();
            groupInvoice.SuspendLayout();
            ((ISupportInitialize)numVatRate).BeginInit();
            groupItems.SuspendLayout();
            ((ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // groupClient
            // 
            groupClient.Controls.Add(label10);
            groupClient.Controls.Add(cmbClients);
            groupClient.Controls.Add(label7);
            groupClient.Controls.Add(txtClientVatNum);
            groupClient.Controls.Add(label6);
            groupClient.Controls.Add(txtClientEik);
            groupClient.Controls.Add(label5);
            groupClient.Controls.Add(txtClientVatId);
            groupClient.Controls.Add(label4);
            groupClient.Controls.Add(txtClientMol);
            groupClient.Controls.Add(label3);
            groupClient.Controls.Add(txtClientAddress);
            groupClient.Controls.Add(label2);
            groupClient.Controls.Add(txtClientCity);
            groupClient.Controls.Add(label1);
            groupClient.Controls.Add(txtClientName);
            groupClient.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupClient.Location = new Point(15, 15);
            groupClient.Name = "groupClient";
            groupClient.Size = new System.Drawing.Size(520, 220);
            groupClient.TabIndex = 0;
            groupClient.TabStop = false;
            groupClient.Text = "Данни за получателя (Клиент)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(15, 30);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(116, 15);
            label10.TabIndex = 15;
            label10.Text = "Запазени шаблони:";
            // 
            // cmbClients
            // 
            cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClients.Font = new Font("Segoe UI", 9F);
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(140, 27);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new System.Drawing.Size(360, 23);
            cmbClients.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(260, 180);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(75, 15);
            label7.TabIndex = 13;
            label7.Text = "ДДС/VAT №:";
            // 
            // txtClientVatNum
            // 
            txtClientVatNum.Font = new Font("Segoe UI", 9F);
            txtClientVatNum.Location = new Point(340, 177);
            txtClientVatNum.Name = "txtClientVatNum";
            txtClientVatNum.Size = new System.Drawing.Size(160, 23);
            txtClientVatNum.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(15, 180);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(58, 15);
            label6.TabIndex = 11;
            label6.Text = "ЕИК/ЕГН:";
            // 
            // txtClientEik
            // 
            txtClientEik.Font = new Font("Segoe UI", 9F);
            txtClientEik.Location = new Point(90, 177);
            txtClientEik.Name = "txtClientEik";
            txtClientEik.Size = new System.Drawing.Size(150, 23);
            txtClientEik.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(260, 145);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(80, 15);
            label5.TabIndex = 9;
            label5.Text = "ЗДДС номер:";
            // 
            // txtClientVatId
            // 
            txtClientVatId.Font = new Font("Segoe UI", 9F);
            txtClientVatId.Location = new Point(340, 142);
            txtClientVatId.Name = "txtClientVatId";
            txtClientVatId.Size = new System.Drawing.Size(160, 23);
            txtClientVatId.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(15, 145);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 15);
            label4.TabIndex = 7;
            label4.Text = "МОЛ:";
            // 
            // txtClientMol
            // 
            txtClientMol.Font = new Font("Segoe UI", 9F);
            txtClientMol.Location = new Point(90, 142);
            txtClientMol.Name = "txtClientMol";
            txtClientMol.Size = new System.Drawing.Size(150, 23);
            txtClientMol.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(15, 110);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "Адрес:";
            // 
            // txtClientAddress
            // 
            txtClientAddress.Font = new Font("Segoe UI", 9F);
            txtClientAddress.Location = new Point(90, 107);
            txtClientAddress.Name = "txtClientAddress";
            txtClientAddress.Size = new System.Drawing.Size(410, 23);
            txtClientAddress.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(260, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Град/село:";
            // 
            // txtClientCity
            // 
            txtClientCity.Font = new Font("Segoe UI", 9F);
            txtClientCity.Location = new Point(340, 72);
            txtClientCity.Name = "txtClientCity";
            txtClientCity.Size = new System.Drawing.Size(160, 23);
            txtClientCity.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(15, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Клиент/Име:";
            // 
            // txtClientName
            // 
            txtClientName.Font = new Font("Segoe UI", 9F);
            txtClientName.Location = new Point(90, 72);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new System.Drawing.Size(150, 23);
            txtClientName.TabIndex = 0;
            // 
            // groupInvoice
            // 
            groupInvoice.Controls.Add(label9);
            groupInvoice.Controls.Add(numVatRate);
            groupInvoice.Controls.Add(label8);
            groupInvoice.Controls.Add(dtpIssueDate);
            groupInvoice.Controls.Add(lblInvNum);
            groupInvoice.Controls.Add(txtInvoiceNumber);
            groupInvoice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupInvoice.Location = new Point(550, 15);
            groupInvoice.Name = "groupInvoice";
            groupInvoice.Size = new System.Drawing.Size(320, 220);
            groupInvoice.TabIndex = 1;
            groupInvoice.TabStop = false;
            groupInvoice.Text = "Данни за фактурата";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(20, 110);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 15);
            label9.TabIndex = 5;
            label9.Text = "Ставка ДДС %:";
            // 
            // numVatRate
            // 
            numVatRate.Font = new Font("Segoe UI", 9F);
            numVatRate.Location = new Point(120, 108);
            numVatRate.Name = "numVatRate";
            numVatRate.Size = new System.Drawing.Size(180, 23);
            numVatRate.TabIndex = 4;
            numVatRate.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(20, 75);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 15);
            label8.TabIndex = 3;
            label8.Text = "Дата:";
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Font = new Font("Segoe UI", 9F);
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(120, 72);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new System.Drawing.Size(180, 23);
            dtpIssueDate.TabIndex = 2;
            // 
            // lblInvNum
            // 
            lblInvNum.AutoSize = true;
            lblInvNum.Font = new Font("Segoe UI", 9F);
            lblInvNum.Location = new Point(20, 40);
            lblInvNum.Name = "lblInvNum";
            lblInvNum.Size = new System.Drawing.Size(71, 15);
            lblInvNum.TabIndex = 1;
            lblInvNum.Text = "Фактура №:";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtInvoiceNumber.Location = new Point(120, 36);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new System.Drawing.Size(180, 25);
            txtInvoiceNumber.TabIndex = 0;
            // 
            // groupItems
            // 
            groupItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupItems.Controls.Add(dataGridViewItems);
            groupItems.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupItems.Location = new Point(15, 250);
            groupItems.Name = "groupItems";
            groupItems.Size = new System.Drawing.Size(855, 280);
            groupItems.TabIndex = 2;
            groupItems.TabStop = false;
            groupItems.Text = "Артикули и Услуги (Остави празно за генериране на бланка за химикал)";
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewItems.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { colDescription, colMeasure, colQuantity, colUnitPrice, colDiscount });
            dataGridViewItems.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewItems.Location = new Point(15, 25);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.Size = new System.Drawing.Size(825, 240);
            dataGridViewItems.TabIndex = 0;
            // 
            // colDescription
            // 
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Описание на стоката/услугата";
            colDescription.Name = "colDescription";
            // 
            // colMeasure
            // 
            colMeasure.DataPropertyName = "Measure";
            colMeasure.FillWeight = 30F;
            colMeasure.HeaderText = "Мярка";
            colMeasure.Name = "colMeasure";
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.FillWeight = 30F;
            colQuantity.HeaderText = "Количество";
            colQuantity.Name = "colQuantity";
            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.FillWeight = 40F;
            colUnitPrice.HeaderText = "Ед. цена (лв.)";
            colUnitPrice.Name = "colUnitPrice";
            // 
            // colDiscount
            // 
            colDiscount.DataPropertyName = "Discount";
            colDiscount.FillWeight = 30F;
            colDiscount.HeaderText = "Отстъпка %";
            colDiscount.Name = "colDiscount";
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerate.BackColor = System.Drawing.Color.MediumSeaGreen;
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGenerate.ForeColor = System.Drawing.Color.White;
            btnGenerate.Location = new Point(620, 545);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(250, 45);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "💾 ЗАПАЗИ И ИЗДАЙ PDF";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            ClientSize = new System.Drawing.Size(884, 606);
            Controls.Add(btnGenerate);
            Controls.Add(groupItems);
            Controls.Add(groupInvoice);
            Controls.Add(groupClient);
            MinimumSize = new System.Drawing.Size(900, 645);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система за издаване на Фактури (Local Edition)";
            groupClient.ResumeLayout(false);
            groupClient.PerformLayout();
            groupInvoice.ResumeLayout(false);
            groupInvoice.PerformLayout();
            ((ISupportInitialize)numVatRate).EndInit();
            groupItems.ResumeLayout(false);
            ((ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupClient;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientMol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClientVatId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientEik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClientVatNum;
        private System.Windows.Forms.GroupBox groupInvoice;
        private System.Windows.Forms.Label lblInvNum;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numVatRate;
        private System.Windows.Forms.GroupBox groupItems;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
    }

}
