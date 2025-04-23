using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetAutomate
{
    public partial class AddFormPayments : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormPayments()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxInvoiceIDPayments.Items.Clear();
            var invoicesQuery = "SELECT InvoiceID FROM Invoices ORDER BY InvoiceID";
            var invoicesCommand = new SqlCommand(invoicesQuery, dataBase.GetConnection());
            var invoicesReader = invoicesCommand.ExecuteReader();
            while (invoicesReader.Read())
            {
                comboBoxInvoiceIDPayments.Items.Add(invoicesReader.GetInt32(0));
            }
            invoicesReader.Close();
            comboBoxPaymentMethod.Items.Clear();
            var paymentMethodsQuery = "SELECT PaymentMethod FROM PaymentMethods ORDER BY PaymentMethod";
            var paymentMethodsCommand = new SqlCommand(paymentMethodsQuery, dataBase.GetConnection());
            var paymentMethodsReader = paymentMethodsCommand.ExecuteReader();
            while (paymentMethodsReader.Read())
            {
                comboBoxPaymentMethod.Items.Add(paymentMethodsReader.GetString(0));
            }
            paymentMethodsReader.Close();
        }

        /// <summary>
        /// ButtonSave_Click() вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var invoiceID = comboBoxInvoiceIDPayments.Text;
                var amount = textBoxAmount.Text;
                var paymentDate = dateTimePickerPaymentDate.Value;
                var paymentMethodName = comboBoxPaymentMethod.Text;
                string queryPaymentMethod = $"SELECT PaymentMethodID FROM PaymentMethods WHERE PaymentMethod = '{paymentMethodName}'";
                SqlCommand commandPaymentMethod = new(queryPaymentMethod, dataBase.GetConnection());
                dataBase.OpenConnection();
                object resultPaymentMethod = commandPaymentMethod.ExecuteScalar();
                var paymentMethodID = resultPaymentMethod?.ToString() ?? "0";
                var insertQuery = $"INSERT INTO Payments (InvoiceID, Amount, PaymentMethod) VALUES ('{invoiceID}', '{amount}', '{paymentMethodID}')";
                var sqlCommand = new SqlCommand(insertQuery, dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }
    }
}