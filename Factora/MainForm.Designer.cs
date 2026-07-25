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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupClient = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClientVatNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientEik = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClientVatId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientMol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.groupInvoice = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numVatRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvNum = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.groupItems = new System.Windows.Forms.GroupBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupClient.SuspendLayout();
            this.groupInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).BeginInit();
            this.groupItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupClient
            // 
            this.groupClient.Controls.Add(this.label10);
            this.groupClient.Controls.Add(this.cmbClients);
            this.groupClient.Controls.Add(this.label7);
            this.groupClient.Controls.Add(this.txtClientVatNum);
            this.groupClient.Controls.Add(this.label6);
            this.groupClient.Controls.Add(this.txtClientEik);
            this.groupClient.Controls.Add(this.label5);
            this.groupClient.Controls.Add(this.txtClientVatId);
            this.groupClient.Controls.Add(this.label4);
            this.groupClient.Controls.Add(this.txtClientMol);
            this.groupClient.Controls.Add(this.label3);
            this.groupClient.Controls.Add(this.txtClientAddress);
            this.groupClient.Controls.Add(this.label2);
            this.groupClient.Controls.Add(this.txtClientCity);
            this.groupClient.Controls.Add(this.label1);
            this.groupClient.Controls.Add(this.txtClientName);
            this.groupClient.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupClient.Location = new System.Drawing.Point(15, 15);
            this.groupClient.Name = "groupClient";
            this.groupClient.Size = new System.Drawing.Size(520, 220);
            this.groupClient.TabIndex = 0;
            this.groupClient.TabStop = false;
            this.groupClient.Text = "Данни за получателя (Клиент)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(15, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Запазени шаблони:";
            // 
            // cmbClients
            // 
            this.cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(140, 27);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(360, 23);
            this.cmbClients.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(260, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "ДДС/VAT №:";
            // 
            // txtClientVatNum
            // 
            this.txtClientVatNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientVatNum.Location = new System.Drawing.Point(340, 177);
            this.txtClientVatNum.Name = "txtClientVatNum";
            this.txtClientVatNum.Size = new System.Drawing.Size(160, 23);
            this.txtClientVatNum.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(15, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "ЕИК/ЕГН:";
            // 
            // txtClientEik
            // 
            this.txtClientEik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientEik.Location = new System.Drawing.Point(90, 177);
            this.txtClientEik.Name = "txtClientEik";
            this.txtClientEik.Size = new System.Drawing.Size(150, 23);
            this.txtClientEik.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(260, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "ЗДДС номер:";
            // 
            // txtClientVatId
            // 
            this.txtClientVatId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientVatId.Location = new System.Drawing.Point(340, 142);
            this.txtClientVatId.Name = "txtClientVatId";
            this.txtClientVatId.Size = new System.Drawing.Size(160, 23);
            this.txtClientVatId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(15, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "МОЛ:";
            // 
            // txtClientMol
            // 
            this.txtClientMol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientMol.Location = new System.Drawing.Point(90, 142);
            this.txtClientMol.Name = "txtClientMol";
            this.txtClientMol.Size = new System.Drawing.Size(150, 23);
            this.txtClientMol.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Адрес:";
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientAddress.Location = new System.Drawing.Point(90, 107);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(410, 23);
            this.txtClientAddress.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(260, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Град/село:";
            // 
            // txtClientCity
            // 
            this.txtClientCity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientCity.Location = new System.Drawing.Point(340, 72);
            this.txtClientCity.Name = "txtClientCity";
            this.txtClientCity.Size = new System.Drawing.Size(160, 23);
            this.txtClientCity.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Клиент/Име:";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClientName.Location = new System.Drawing.Point(90, 72);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(150, 23);
            this.txtClientName.TabIndex = 0;
            // 
            // groupInvoice
            // 
            this.groupInvoice.Controls.Add(this.label9);
            this.groupInvoice.Controls.Add(this.numVatRate);
            this.groupInvoice.Controls.Add(this.label8);
            this.groupInvoice.Controls.Add(this.dtpIssueDate);
            this.groupInvoice.Controls.Add(this.lblInvNum);
            this.groupInvoice.Controls.Add(this.txtInvoiceNumber);
            this.groupInvoice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupInvoice.Location = new System.Drawing.Point(550, 15);
            this.groupInvoice.Name = "groupInvoice";
            this.groupInvoice.Size = new System.Drawing.Size(320, 220);
            this.groupInvoice.TabIndex = 1;
            this.groupInvoice.TabStop = false;
            this.groupInvoice.Text = "Данни за фактурата";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ставка ДДС %:";
            // 
            // numVatRate
            // 
            this.numVatRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numVatRate.Location = new System.Drawing.Point(120, 108);
            this.numVatRate.Name = "numVatRate";
            this.numVatRate.Size = new System.Drawing.Size(180, 23);
            this.numVatRate.TabIndex = 4;
            this.numVatRate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(20, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Дата:";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Location = new System.Drawing.Point(120, 72);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(180, 23);
            this.dtpIssueDate.TabIndex = 2;
            // 
            // lblInvNum
            // 
            this.lblInvNum.AutoSize = true;
            this.lblInvNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInvNum.Location = new System.Drawing.Point(20, 40);
            this.lblInvNum.Name = "lblInvNum";
            this.lblInvNum.Size = new System.Drawing.Size(68, 15);
            this.lblInvNum.TabIndex = 1;
            this.lblInvNum.Text = "Фактура №:";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtInvoiceNumber.Location = new System.Drawing.Point(120, 36);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(180, 25);
            this.txtInvoiceNumber.TabIndex = 0;
            // 
            // groupItems
            // 
            this.groupItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupItems.Controls.Add(this.dataGridViewItems);
            this.groupItems.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupItems.Location = new System.Drawing.Point(15, 250);
            this.groupItems.Name = "groupItems";
            this.groupItems.Size = new System.Drawing.Size(855, 280);
            this.groupItems.TabIndex = 2;
            this.groupItems.TabStop = false;
            this.groupItems.Text = "Артикули и Услуги (Остави празно за генериране на бланка за химикал)";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colMeasure,
            this.colQuantity,
            this.colUnitPrice,
            this.colDiscount});
            this.dataGridViewItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewItems.Location = new System.Drawing.Point(15, 25);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowTemplate.Height = 25;
            this.dataGridViewItems.Size = new System.Drawing.Size(825, 240);
            this.dataGridViewItems.TabIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Описание на стоката/услугата";
            this.colDescription.Name = "colDescription";
            // 
            // colMeasure
            // 
            this.colMeasure.DataPropertyName = "Measure";
            this.colMeasure.FillWeight = 30F;
            this.colMeasure.HeaderText = "Мярка";
            this.colMeasure.Name = "colMeasure";
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.FillWeight = 30F;
            this.colQuantity.HeaderText = "Количество";
            this.colQuantity.Name = "colQuantity";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.FillWeight = 40F;
            this.colUnitPrice.HeaderText = "Ед. цена (лв.)";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // colDiscount
            // 
            this.colDiscount.DataPropertyName = "Discount";
            this.colDiscount.FillWeight = 30F;
            this.colDiscount.HeaderText = "Отстъпка %";
            this.colDiscount.Name = "colDiscount";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(620, 545);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(250, 45);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "💾 ЗАПАЗИ И ИЗДАЙ PDF";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(884, 606);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupItems);
            this.Controls.Add(this.groupInvoice);
            this.Controls.Add(this.groupClient);
            this.MinimumSize = new System.Drawing.Size(900, 645);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система за издаване на Фактури (Local Edition)";
            this.groupClient.ResumeLayout(false);
            this.groupClient.PerformLayout();
            this.groupInvoice.ResumeLayout(false);
            this.groupInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).EndInit();
            this.groupItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);

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
