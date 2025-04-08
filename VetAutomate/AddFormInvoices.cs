using System.Data.SqlClient;

namespace VetAutomate
{
    public partial class AddFormInvoices : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormInvoices()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var clientLogin = textBoxClientIDInvoices.Text;
                string queryClient = $"SELECT ClientID FROM Clients WHERE FullName = '{clientLogin}'";
                SqlCommand commandClient = new(queryClient, dataBase.GetConnection());
                dataBase.OpenConnection();
                object resultClient = commandClient.ExecuteScalar();
                var clientID = resultClient?.ToString() ?? "0";
                var totalAmount = textBoxTotalAmount.Text;
                var invoiceDate = dateTimePickerInvoiceDate.Value;
                var paid = checkBoxPaid.Checked ? "1" : "0";
                var insertQuery = $"INSERT INTO Invoices (ClientID, TotalAmount, InvoiceDate, Paid) VALUES ('{clientID}', '{totalAmount}', '{invoiceDate}', '{paid}')";
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