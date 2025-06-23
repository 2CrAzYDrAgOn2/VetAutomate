using System.Data.SqlClient;
using System.Windows.Forms;

namespace VetAutomate
{
    public partial class AddFormServiceUsages : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormServiceUsages()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxPetIDServiceUsages.Items.Clear();
            var petsQuery = "SELECT Name FROM Pets ORDER BY Name";
            var petsCommand = new SqlCommand(petsQuery, dataBase.GetConnection());
            var petsReader = petsCommand.ExecuteReader();
            while (petsReader.Read())
            {
                comboBoxPetIDServiceUsages.Items.Add(petsReader.GetString(0));
            }
            petsReader.Close();
            comboBoxVetIDServiceUsages.Items.Clear();
            var vetsQuery = "SELECT FullName FROM Veterinarians ORDER BY FullName";
            var vetsCommand = new SqlCommand(vetsQuery, dataBase.GetConnection());
            var vetsReader = vetsCommand.ExecuteReader();
            while (vetsReader.Read())
            {
                comboBoxVetIDServiceUsages.Items.Add(vetsReader.GetString(0));
            }
            vetsReader.Close();
            comboBoxServiceIDServiceUsages.Items.Clear();
            var servicesQuery = "SELECT ServiceName FROM Services ORDER BY ServiceName";
            var servicesCommand = new SqlCommand(servicesQuery, dataBase.GetConnection());
            var servicesReader = servicesCommand.ExecuteReader();
            while (servicesReader.Read())
            {
                comboBoxServiceIDServiceUsages.Items.Add(servicesReader.GetString(0));
            }
            servicesReader.Close();

            dataBase.CloseConnection();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var petName = comboBoxPetIDServiceUsages.Text;
                string queryPet = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                object resultPet = commandPet.ExecuteScalar();
                var petID = resultPet?.ToString() ?? "0";
                var vetName = comboBoxVetIDServiceUsages.Text;
                string queryVet = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                object resultVet = commandVet.ExecuteScalar();
                var vetID = resultVet?.ToString() ?? "0";
                var serviceName = comboBoxServiceIDServiceUsages.Text;
                string queryService = $"SELECT ServiceID FROM Services WHERE ServiceName = '{serviceName}'";
                SqlCommand commandService = new(queryService, dataBase.GetConnection());
                object resultService = commandService.ExecuteScalar();
                var serviceID = resultService?.ToString() ?? "0";
                var purpose = textBoxPurposeServiceUsages.Text;
                var insertQuery = $@"INSERT INTO ServiceUsages
                                    (PetID, VetID, ServiceID, Purpose)
                                    VALUES
                                    ('{petID}', '{vetID}', '{serviceID}', '{purpose}')";

                var sqlCommand = new SqlCommand(insertQuery, dataBase.GetConnection());
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Использование услуги успешно добавлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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