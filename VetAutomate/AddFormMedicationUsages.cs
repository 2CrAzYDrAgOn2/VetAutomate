using System.Data.SqlClient;
using System.Windows.Forms;

namespace VetAutomate
{
    public partial class AddFormMedicationUsages : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormMedicationUsages()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxPetIDMedicationUsages.Items.Clear();
            var petsQuery = "SELECT Name FROM Pets ORDER BY Name";
            var petsCommand = new SqlCommand(petsQuery, dataBase.GetConnection());
            var petsReader = petsCommand.ExecuteReader();
            while (petsReader.Read())
            {
                comboBoxPetIDMedicationUsages.Items.Add(petsReader.GetString(0));
            }
            petsReader.Close();
            comboBoxVetIDMedicationUsages.Items.Clear();
            var vetsQuery = "SELECT FullName FROM Veterinarians ORDER BY FullName";
            var vetsCommand = new SqlCommand(vetsQuery, dataBase.GetConnection());
            var vetsReader = vetsCommand.ExecuteReader();
            while (vetsReader.Read())
            {
                comboBoxVetIDMedicationUsages.Items.Add(vetsReader.GetString(0));
            }
            vetsReader.Close();
            comboBoxMedicationIDMedicationUsages.Items.Clear();
            var medsQuery = "SELECT Name FROM Medications ORDER BY Name";
            var medsCommand = new SqlCommand(medsQuery, dataBase.GetConnection());
            var medsReader = medsCommand.ExecuteReader();
            while (medsReader.Read())
            {
                comboBoxMedicationIDMedicationUsages.Items.Add(medsReader.GetString(0));
            }
            medsReader.Close();

            dataBase.CloseConnection();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var petName = comboBoxPetIDMedicationUsages.Text;
                string queryPet = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                object resultPet = commandPet.ExecuteScalar();
                var petID = resultPet?.ToString() ?? "0";
                var vetName = comboBoxVetIDMedicationUsages.Text;
                string queryVet = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                object resultVet = commandVet.ExecuteScalar();
                var vetID = resultVet?.ToString() ?? "0";
                var medName = comboBoxMedicationIDMedicationUsages.Text;
                string queryMed = $"SELECT MedicationID FROM Medications WHERE Name = '{medName}'";
                SqlCommand commandMed = new(queryMed, dataBase.GetConnection());
                object resultMed = commandMed.ExecuteScalar();
                var medicationID = resultMed?.ToString() ?? "0";
                var quantity = textBoxQuantityUsed.Text;
                var purpose = textBoxPurposeMedicationUsages.Text;
                var insertQuery = $@"INSERT INTO MedicationUsages
                                    (PetID, VetID, MedicationID, QuantityUsed, Purpose)
                                    VALUES
                                    ('{petID}', '{vetID}', '{medicationID}', '{quantity}', '{purpose}')";

                var sqlCommand = new SqlCommand(insertQuery, dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();
                var updateQuery = $"UPDATE Medications SET QuantityInStock = QuantityInStock - {quantity} WHERE MedicationID = {medicationID}";
                var updateCommand = new SqlCommand(updateQuery, dataBase.GetConnection());
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Использование лекарства успешно добавлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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