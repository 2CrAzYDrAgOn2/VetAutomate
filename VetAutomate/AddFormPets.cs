using System.Data.SqlClient;
using System.Windows.Forms;

namespace VetAutomate
{
    public partial class AddFormPets : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormPets()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxOwnerID.Items.Clear();
            var ownersQuery = "SELECT FullName FROM Clients ORDER BY FullName";
            var ownersCommand = new SqlCommand(ownersQuery, dataBase.GetConnection());
            var ownersReader = ownersCommand.ExecuteReader();
            while (ownersReader.Read())
            {
                comboBoxOwnerID.Items.Add(ownersReader.GetString(0));
            }
            ownersReader.Close();
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
                var name = textBoxNamePets.Text;
                var species = textBoxSpecies.Text;
                var breed = textBoxBreed.Text;
                var birthDate = dateTimePickerBirthDatePets.Value;
                var ownerLogin = comboBoxOwnerID.Text;
                string queryOwner = $"SELECT ClientID FROM Clients WHERE FullName = '{ownerLogin}'";
                SqlCommand commandOwner = new(queryOwner, dataBase.GetConnection());
                dataBase.OpenConnection();
                object resultOwner = commandOwner.ExecuteScalar();
                var ownerID = resultOwner?.ToString() ?? "0";
                var insertQuery = $"INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES ('{name}', '{species}', '{breed}', '{birthDate}', '{ownerID}')";
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