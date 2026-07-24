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
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            dataGridViewItems = new DataGridView();
            dtpIssueDate = new DateTimePicker();
            txtInvoiceNumber = new TextBox();
            txtClientName = new TextBox();
            txtClientCity = new TextBox();
            txtClientAddress = new TextBox();
            txtClientMol = new TextBox();
            txtClientVatId = new TextBox();
            txtClientEik = new TextBox();
            txtClientVatNum = new TextBox();
            numVatRate = new NumericUpDown();
            btnGenerate = new Button();
            ((ISupportInitialize)dataGridViewItems).BeginInit();
            ((ISupportInitialize)numVatRate).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Location = new Point(12, 12);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.Size = new System.Drawing.Size(240, 150);
            dataGridViewItems.TabIndex = 0;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Location = new Point(258, 12);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new System.Drawing.Size(200, 23);
            dtpIssueDate.TabIndex = 1;
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(464, 12);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new System.Drawing.Size(100, 23);
            txtInvoiceNumber.TabIndex = 2;
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(258, 41);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new System.Drawing.Size(100, 23);
            txtClientName.TabIndex = 3;
            // 
            // txtClientCity
            // 
            txtClientCity.Location = new Point(258, 70);
            txtClientCity.Name = "txtClientCity";
            txtClientCity.Size = new System.Drawing.Size(100, 23);
            txtClientCity.TabIndex = 4;
            // 
            // txtClientAddress
            // 
            txtClientAddress.Location = new Point(258, 99);
            txtClientAddress.Name = "txtClientAddress";
            txtClientAddress.Size = new System.Drawing.Size(100, 23);
            txtClientAddress.TabIndex = 5;
            // 
            // txtClientMol
            // 
            txtClientMol.Location = new Point(258, 128);
            txtClientMol.Name = "txtClientMol";
            txtClientMol.Size = new System.Drawing.Size(100, 23);
            txtClientMol.TabIndex = 6;
            // 
            // txtClientVatId
            // 
            txtClientVatId.Location = new Point(364, 41);
            txtClientVatId.Name = "txtClientVatId";
            txtClientVatId.Size = new System.Drawing.Size(100, 23);
            txtClientVatId.TabIndex = 7;
            // 
            // txtClientEik
            // 
            txtClientEik.Location = new Point(364, 70);
            txtClientEik.Name = "txtClientEik";
            txtClientEik.Size = new System.Drawing.Size(100, 23);
            txtClientEik.TabIndex = 8;
            // 
            // txtClientVatNum
            // 
            txtClientVatNum.Location = new Point(364, 99);
            txtClientVatNum.Name = "txtClientVatNum";
            txtClientVatNum.Size = new System.Drawing.Size(100, 23);
            txtClientVatNum.TabIndex = 9;
            // 
            // numVatRate
            // 
            numVatRate.Location = new Point(364, 129);
            numVatRate.Name = "numVatRate";
            numVatRate.Size = new System.Drawing.Size(100, 23);
            numVatRate.TabIndex = 10;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(470, 128);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(75, 23);
            btnGenerate.TabIndex = 11;
            btnGenerate.Text = "Save";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(btnGenerate);
            Controls.Add(numVatRate);
            Controls.Add(txtClientVatNum);
            Controls.Add(txtClientEik);
            Controls.Add(txtClientVatId);
            Controls.Add(txtClientMol);
            Controls.Add(txtClientAddress);
            Controls.Add(txtClientCity);
            Controls.Add(txtClientName);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(dtpIssueDate);
            Controls.Add(dataGridViewItems);
            Name = "MainForm";
            Text = "Фактури";
            ((ISupportInitialize)dataGridViewItems).EndInit();
            ((ISupportInitialize)numVatRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        

        private DataGridView dataGridViewItems;
        private DateTimePicker dtpIssueDate;
        private TextBox txtInvoiceNumber;
        private TextBox txtClientName;
        private TextBox txtClientCity;
        private TextBox txtClientAddress;
        private TextBox txtClientMol;
        private TextBox txtClientVatId;
        private TextBox txtClientEik;
        private TextBox txtClientVatNum;
        private NumericUpDown numVatRate;
        private Button btnGenerate;
    }

}
