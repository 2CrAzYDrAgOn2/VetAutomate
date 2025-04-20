using Microsoft.Office.Interop.Word;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Application = Microsoft.Office.Interop.Word.Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace VetAutomate
{
    internal enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        private readonly DataBase dataBase = new();
        private bool admin;
        private int selectedRow;
        private System.Windows.Forms.Timer timer;
        private NotifyIcon notifyIcon;

        public Form1(bool admin)
        {
            try
            {
                this.admin = admin;
                InitializeComponent();
                StartPosition = FormStartPosition.CenterScreen;
                InitializeNotifyIcon();
                InitializeTimer();
                ClearFields();
                ShowBalloonTip();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// CreateColumns() вызывается при создании колонок
        /// </summary>
        private void CreateColumns()
        {
            try
            {
                dataGridViewClients.Columns.Add("ClientID", "Номер");
                dataGridViewClients.Columns.Add("FullName", "ФИО");
                dataGridViewClients.Columns.Add("Phone", "Телефон");
                dataGridViewClients.Columns.Add("Email", "Email");
                dataGridViewClients.Columns.Add("Address", "Адрес");
                dataGridViewClients.Columns.Add("INN", "ИНН");
                dataGridViewClients.Columns.Add("RegistrationDate", "Дата регистрации");
                dataGridViewClients.Columns.Add("IsNew", String.Empty);
                dataGridViewPets.Columns.Add("PetID", "Номер");
                dataGridViewPets.Columns.Add("Name", "Кличка");
                dataGridViewPets.Columns.Add("Species", "Вид");
                dataGridViewPets.Columns.Add("Breed", "Порода");
                dataGridViewPets.Columns.Add("BirthDate", "Дата рождения");
                dataGridViewPets.Columns.Add("OwnerID", "ID владельца");
                dataGridViewPets.Columns.Add("IsNew", String.Empty);
                dataGridViewVeterinarians.Columns.Add("VetID", "Номер");
                dataGridViewVeterinarians.Columns.Add("FullName", "ФИО");
                dataGridViewVeterinarians.Columns.Add("BirthDate", "Дата рождения");
                dataGridViewVeterinarians.Columns.Add("BirthPlace", "Место рождения");
                dataGridViewVeterinarians.Columns.Add("PassportSeries", "Серия паспорта");
                dataGridViewVeterinarians.Columns.Add("PassportNumber", "Номер паспорта");
                dataGridViewVeterinarians.Columns.Add("Phone", "Телефон");
                dataGridViewVeterinarians.Columns.Add("Email", "Email");
                dataGridViewVeterinarians.Columns.Add("INN", "ИНН");
                dataGridViewVeterinarians.Columns.Add("DateOfEmployment", "Дата найма");
                dataGridViewVeterinarians.Columns.Add("PostID", "Должность");
                dataGridViewVeterinarians.Columns.Add("GenderID", "Пол");
                dataGridViewVeterinarians.Columns.Add("IsNew", String.Empty);
                dataGridViewServices.Columns.Add("ServiceID", "Номер");
                dataGridViewServices.Columns.Add("ServiceName", "Услуга");
                dataGridViewServices.Columns.Add("Price", "Цена");
                dataGridViewServices.Columns.Add("IsNew", String.Empty);
                dataGridViewInvoices.Columns.Add("InvoiceID", "Номер");
                dataGridViewInvoices.Columns.Add("ClientID", "ID клиента");
                dataGridViewInvoices.Columns.Add("TotalAmount", "Сумма");
                dataGridViewInvoices.Columns.Add("InvoiceDate", "Дата счета");
                dataGridViewInvoices.Columns.Add("Paid", "Оплачено");
                dataGridViewInvoices.Columns.Add("IsNew", String.Empty);
                dataGridViewPayments.Columns.Add("PaymentID", "Номер");
                dataGridViewPayments.Columns.Add("InvoiceID", "ID счета");
                dataGridViewPayments.Columns.Add("Amount", "Сумма");
                dataGridViewPayments.Columns.Add("PaymentDate", "Дата оплаты");
                dataGridViewPayments.Columns.Add("PaymentMethod", "Способ оплаты");
                dataGridViewPayments.Columns.Add("IsNew", String.Empty);
                dataGridViewMedications.Columns.Add("MedicationID", "Номер");
                dataGridViewMedications.Columns.Add("Name", "Название");
                dataGridViewMedications.Columns.Add("Description", "Описание");
                dataGridViewMedications.Columns.Add("Price", "Цена");
                dataGridViewMedications.Columns.Add("IsNew", String.Empty);
                dataGridViewPrescriptions.Columns.Add("PrescriptionID", "Номер");
                dataGridViewPrescriptions.Columns.Add("PetID", "ID питомца");
                dataGridViewPrescriptions.Columns.Add("VetID", "ID ветеринара");
                dataGridViewPrescriptions.Columns.Add("MedicationID", "ID лекарства");
                dataGridViewPrescriptions.Columns.Add("Dosage", "Дозировка");
                dataGridViewPrescriptions.Columns.Add("Instructions", "Инструкции");
                dataGridViewPrescriptions.Columns.Add("IsNew", String.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ClearFields() вызывается при очистке полей
        /// </summary>
        private void ClearFields()
        {
            try
            {
                textBoxClientID.Text = "";
                textBoxFullNameClients.Text = "";
                maskedTextBoxPhoneClients.Text = "";
                textBoxEmailClients.Text = "";
                textBoxAddress.Text = "";
                textBoxINNClients.Text = "";
                textBoxPetID.Text = "";
                textBoxNamePets.Text = "";
                textBoxSpecies.Text = "";
                textBoxBreed.Text = "";
                textBoxOwnerID.Text = "";
                textBoxVetID.Text = "";
                textBoxFullNameVeterinarians.Text = "";
                textBoxBirthPlace.Text = "";
                textBoxPassportSeries.Text = "";
                textBoxPassportNumber.Text = "";
                maskedTextBoxPhoneVeterinarians.Text = "";
                textBoxEmailVeterinarians.Text = "";
                textBoxINNVeterinarians.Text = "";
                textBoxServiceID.Text = "";
                textBoxServiceName.Text = "";
                textBoxPriceServices.Text = "";
                textBoxInvoiceID.Text = "";
                textBoxClientIDInvoices.Text = "";
                textBoxTotalAmount.Text = "";
                checkBoxPaid.Checked = false;
                textBoxPaymentID.Text = "";
                textBoxInvoiceIDPayments.Text = "";
                textBoxAmount.Text = "";
                textBoxMedicationID.Text = "";
                textBoxNameMedications.Text = "";
                textBoxDescription.Text = "";
                textBoxPriceMedications.Text = "";
                textBoxPrescriptionID.Text = "";
                textBoxPetIDPrescriptions.Text = "";
                textBoxVetID.Text = "";
                textBoxMedicationIDPrescriptions.Text = "";
                textBoxDosage.Text = "";
                textBoxInstructions.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ReadSingleRow() вызывается при чтении каждой строки
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="iDataRecord"></param>
        private static void ReadSingleRow(DataGridView dataGridView, IDataRecord iDataRecord)
        {
            try
            {
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetString(4), iDataRecord.GetString(5), iDataRecord.GetDateTime(6).ToString("yyyy-MM-dd"), RowState.Modified);
                        break;

                    case "dataGridViewPets":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetDateTime(4).ToString("yyyy-MM-dd"), iDataRecord.GetInt32(5), RowState.Modified);
                        break;

                    case "dataGridViewVeterinarians":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.GetString(3), iDataRecord.GetString(4), iDataRecord.GetString(5), iDataRecord.GetString(6), iDataRecord.GetString(7), iDataRecord.GetString(8), iDataRecord.GetDateTime(9).ToString("yyyy-MM-dd"), iDataRecord.GetInt32(10), iDataRecord.GetInt32(11), RowState.Modified);
                        break;

                    case "dataGridViewServices":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDouble(2), RowState.Modified);
                        break;

                    case "dataGridViewInvoices":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetDouble(2), iDataRecord.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss"), iDataRecord.GetBoolean(4), RowState.Modified);
                        break;

                    case "dataGridViewPayments":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetDouble(2), iDataRecord.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss"), iDataRecord.GetInt32(4), RowState.Modified);
                        break;

                    case "dataGridViewMedications":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetDouble(3), RowState.Modified);
                        break;

                    case "dataGridViewPrescriptions":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), iDataRecord.GetString(4), iDataRecord.GetString(5), RowState.Modified);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// RefreshDataGrid() вызывается при обновлении базы данных
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="tableName"></param>
        private void RefreshDataGrid(DataGridView dataGridView, string tableName)
        {
            try
            {
                dataGridView.Rows.Clear();
                string queryString = $"select * from {tableName}";
                SqlCommand sqlCommand = new(queryString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow(dataGridView, sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// InitializeNotifyIcon() вызывается при инициализации иконки в трее
        /// </summary>
        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        /// <summary>
        /// InitializeTimer() вызывается при инициализации таймера
        /// </summary>
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 3600000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Timer_Tick() вызывается при завершении тайиера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowBalloonTip();
        }

        /// <summary>
        /// ShowBalloonTip() вызывается при показе уведомления
        /// </summary>
        private void ShowBalloonTip()
        {
            notifyIcon.BalloonTipTitle = "Учет ветеринарной клиники";
            notifyIcon.BalloonTipText = "Все права защищены.";
            notifyIcon.ShowBalloonTip(3000);
        }

        /// <summary>
        /// Form1_Load() вызывается при загрузке сцены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CreateColumns();
                RefreshDataGrid(dataGridViewClients, "Clients");
                RefreshDataGrid(dataGridViewPets, "Pets");
                RefreshDataGrid(dataGridViewVeterinarians, "Veterinarians");
                RefreshDataGrid(dataGridViewServices, "Services");
                RefreshDataGrid(dataGridViewInvoices, "Invoices");
                RefreshDataGrid(dataGridViewPayments, "Payments");
                RefreshDataGrid(dataGridViewMedications, "Medications");
                RefreshDataGrid(dataGridViewPrescriptions, "Prescriptions");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridView_CellClick() вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="selectedRow"></param>
        private void DataGridView_CellClick(DataGridView dataGridView, int selectedRow)
        {
            try
            {
                DataGridViewRow dataGridViewRow = dataGridView.Rows[selectedRow];
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        textBoxClientID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxFullNameClients.Text = dataGridViewRow.Cells[1].Value.ToString();
                        maskedTextBoxPhoneClients.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxEmailClients.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxAddress.Text = dataGridViewRow.Cells[4].Value.ToString();
                        textBoxINNClients.Text = dataGridViewRow.Cells[5].Value.ToString();
                        dateTimePickerRegistrationDate.Text = dataGridViewRow.Cells[6].Value.ToString();
                        break;

                    case "dataGridViewPets":
                        textBoxPetID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxNamePets.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxSpecies.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxBreed.Text = dataGridViewRow.Cells[3].Value.ToString();
                        dateTimePickerBirthDatePets.Text = dataGridViewRow.Cells[4].Value.ToString();
                        var ownerID = dataGridViewRow.Cells[5].Value.ToString();
                        string queryOwner = $"SELECT FullName FROM Clients WHERE ClientID = {ownerID}";
                        SqlCommand commandOwner = new(queryOwner, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultOwner = commandOwner.ExecuteScalar();
                        textBoxOwnerID.Text = resultOwner.ToString();
                        break;

                    case "dataGridViewVeterinarians":
                        textBoxVetID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxFullNameVeterinarians.Text = dataGridViewRow.Cells[1].Value.ToString();
                        dateTimePickerBirthDateVeterinarians.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxBirthPlace.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxPassportSeries.Text = dataGridViewRow.Cells[4].Value.ToString();
                        textBoxPassportNumber.Text = dataGridViewRow.Cells[5].Value.ToString();
                        maskedTextBoxPhoneVeterinarians.Text = dataGridViewRow.Cells[6].Value.ToString();
                        textBoxEmailVeterinarians.Text = dataGridViewRow.Cells[7].Value.ToString();
                        textBoxINNVeterinarians.Text = dataGridViewRow.Cells[8].Value.ToString();
                        dateTimePickerDateOfEmployment.Text = dataGridViewRow.Cells[9].Value.ToString();
                        var postID = dataGridViewRow.Cells[10].Value.ToString();
                        string queryPost = $"SELECT Post FROM Posts WHERE PostID = {postID}";
                        SqlCommand commandPost = new(queryPost, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultPost = commandPost.ExecuteScalar();
                        comboBoxPost.Text = resultPost.ToString();
                        var genderID = dataGridViewRow.Cells[11].Value.ToString();
                        string queryGender = $"SELECT Gender FROM Genders WHERE GenderID = {genderID}";
                        SqlCommand commandGender = new(queryGender, dataBase.GetConnection());
                        object resultGender = commandGender.ExecuteScalar();
                        comboBoxGender.Text = resultGender.ToString();
                        dataBase.CloseConnection();
                        break;

                    case "dataGridViewServices":
                        textBoxServiceID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxServiceName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxPriceServices.Text = dataGridViewRow.Cells[2].Value.ToString();
                        break;

                    case "dataGridViewInvoices":
                        textBoxInvoiceID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        var clientIDInvoice = dataGridViewRow.Cells[1].Value.ToString();
                        string queryClientInvoice = $"SELECT FullName FROM Clients WHERE ClientID = {clientIDInvoice}";
                        SqlCommand commandClientInvoice = new(queryClientInvoice, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultClientInvoice = commandClientInvoice.ExecuteScalar();
                        textBoxClientIDInvoices.Text = resultClientInvoice.ToString();
                        textBoxTotalAmount.Text = dataGridViewRow.Cells[2].Value.ToString();
                        dateTimePickerInvoiceDate.Text = dataGridViewRow.Cells[3].Value.ToString();
                        checkBoxPaid.Checked = Convert.ToBoolean(dataGridViewRow.Cells[4].Value);
                        break;

                    case "dataGridViewPayments":
                        textBoxPaymentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxInvoiceIDPayments.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxAmount.Text = dataGridViewRow.Cells[2].Value.ToString();
                        dateTimePickerPaymentDate.Text = dataGridViewRow.Cells[3].Value.ToString();
                        var paymentMethod = dataGridViewRow.Cells[4].Value.ToString();
                        string queryMethod = $"SELECT PaymentMethod FROM PaymentMethods WHERE PaymentMethodID = {paymentMethod}";
                        SqlCommand commandMethod = new(queryMethod, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultMethod = commandMethod.ExecuteScalar();
                        comboBoxPaymentMethod.Text = resultMethod.ToString();
                        break;

                    case "dataGridViewMedications":
                        textBoxMedicationID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxNameMedications.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxDescription.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxPriceMedications.Text = dataGridViewRow.Cells[3].Value.ToString();
                        break;

                    case "dataGridViewPrescriptions":
                        textBoxPrescriptionID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        var petID = dataGridViewRow.Cells[1].Value.ToString();
                        string queryPet = $"SELECT Name FROM Pets WHERE PetID = {petID}";
                        SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultPet = commandPet.ExecuteScalar();
                        textBoxPetIDPrescriptions.Text = resultPet.ToString();
                        var vetID = dataGridViewRow.Cells[2].Value.ToString();
                        string queryVet = $"SELECT FullName FROM Veterinarians WHERE VetID = {vetID}";
                        SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                        object resultVet = commandVet.ExecuteScalar();
                        textBoxVetIDPrescriptions.Text = resultVet.ToString();
                        var medicationID = dataGridViewRow.Cells[3].Value.ToString();
                        string queryMedication = $"SELECT Name FROM Medications WHERE MedicationID = {medicationID}";
                        SqlCommand commandMedication = new(queryMedication, dataBase.GetConnection());
                        object resultMedication = commandMedication.ExecuteScalar();
                        textBoxMedicationIDPrescriptions.Text = resultMedication.ToString();
                        textBoxDosage.Text = dataGridViewRow.Cells[4].Value.ToString();
                        textBoxInstructions.Text = dataGridViewRow.Cells[5].Value.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Search() вызывается при вводе текста в строку
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        string queryClients = $"SELECT * FROM Clients WHERE CONCAT(ClientID, FullName, Phone, Email, Address, INN, RegistrationDate) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdClients = new(queryClients, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerClients = cmdClients.ExecuteReader();
                        while (readerClients.Read())
                        {
                            ReadSingleRow(dataGridView, readerClients);
                        }
                        readerClients.Close();
                        break;

                    case "dataGridViewPets":
                        string queryPets = $"SELECT * FROM Pets WHERE CONCAT(PetID, Name, Species, Breed, BirthDate, OwnerID) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdPets = new(queryPets, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerPets = cmdPets.ExecuteReader();
                        while (readerPets.Read())
                        {
                            ReadSingleRow(dataGridView, readerPets);
                        }
                        readerPets.Close();
                        break;

                    case "dataGridViewVeterinarians":
                        string queryVets = $"SELECT * FROM Veterinarians WHERE CONCAT(VetID, FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmployment, PostID, GenderID) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdVets = new(queryVets, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerVets = cmdVets.ExecuteReader();
                        while (readerVets.Read())
                        {
                            ReadSingleRow(dataGridView, readerVets);
                        }
                        readerVets.Close();
                        break;

                    case "dataGridViewServices":
                        string queryServices = $"SELECT * FROM Services WHERE CONCAT(ServiceID, Name, Price) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdServices = new(queryServices, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerServices = cmdServices.ExecuteReader();
                        while (readerServices.Read())
                        {
                            ReadSingleRow(dataGridView, readerServices);
                        }
                        readerServices.Close();
                        break;

                    case "dataGridViewInvoices":
                        string queryInvoices = $"SELECT * FROM Invoices WHERE CONCAT(InvoiceID, ClientID, TotalAmount, InvoiceDate, Paid) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdInvoices = new(queryInvoices, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerInvoices = cmdInvoices.ExecuteReader();
                        while (readerInvoices.Read())
                        {
                            ReadSingleRow(dataGridView, readerInvoices);
                        }
                        readerInvoices.Close();
                        break;

                    case "dataGridViewPayments":
                        string queryPayments = $"SELECT * FROM Payments WHERE CONCAT(PaymentID, InvoiceID, Amount, PaymentDate, PaymentMethod) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdPayments = new(queryPayments, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerPayments = cmdPayments.ExecuteReader();
                        while (readerPayments.Read())
                        {
                            ReadSingleRow(dataGridView, readerPayments);
                        }
                        readerPayments.Close();
                        break;

                    case "dataGridViewMedications":
                        string queryMeds = $"SELECT * FROM Medications WHERE CONCAT(MedicationID, Name, Description, Price) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdMeds = new(queryMeds, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerMeds = cmdMeds.ExecuteReader();
                        while (readerMeds.Read())
                        {
                            ReadSingleRow(dataGridView, readerMeds);
                        }
                        readerMeds.Close();
                        break;

                    case "dataGridViewPrescriptions":
                        string queryPrescriptions = $"SELECT * FROM Prescriptions WHERE CONCAT(PrescriptionID, PetID, VetID, MedicationID, Dosage, Instructions) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdPrescriptions = new(queryPrescriptions, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerPrescriptions = cmdPrescriptions.ExecuteReader();
                        while (readerPrescriptions.Read())
                        {
                            ReadSingleRow(dataGridView, readerPrescriptions);
                        }
                        readerPrescriptions.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRow() вызывается при удалении строки
        /// </summary>
        /// <param name="dataGridView"></param>
        private static void DeleteRow(DataGridView dataGridView)
        {
            try
            {
                int index = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows[index].Visible = false;
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[7].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[7].Value = RowState.Deleted;
                        break;

                    case "dataGridViewPets":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                        break;

                    case "dataGridViewVeterinarians":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[12].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[12].Value = RowState.Deleted;
                        break;

                    case "dataGridViewServices":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;

                    case "dataGridViewInvoices":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;

                    case "dataGridViewPayments":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMedications":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewPrescriptions":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBase() вызывается при обновлении базы данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void UpdateBase(DataGridView dataGridView)
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridView.Rows.Count; index++)
                {
                    switch (dataGridView.Name)
                    {
                        case "dataGridViewClients":
                            var rowStateClients = (RowState)dataGridView.Rows[index].Cells[7].Value;
                            if (rowStateClients == RowState.Existed)
                                continue;
                            if (rowStateClients == RowState.Deleted)
                            {
                                var clientID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Clients WHERE ClientID = '{clientID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateClients == RowState.Modified)
                            {
                                var clientID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var address = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var inn = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var registrationDate = dataGridView.Rows[index].Cells[6].Value.ToString();
                                var updateQuery = $"UPDATE Clients SET FullName = '{fullName}', Phone = '{phone}', Email = '{email}', Address = '{address}', INN = '{inn}', RegistrationDate = '{registrationDate}' WHERE ClientID = '{clientID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateClients == RowState.New)
                            {
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var address = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var inn = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var registrationDate = dataGridView.Rows[index].Cells[6].Value.ToString();
                                var insertQuery = $"INSERT INTO Clients (FullName, Phone, Email, Address, INN, RegistrationDate) VALUES ('{fullName}', '{phone}', '{email}', '{address}', '{inn}', '{registrationDate}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewPets":
                            var rowStatePets = (RowState)dataGridView.Rows[index].Cells[6].Value;
                            if (rowStatePets == RowState.Existed)
                                continue;
                            if (rowStatePets == RowState.Deleted)
                            {
                                var petID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Pets WHERE PetID = '{petID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePets == RowState.Modified)
                            {
                                var petID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var species = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var breed = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var ownerID = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var updateQuery = $"UPDATE Pets SET Name = '{name}', Species = '{species}', Breed = '{breed}', BirthDate = '{birthDate}', OwnerID = '{ownerID}' WHERE PetID = '{petID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePets == RowState.New)
                            {
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var species = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var breed = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var ownerID = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var insertQuery = $"INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES ('{name}', '{species}', '{breed}', '{birthDate}', '{ownerID}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewVeterinarians":
                            var rowStateVets = (RowState)dataGridView.Rows[index].Cells[12].Value;
                            if (rowStateVets == RowState.Existed)
                                continue;

                            if (rowStateVets == RowState.Deleted)
                            {
                                var vetID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Veterinarians WHERE VetID = '{vetID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateVets == RowState.Modified)
                            {
                                var vetID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var birthPlace = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var passportSeries = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var passportNumber = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[6].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[7].Value.ToString();
                                var inn = dataGridView.Rows[index].Cells[8].Value.ToString();
                                var dateOfEmployment = dataGridView.Rows[index].Cells[9].Value.ToString();
                                var postID = dataGridView.Rows[index].Cells[10].Value.ToString();
                                var genderID = dataGridView.Rows[index].Cells[11].Value.ToString();
                                var updateQuery = $"UPDATE Veterinarians SET FullName = '{fullName}', BirthDate = '{birthDate}', BirthPlace = '{birthPlace}', PassportSeries = '{passportSeries}', PassportNumber = '{passportNumber}', Phone = '{phone}', Email = '{email}', INN = '{inn}', DateOfEmployment = '{dateOfEmployment}', PostID = '{postID}', GenderID = '{genderID}' WHERE VetID = '{vetID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateVets == RowState.New)
                            {
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var birthPlace = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var passportSeries = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var passportNumber = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[6].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[7].Value.ToString();
                                var inn = dataGridView.Rows[index].Cells[8].Value.ToString();
                                var dateOfEmployment = dataGridView.Rows[index].Cells[9].Value.ToString();
                                var postID = dataGridView.Rows[index].Cells[10].Value.ToString();
                                var genderID = dataGridView.Rows[index].Cells[11].Value.ToString();
                                var insertQuery = $"INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmoloyment, PostID, GenderID) VALUES ('{fullName}', '{birthDate}', '{birthPlace}', '{passportSeries}', '{passportNumber}', '{phone}', '{email}', '{inn}', '{dateOfEmployment}', '{postID}', '{genderID}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewServices":
                            var rowStateServices = (RowState)dataGridView.Rows[index].Cells[3].Value;
                            if (rowStateServices == RowState.Existed)
                                continue;
                            if (rowStateServices == RowState.Deleted)
                            {
                                var serviceID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Services WHERE ServiceID = '{serviceID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateServices == RowState.Modified)
                            {
                                var serviceID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var serviceName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var price = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var updateQuery = $"UPDATE Services SET ServiceName = '{serviceName}', Price = '{price}' WHERE ServiceID = '{serviceID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateServices == RowState.New)
                            {
                                var serviceName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var price = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var insertQuery = $"INSERT INTO Services (ServiceName, Price) VALUES ('{serviceName}', '{price}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewInvoices":
                            var rowStateInvoices = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateInvoices == RowState.Existed)
                                continue;
                            if (rowStateInvoices == RowState.Deleted)
                            {
                                var invoiceID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Invoices WHERE InvoiceID = '{invoiceID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateInvoices == RowState.Modified)
                            {
                                var invoiceID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var clientID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var totalAmount = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var invoiceDate = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var paid = Convert.ToBoolean(dataGridView.Rows[index].Cells[4].Value) ? 1 : 0;
                                var updateQuery = $"UPDATE Invoices SET ClientID = '{clientID}', TotalAmount = '{totalAmount}', InvoiceDate = '{invoiceDate}', Paid = '{paid}' WHERE InvoiceID = '{invoiceID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateInvoices == RowState.New)
                            {
                                var clientID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var totalAmount = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var invoiceDate = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var paid = Convert.ToBoolean(dataGridView.Rows[index].Cells[4].Value) ? 1 : 0;
                                var insertQuery = $"INSERT INTO Invoices (ClientID, TotalAmount, InvoiceDate, Paid) VALUES ('{clientID}', '{totalAmount}', '{invoiceDate}' '{paid}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewPayments":
                            var rowStatePayments = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStatePayments == RowState.Existed)
                                continue;
                            if (rowStatePayments == RowState.Deleted)
                            {
                                var paymentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Payments WHERE PaymentID = '{paymentID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePayments == RowState.Modified)
                            {
                                var paymentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var invoiceID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var amount = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var paymentDate = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var method = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var updateQuery = $"UPDATE Payments SET InvoiceID = '{invoiceID}', Amount = '{amount}', PaymentDate = '{paymentDate}', PaymentMethod = '{method}' WHERE PaymentID = '{paymentID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePayments == RowState.New)
                            {
                                var invoiceID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var amount = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var paymentDate = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var method = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var insertQuery = $"INSERT INTO Payments (InvoiceID, Amount, PaymentMethod) VALUES ('{invoiceID}', '{amount}', '{method}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewMedications":
                            var rowStateMedications = (RowState)dataGridView.Rows[index].Cells[4].Value;
                            if (rowStateMedications == RowState.Existed)
                                continue;
                            if (rowStateMedications == RowState.Deleted)
                            {
                                var medicationID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Medications WHERE MedicationID = '{medicationID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateMedications == RowState.Modified)
                            {
                                var medicationID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var price = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var updateQuery = $"UPDATE Medications SET Name = '{name}', Description = '{description}', Price = '{price}' WHERE MedicationID = '{medicationID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateMedications == RowState.New)
                            {
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var price = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var insertQuery = $"INSERT INTO Medications (Name, Description, Price) VALUES ('{name}', '{description}', '{price}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewPrescriptions":
                            var rowStatePrescriptions = (RowState)dataGridView.Rows[index].Cells[6].Value;
                            if (rowStatePrescriptions == RowState.Existed)
                                continue;

                            if (rowStatePrescriptions == RowState.Deleted)
                            {
                                var prescriptionID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Prescriptions WHERE PrescriptionID = '{prescriptionID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePrescriptions == RowState.Modified)
                            {
                                var prescriptionID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var petID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var vetID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var medicationID = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var dosage = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var instructions = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var updateQuery = $"UPDATE Prescriptions SET PetID = '{petID}', VetID = '{vetID}', MedicationID = '{medicationID}', Dosage = '{dosage}', Instructions = '{instructions}' WHERE PrescriptionID = '{prescriptionID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStatePrescriptions == RowState.New)
                            {
                                var petID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var vetID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var medicationID = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var dosage = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var instructions = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var insertQuery = $"INSERT INTO Prescriptions (PetID, VetID, MedicationID, Dosage, Instructions) VALUES ('{petID}', '{vetID}', '{medicationID}', '{dosage}', '{instructions}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;
                    }
                }
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

        /// <summary>
        /// Change() вызывается при изменении таблиц в базе данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Change(DataGridView dataGridView)
        {
            try
            {
                var selectedRowIndex = dataGridView.CurrentCell.RowIndex;
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        var clientID = textBoxClientID.Text;
                        var fullName = textBoxFullNameClients.Text;
                        var phone = maskedTextBoxPhoneClients.Text;
                        var email = textBoxEmailClients.Text;
                        var address = textBoxAddress.Text;
                        var inn = textBoxINNClients.Text;
                        var registrationDate = dateTimePickerRegistrationDate.Value;
                        dataGridView.Rows[selectedRowIndex].SetValues(clientID, fullName, phone, email, address, inn, registrationDate);
                        dataGridView.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                        break;

                    case "dataGridViewPets":
                        var petID = textBoxPetID.Text;
                        var name = textBoxNamePets.Text;
                        var species = textBoxSpecies.Text;
                        var breed = textBoxBreed.Text;
                        var birthDate = dateTimePickerBirthDatePets.Value;
                        var ownerLogin = textBoxOwnerID.Text;
                        string queryOwner = $"SELECT ClientID FROM Clients WHERE FullName = '{ownerLogin}'";
                        SqlCommand commandOwner = new(queryOwner, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultOwner = commandOwner.ExecuteScalar();
                        var ownerID = resultOwner?.ToString() ?? "0";
                        dataGridView.Rows[selectedRowIndex].SetValues(petID, name, species, breed, birthDate, ownerID);
                        dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                        break;

                    case "dataGridViewVeterinarians":
                        var vetID = textBoxVetID.Text;
                        var fullNameVet = textBoxFullNameVeterinarians.Text;
                        var birthDateVet = dateTimePickerBirthDateVeterinarians.Value;
                        var birthPlace = textBoxBirthPlace.Text;
                        var passportSeries = textBoxPassportSeries.Text;
                        var passportNumber = textBoxPassportNumber.Text;
                        var phoneVet = maskedTextBoxPhoneVeterinarians.Text;
                        var emailVet = textBoxEmailVeterinarians.Text;
                        var innVet = textBoxINNVeterinarians.Text;
                        var dateOfEmployement = dateTimePickerDateOfEmployment.Value;
                        string queryGender = $"SELECT GenderID FROM Genders WHERE Gender = '{comboBoxGender.Text}'";
                        SqlCommand commandGender = new(queryGender, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultGender = commandGender.ExecuteScalar();
                        var genderID = resultGender?.ToString() ?? "0";
                        string queryPost = $"SELECT PostID FROM Posts WHERE Post = '{comboBoxPost.Text}'";
                        SqlCommand commandPost = new(queryPost, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultPost = commandPost.ExecuteScalar();
                        var postID = resultPost?.ToString() ?? "0";
                        dataGridView.Rows[selectedRowIndex].SetValues(vetID, fullNameVet, birthDateVet, birthPlace, passportSeries, passportNumber, phoneVet, emailVet, innVet, dateOfEmployement, genderID, postID);
                        dataGridView.Rows[selectedRowIndex].Cells[12].Value = RowState.Modified;
                        break;

                    case "dataGridViewServices":
                        var serviceID = textBoxServiceID.Text;
                        var serviceName = textBoxServiceName.Text;
                        var price = textBoxPriceServices.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(serviceID, serviceName, price);
                        dataGridView.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                        break;

                    case "dataGridViewInvoices":
                        var invoiceID = textBoxInvoiceID.Text;
                        var clientLogin = textBoxClientIDInvoices.Text;
                        string queryClient = $"SELECT ClientID FROM Clients WHERE FullName = '{clientLogin}'";
                        SqlCommand commandClient = new(queryClient, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultClient = commandClient.ExecuteScalar();
                        var clientIDInvoice = resultClient?.ToString() ?? "0";
                        var totalAmount = textBoxTotalAmount.Text;
                        var invoiceDate = dateTimePickerInvoiceDate.Value;
                        var paid = checkBoxPaid.Checked ? "True" : "False";
                        dataGridView.Rows[selectedRowIndex].SetValues(invoiceID, clientIDInvoice, totalAmount, invoiceDate, paid);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;

                    case "dataGridViewPayments":
                        var paymentID = textBoxPaymentID.Text;
                        var invoiceIDPayment = textBoxInvoiceIDPayments.Text;
                        var amount = textBoxAmount.Text;
                        var paymentDate = dateTimePickerPaymentDate.Value;
                        var paymentMethodName = comboBoxPaymentMethod.Text;
                        string queryPaymentMethod = $"SELECT PaymentMethodID FROM PaymentMethods WHERE PaymentMethod = '{paymentMethodName}'";
                        SqlCommand commandPaymentMethod = new(queryPaymentMethod, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultPaymentMethod = commandPaymentMethod.ExecuteScalar();
                        var paymentMethodID = resultPaymentMethod?.ToString() ?? "0";
                        dataGridView.Rows[selectedRowIndex].SetValues(paymentID, invoiceIDPayment, amount, paymentDate, paymentMethodID);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;

                    case "dataGridViewMedications":
                        var medicationID = textBoxMedicationID.Text;
                        var nameMed = textBoxNameMedications.Text;
                        var description = textBoxDescription.Text;
                        var priceMed = textBoxPriceMedications.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(medicationID, nameMed, description, priceMed);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewPrescriptions":
                        var prescriptionID = textBoxPrescriptionID.Text;
                        var petName = textBoxPetIDPrescriptions.Text;
                        string queryPet = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                        SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        object resultPet = commandPet.ExecuteScalar();
                        var petIDPres = resultPet?.ToString() ?? "0";
                        var vetName = textBoxVetIDPrescriptions.Text;
                        string queryVet = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                        SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                        object resultVet = commandVet.ExecuteScalar();
                        var vetIDPres = resultVet?.ToString();
                        var medName = textBoxMedicationIDPrescriptions.Text;
                        string queryMed = $"SELECT MedicationID FROM Medications WHERE Name = '{medName}'";
                        SqlCommand commandMed = new(queryMed, dataBase.GetConnection());
                        object resultMed = commandMed.ExecuteScalar();
                        var medicationIDPres = resultMed?.ToString() ?? "0";
                        var dosage = textBoxDosage.Text;
                        var instructions = textBoxInstructions.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(prescriptionID, petIDPres, vetIDPres, medicationIDPres, dosage, instructions);
                        dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToWord() вызывается при экспорте в Word
        /// </summary>
        /// <param name="dataGridView"></param>
        private void ExportToWord(DataGridView dataGridView)
        {
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = true
                };
                Document doc = wordApp.Documents.Add();
                Paragraph title = doc.Paragraphs.Add();
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        title.Range.Text = "Данные клиентов";
                        break;

                    case "dataGridViewPets":
                        title.Range.Text = "Данные питомцев";
                        break;

                    case "dataGridViewVeterinarians":
                        title.Range.Text = "Данные ветеринаров";
                        break;

                    case "dataGridViewServices":
                        title.Range.Text = "Данные услуг";
                        break;

                    case "dataGridViewInvoices":
                        title.Range.Text = "Данные счетов";
                        break;

                    case "dataGridViewPayments":
                        title.Range.Text = "Данные платежей";
                        break;

                    case "dataGridViewMedications":
                        title.Range.Text = "Данные лекарств";
                        break;

                    case "dataGridViewPrescriptions":
                        title.Range.Text = "Данные записей в книжке";
                        break;
                }
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 14;
                title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();
                Table table = doc.Tables.Add(title.Range, dataGridView.RowCount + 1, dataGridView.ColumnCount - 1);
                for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                {
                    table.Cell(1, col + 1).Range.Text = dataGridView.Columns[col].HeaderText;
                }
                for (int row = 0; row < dataGridView.RowCount; row++)
                {
                    for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                    {
                        table.Cell(row + 2, col + 1).Range.Text = dataGridView[col, row].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToExcel() вызывается при экспорте в Excel
        /// </summary>
        /// <param name="dataGridView"></param>
        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                Excel.Application excelApp = new()
                {
                    Visible = true
                };
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                string title = "";
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        title = "Данные клиентов";
                        break;

                    case "dataGridViewPets":
                        title = "Данные питомцев";
                        break;

                    case "dataGridViewVeterinarians":
                        title = "Данные ветеринаров";
                        break;

                    case "dataGridViewServices":
                        title = "Данные услуг";
                        break;

                    case "dataGridViewInvoices":
                        title = "Данные счетов";
                        break;

                    case "dataGridViewPayments":
                        title = "Данные платежей";
                        break;

                    case "dataGridViewMedications":
                        title = "Данные лекарств";
                        break;

                    case "dataGridViewPrescriptions":
                        title = "Данные записей в книжке";
                        break;
                }
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dataGridView.ColumnCount - 1]];
                titleRange.Merge();
                titleRange.Value = title;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                for (int col = 0; col < dataGridView.ColumnCount; col++)
                {
                    worksheet.Cells[2, col + 1] = dataGridView.Columns[col].HeaderText;
                }
                for (int row = 0; row < dataGridView.RowCount; row++)
                {
                    for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                    {
                        worksheet.Cells[row + 3, col + 1] = dataGridView[col, row].Value.ToString();
                        Excel.Range dataRange = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[dataGridView.RowCount + 2, dataGridView.ColumnCount]];
                        dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        dataRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ExportToTXT() вызывается при экспорте в .txt
        /// </summary>
        /// <param name="dataGridView"></param>
        private static void ExportToTXT(DataGridView dataGridView)
        {
            string text = "";
            switch (dataGridView.Name)
            {
                case "dataGridViewClients":
                    text += "Данные клиентов\n\n";
                    break;

                case "dataGridViewPets":
                    text += "Данные питомцев\n\n";
                    break;

                case "dataGridViewVeterinarians":
                    text += "Данные ветеринаров\n\n";
                    break;

                case "dataGridViewServices":
                    text += "Данные услуг\n\n";
                    break;

                case "dataGridViewInvoices":
                    text += "Данные счетов\n\n";
                    break;

                case "dataGridViewPayments":
                    text += "Данные платежей\n\n";
                    break;

                case "dataGridViewMedications":
                    text += "Данные лекарств\n\n";
                    break;

                case "dataGridViewPrescriptions":
                    text += "Данные записей в книжке\n\n";
                    break;
            }
            for (int col = 0; col < dataGridView.ColumnCount; col++)
            {
                text += dataGridView.Columns[col].HeaderText + "\t";
            }
            text += "\n";
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                for (int col = 0; col < dataGridView.ColumnCount - 1; col++)
                {
                    text += dataGridView[col, row].Value?.ToString() + "\t";
                }
                text += "\n";
            }
            string filePath = "данные.txt";
            File.WriteAllText(filePath, text);
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        /// <summary>
        /// Reports() вызывается при создании отчетов
        /// </summary>
        /// <param name="report"></param>
        private void Reports(string report)
        {
            dataBase.OpenConnection();
            var wordApp = new Application { Visible = true };
            Document doc = wordApp.Documents.Add();
            Paragraph title = doc.Paragraphs.Add();
            string query = "";
            switch (report)
            {
                case "Payments":
                    title.Range.Text = "Отчет по доходам клиники за период";
                    query = @"SELECT
                                c.FullName AS Client,
                                c.Phone,
                                c.Email,
                                p.Name AS PetName,
                                p.Species,
                                p.Breed,
                                COUNT(DISTINCT i.InvoiceID) AS VisitsCount,
                                SUM(i.TotalAmount) AS TotalSpent,
                                MAX(i.InvoiceDate) AS LastVisitDate
                            FROM
                                Clients c
                            JOIN
                                Pets p ON c.ClientID = p.OwnerID
                            LEFT JOIN
                                Invoices i ON c.ClientID = i.ClientID
                            LEFT JOIN
                                Payments pay ON i.InvoiceID = pay.InvoiceID
                            WHERE
                                i.Paid = 1
                                AND i.InvoiceDate BETWEEN '2023-01-01' AND GetDate()
                            GROUP BY
                                c.FullName,
                                c.Phone,
                                c.Email,
                                p.Name,
                                p.Species,
                                p.Breed
                            ORDER BY
                                TotalSpent DESC;";
                    break;

                case "Veterinarians":
                    title.Range.Text = "Отчет по активности ветеринаров";
                    query = @"SELECT
                                v.FullName AS Veterinarian,
                                p.Post AS Position,
                                COUNT(DISTINCT pr.PrescriptionID) AS PrescriptionsCount,
                                COUNT(DISTINCT pr.PetID) AS UniquePatientsCount,
                                COUNT(DISTINCT pr.MedicationID) AS UniqueMedicationsPrescribed
                            FROM
                                Veterinarians v
                            JOIN
                                Posts p ON v.PostID = p.PostID
                            LEFT JOIN
                                Prescriptions pr ON v.VetID = pr.VetID
                            LEFT JOIN
                                Invoices i ON pr.PetID = i.ClientID -- Связь через клиента/владельца питомца
                            WHERE
                                i.InvoiceDate BETWEEN '2023-01-01' AND GETDATE() -- Используем дату из счетов
                                OR pr.PrescriptionID IS NOT NULL -- Учитываем все рецепты
                            GROUP BY
                                v.FullName,
                                p.Post
                            ORDER BY
                                PrescriptionsCount DESC;";
                    break;

                case "Clients":
                    title.Range.Text = "Отчет по клиентам и их питомцам";
                    query = @"SELECT
                                c.FullName AS Client,
                                c.Phone,
                                c.Email,
                                p.Name AS PetName,
                                p.Species,
                                p.Breed,
                                COUNT(DISTINCT i.InvoiceID) AS VisitsCount,
                                SUM(i.TotalAmount) AS TotalSpent,
                                MAX(i.InvoiceDate) AS LastVisitDate
                            FROM
                                Clients c
                            JOIN
                                Pets p ON c.ClientID = p.OwnerID
                            LEFT JOIN
                                Invoices i ON c.ClientID = i.ClientID
                            LEFT JOIN
                                Payments pay ON i.InvoiceID = pay.InvoiceID
                            WHERE
                                i.Paid = 1
                                AND i.InvoiceDate BETWEEN '2023-01-01' AND GetDate()
                            GROUP BY
                                c.FullName,
                                c.Phone,
                                c.Email,
                                p.Name,
                                p.Species,
                                p.Breed
                            ORDER BY
                                TotalSpent DESC;";
                    break;
            }
            SqlCommand command = new(query, dataBase.GetConnection());
            SqlDataAdapter adapter = new(command);
            System.Data.DataTable dataTable = new();
            adapter.Fill(dataTable);
            dataBase.CloseConnection();
            title.Range.Font.Bold = 1;
            title.Range.Font.Size = 14;
            title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();
            Table table = doc.Tables.Add(title.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);
            table.Borders.Enable = 1;
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                table.Cell(1, col + 1).Range.Text = dataTable.Columns[col].ColumnName;
            }
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    table.Cell(row + 2, col + 1).Range.Text = dataTable.Rows[row][col].ToString();
                }
            }
        }

        /// <summary>
        /// ButtonRefresh_Click() вызывается при нажатии на кнопку обновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDataGrid(dataGridViewClients, "Clients");
                RefreshDataGrid(dataGridViewPets, "Pets");
                RefreshDataGrid(dataGridViewVeterinarians, "Veterinarians");
                RefreshDataGrid(dataGridViewServices, "Services");
                RefreshDataGrid(dataGridViewInvoices, "Invoices");
                RefreshDataGrid(dataGridViewPayments, "Payments");
                RefreshDataGrid(dataGridViewMedications, "Medications");
                RefreshDataGrid(dataGridViewPrescriptions, "Prescriptions");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonClear_Click() вызывается при нажатии на кнопку очистки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewClient_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewClient_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormClients addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewPet_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewPet_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormPets addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewVeterinarian_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormVeterinarians addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewService_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewService_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormServices addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewInvoice_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormInvoices addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewPayment_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewPayment_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormPayments addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMedication_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMedication_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMedications addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewPrescription_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormPrescriptions addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteClient_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewClients);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeletePet_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePet_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewPets);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteVeterinarian_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewVeterinarians);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteService_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewServices);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteInvoice_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewInvoices);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeletePayment_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePayment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewPayments);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMedication_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMedication_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMedications);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeletePrescription_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeletePrescription_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewPrescriptions);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeClient_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeClient_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewClients);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangePet_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePet_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewPets);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeVeterinarian_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewVeterinarians);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeService_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeService_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewServices);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeInvoice_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewInvoices);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangePayment_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePayment_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewPayments);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMedication_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMedication_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMedications);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangePrescription_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePrescription_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewPrescriptions);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveClient_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewClients);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSavePet_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSavePet_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewPets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveVeterinarian_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewVeterinarians);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveService_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    UpdateBase(dataGridViewServices);
                }
                else
                {
                    MessageBox.Show("У вас недостаточно прав!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveInvoice_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewInvoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSavePayment_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSavePayment_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMedication_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMedication_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewMedications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSavePrescription_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSavePrescription_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewPrescriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordClient_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordClient_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordPet_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordPet_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewPets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordVeterinarian_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewVeterinarians);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordService_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordService_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewServices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordInvoice_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewInvoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordPayment_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordPayment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMedication_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMedication_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMedications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordPrescription_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewPrescriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelClient_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelClient_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelPet_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelPet_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewPets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelVeterinarian_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewVeterinarians);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelService_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelService_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewServices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelInvoice_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewInvoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelPayment_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelPayment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMedication_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMedication_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMedications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelPrescription_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewPrescriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTClient_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTClient_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTPet_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTPet_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewPets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTVeterinarian_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTVeterinarian_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewVeterinarians);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTService_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTService_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewServices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTInvoice_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewInvoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTPayment_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTPayment_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTMedication_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTMedication_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewMedications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonTXTPrescription_Click() вызывается при нажатии на кнопку "Вывод в TXT" на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTXTPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToTXT(dataGridViewPrescriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewClients_CellClick() вызывается при нажатии на ячейку на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewClients, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewPets_CellClick() вызывается при нажатии на ячейку на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewPets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewPets, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewVeterinarians_CellClick() вызывается при нажатии на ячейку на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewVeterinarians_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewVeterinarians, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewServices_CellClick() вызывается при нажатии на ячейку на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewServices, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewInvoices_CellClick() вызывается при нажатии на ячейку на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewInvoices, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewPayments_CellClick() вызывается при нажатии на ячейку на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewPayments, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMedications_CellClick() вызывается при нажатии на ячейку на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMedications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMedications, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewPrescriptions_CellClick() вызывается при нажатии на ячейку на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewPrescriptions, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchClients_TextChanged() вызывается при изменении текста на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchClients_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchPets_TextChanged() вызывается при изменении текста на вкладке "Питомцы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchPets_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewPets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchVeterinarians_TextChanged() вызывается при изменении текста на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchVeterinarians_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewVeterinarians);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchServices_TextChanged() вызывается при изменении текста на вкладке "Услуги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchServices_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewServices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchInvoices_TextChanged() вызывается при изменении текста на вкладке "Чеки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchInvoices_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewInvoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchPayments_TextChanged() вызывается при изменении текста на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchPayments_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMedications_TextChanged() вызывается при изменении текста на вкладке "Лекарства"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMedications_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMedications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchPrescriptions_TextChanged() вызывается при изменении текста на вкладке "Записи в книжке"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchPrescriptions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewPrescriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonReportClients_Click() вызывается при нажатии на кнопку отчета на вкладке "Клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportClients_Click(object sender, EventArgs e)
        {
            Reports("Clients");
        }

        /// <summary>
        /// ButtonReportVeterinarians_Click() вызывается при нажатии на кнопку отчета на вкладке "Ветеринары"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportVeterinarians_Click(object sender, EventArgs e)
        {
            Reports("Veterinarians");
        }

        /// <summary>
        /// ButtonReportPayments_Click() вызывается при нажатии на кнопку отчета на вкладке "Оплаты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReportPayments_Click(object sender, EventArgs e)
        {
            Reports("Payments");
        }
    }
}