using System.Data.SqlClient;
using System.Windows.Forms;

namespace VetAutomate
{
    public partial class AddFormMedicationSupplies : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMedicationSupplies()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxMedicationIDMedicationSuppplies.Items.Clear();
            var medsQuery = "SELECT Name FROM Medications ORDER BY Name";
            var medsCommand = new SqlCommand(medsQuery, dataBase.GetConnection());
            var medsReader = medsCommand.ExecuteReader();
            while (medsReader.Read())
            {
                comboBoxMedicationIDMedicationSuppplies.Items.Add(medsReader.GetString(0));
            }
            medsReader.Close();
            dataBase.CloseConnection();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var medName = comboBoxMedicationIDMedicationSuppplies.Text;
                string queryMed = $"SELECT MedicationID FROM Medications WHERE Name = '{medName}'";
                SqlCommand commandMed = new(queryMed, dataBase.GetConnection());
                object resultMed = commandMed.ExecuteScalar();
                var medicationID = resultMed?.ToString() ?? "0";
                var quantity = textBoxQuantitySupplied.Text;
                var supplier = textBoxSupplierName.Text;
                var supplyDate = dateTimePickerSupplyDate.Value;
                var insertQuery = $@"INSERT INTO MedicationSupplies
                                    (MedicationID, QuantitySupplied, SupplierName, SupplyDate)
                                    VALUES
                                    ('{medicationID}', '{quantity}', '{supplier}', '{supplyDate}')";
                var sqlCommand = new SqlCommand(insertQuery, dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Поставка успешно добавлена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }
    }
}