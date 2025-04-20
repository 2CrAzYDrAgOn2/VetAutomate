using System.Data.SqlClient;

namespace VetAutomate
{
    public partial class AddFormClients : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormClients()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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
                var fullName = textBoxFullNameClients.Text;
                var phone = maskedTextBoxPhoneClients.Text;
                var email = textBoxEmailClients.Text;
                var address = textBoxAddress.Text;
                var inn = textBoxINNClients.Text;
                var registrationDate = dateTimePickerRegistrationDate.Value;
                var insertQuery = $"INSERT INTO Clients (FullName, Phone, Email, Address, INN, RegistrationDate) VALUES ('{fullName}', '{phone}', '{email}', '{address}', '{inn}', '{registrationDate}')";
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