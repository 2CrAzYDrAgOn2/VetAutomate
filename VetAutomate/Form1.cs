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
                dataGridViewClients.Columns.Add("Номер", "Номер");
                dataGridViewClients.Columns.Add("ФИО", "ФИО");
                dataGridViewClients.Columns.Add("Телефон", "Телефон");
                dataGridViewClients.Columns.Add("Email", "Email");
                dataGridViewClients.Columns.Add("Адрес", "Адрес");
                dataGridViewClients.Columns.Add("ИНН", "ИНН");
                dataGridViewClients.Columns.Add("Дата регистрации", "Дата регистрации");
                dataGridViewClients.Columns.Add("IsNew", String.Empty);
                dataGridViewPets.Columns.Add("Номер", "Номер");
                dataGridViewPets.Columns.Add("Кличка", "Кличка");
                dataGridViewPets.Columns.Add("Вид", "Вид");
                dataGridViewPets.Columns.Add("Порода", "Порода");
                dataGridViewPets.Columns.Add("Дата рождения", "Дата рождения");
                dataGridViewPets.Columns.Add("ID владельца", "ID владельца");
                dataGridViewPets.Columns.Add("IsNew", String.Empty);
                dataGridViewVeterinarians.Columns.Add("Номер", "Номер");
                dataGridViewVeterinarians.Columns.Add("ФИО", "ФИО");
                dataGridViewVeterinarians.Columns.Add("Дата рождения", "Дата рождения");
                dataGridViewVeterinarians.Columns.Add("Место рождения", "Место рождения");
                dataGridViewVeterinarians.Columns.Add("Серия паспорта", "Серия паспорта");
                dataGridViewVeterinarians.Columns.Add("Номер паспорта", "Номер паспорта");
                dataGridViewVeterinarians.Columns.Add("Телефон", "Телефон");
                dataGridViewVeterinarians.Columns.Add("Email", "Email");
                dataGridViewVeterinarians.Columns.Add("ИНН", "ИНН");
                dataGridViewVeterinarians.Columns.Add("Дата найма", "Дата найма");
                dataGridViewVeterinarians.Columns.Add("Должность", "Должность");
                dataGridViewVeterinarians.Columns.Add("Пол", "Пол");
                dataGridViewVeterinarians.Columns.Add("IsNew", String.Empty);
                dataGridViewServices.Columns.Add("Номер", "Номер");
                dataGridViewServices.Columns.Add("Услуга", "Услуга");
                dataGridViewServices.Columns.Add("IsNew", String.Empty);
                dataGridViewMedications.Columns.Add("Номер", "Номер");
                dataGridViewMedications.Columns.Add("Название", "Название");
                dataGridViewMedications.Columns.Add("Описание", "Описание");
                dataGridViewMedications.Columns.Add("Количество в наличии", "Количество в наличии");
                dataGridViewMedications.Columns.Add("IsNew", String.Empty);
                dataGridViewMedicationSupplies.Columns.Add("Номер поставки", "Номер поставки");
                dataGridViewMedicationSupplies.Columns.Add("Препарат", "Препарат");
                dataGridViewMedicationSupplies.Columns.Add("Дата поставки", "Дата поставки");
                dataGridViewMedicationSupplies.Columns.Add("Количество", "Количество");
                dataGridViewMedicationSupplies.Columns.Add("Поставщик", "Поставщик");
                dataGridViewMedicationSupplies.Columns.Add("IsNew", String.Empty);
                dataGridViewMedicationUsages.Columns.Add("Номер использования", "Номер использования");
                dataGridViewMedicationUsages.Columns.Add("Питомец", "Питомец");
                dataGridViewMedicationUsages.Columns.Add("Ветеринар", "Ветеринар");
                dataGridViewMedicationUsages.Columns.Add("Препарат", "Препарат");
                dataGridViewMedicationUsages.Columns.Add("Количество", "Количество");
                dataGridViewMedicationUsages.Columns.Add("Цель применения", "Цель применения");
                dataGridViewMedicationUsages.Columns.Add("IsNew", String.Empty);
                dataGridViewServiceUsages.Columns.Add("Номер услуги", "Номер услуги");
                dataGridViewServiceUsages.Columns.Add("Питомец", "Питомец");
                dataGridViewServiceUsages.Columns.Add("Ветеринар", "Ветеринар");
                dataGridViewServiceUsages.Columns.Add("Услуга", "Услуга");
                dataGridViewServiceUsages.Columns.Add("Цель", "Цель");
                dataGridViewServiceUsages.Columns.Add("IsNew", String.Empty);
                HideIsNewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// HideIsNewColumns() вызывается при прятании колонок
        /// </summary>
        private void HideIsNewColumns()
        {
            dataGridViewClients.Columns["IsNew"].Visible = false;
            dataGridViewPets.Columns["IsNew"].Visible = false;
            dataGridViewVeterinarians.Columns["IsNew"].Visible = false;
            dataGridViewServices.Columns["IsNew"].Visible = false;
            dataGridViewMedications.Columns["IsNew"].Visible = false;
            dataGridViewMedicationSupplies.Columns["IsNew"].Visible = false;
            dataGridViewMedicationUsages.Columns["IsNew"].Visible = false;
            dataGridViewServiceUsages.Columns["IsNew"].Visible = false;
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
                textBoxPetID.Text = "";
                textBoxNamePets.Text = "";
                textBoxSpecies.Text = "";
                textBoxBreed.Text = "";
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
                textBoxMedicationID.Text = "";
                textBoxNameMedications.Text = "";
                textBoxDescription.Text = "";
                textBoxQuantityInStock.Text = "";
                textBoxVetID.Text = "";
                textBoxSupplyID.Text = "";
                textBoxSupplyID.Text = "";
                textBoxQuantitySupplied.Text = "";
                textBoxSupplierName.Text = "";
                dateTimePickerSupplyDate.Value = DateTime.Now;
                textBoxMedicationUsageID.Text = "";
                textBoxQuantityUsed.Text = "";
                textBoxPurposeMedicationUsages.Text = "";
                textBoxServiceUsageID.Text = "";
                textBoxPurposeServiceUsages.Text = "";
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
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetString(4), iDataRecord.GetDateTime(5).ToString("yyyy-MM-dd"), RowState.Modified);
                        break;

                    case "dataGridViewPets":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetDateTime(4).ToString("yyyy-MM-dd"), iDataRecord.GetString(5), RowState.Modified);
                        break;

                    case "dataGridViewVeterinarians":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.GetString(3), iDataRecord.GetString(4), iDataRecord.GetString(5), iDataRecord.GetString(6), iDataRecord.GetString(7), iDataRecord.GetString(8), iDataRecord.GetDateTime(9).ToString("yyyy-MM-dd"), iDataRecord.GetString(10), iDataRecord.GetString(11), RowState.Modified);
                        break;

                    case "dataGridViewServices":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "dataGridViewMedications":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetInt32(3), RowState.Modified);
                        break;

                    case "dataGridViewMedicationSupplies":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetDateTime(2).ToString("yyyy-MM-dd"), iDataRecord.GetInt32(3), iDataRecord.GetString(4), RowState.Modified);
                        break;

                    case "dataGridViewMedicationUsages":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetInt32(4), iDataRecord.GetString(5), RowState.Modified);
                        break;

                    case "dataGridViewServiceUsages":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetString(2), iDataRecord.GetString(3), iDataRecord.GetString(4), RowState.Modified);
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
                string queryString = "";

                queryString = tableName switch
                {
                    "Clients" => "SELECT * FROM Clients",
                    "Pets" => @"SELECT p.PetID, p.Name, p.Species, p.Breed, p.BirthDate,
                      c.FullName AS OwnerName
                      FROM Pets p
                      LEFT JOIN Clients c ON p.OwnerID = c.ClientID",
                    "Veterinarians" => @"SELECT v.VetID, v.FullName, v.BirthDate, v.BirthPlace,
                      v.PassportSeries, v.PassportNumber, v.Phone, v.Email, v.INN,
                      v.DateOfEmployment, p.Post, g.Gender
                      FROM Veterinarians v
                      LEFT JOIN Posts p ON v.PostID = p.PostID
                      LEFT JOIN Genders g ON v.GenderID = g.GenderID",
                    "Services" => "SELECT * FROM Services",
                    "Medications" => "SELECT * FROM Medications",
                    "MedicationSupplies" => @"SELECT ms.SupplyID, m.Name AS MedicationName,
                      ms.SupplyDate, ms.QuantitySupplied, ms.SupplierName
                      FROM MedicationSupplies ms
                      LEFT JOIN Medications m ON ms.MedicationID = m.MedicationID",
                    "MedicationUsages" => @"SELECT mu.MedicationUsageID, p.Name AS PetName,
                      v.FullName AS VeterinarianName, m.Name AS MedicationName,
                      mu.QuantityUsed, mu.Purpose
                      FROM MedicationUsages mu
                      LEFT JOIN Pets p ON mu.PetID = p.PetID
                      LEFT JOIN Veterinarians v ON mu.VetID = v.VetID
                      LEFT JOIN Medications m ON mu.MedicationID = m.MedicationID",
                    "ServiceUsages" => @"SELECT su.ServiceUsageID, p.Name AS PetName,
                      v.FullName AS VeterinarianName, s.ServiceName,
                      su.Purpose
                      FROM ServiceUsages su
                      LEFT JOIN Pets p ON su.PetID = p.PetID
                      LEFT JOIN Veterinarians v ON su.VetID = v.VetID
                      LEFT JOIN Services s ON su.ServiceID = s.ServiceID",
                    _ => $"SELECT * FROM {tableName}",
                };
                SqlCommand sqlCommand = new(queryString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow(dataGridView, sqlDataReader);
                }
                sqlDataReader.Close();
                FillAllComboBoxes();
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
                RefreshDataGrid(dataGridViewMedications, "Medications");
                RefreshDataGrid(dataGridViewMedicationSupplies, "MedicationSupplies");
                RefreshDataGrid(dataGridViewMedicationUsages, "MedicationUsages");
                RefreshDataGrid(dataGridViewServiceUsages, "ServiceUsages");
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
                        dateTimePickerRegistrationDate.Text = dataGridViewRow.Cells[5].Value.ToString();
                        panelRecordClients.Visible = true;
                        break;

                    case "dataGridViewPets":
                        textBoxPetID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxNamePets.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxSpecies.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxBreed.Text = dataGridViewRow.Cells[3].Value.ToString();
                        dateTimePickerBirthDatePets.Text = dataGridViewRow.Cells[4].Value.ToString();
                        comboBoxOwnerID.Text = dataGridViewRow.Cells[5].Value.ToString();
                        panelRecordPets.Visible = true;
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
                        comboBoxPost.Text = dataGridViewRow.Cells[10].Value.ToString();
                        comboBoxGender.Text = dataGridViewRow.Cells[11].Value.ToString();
                        panelRecordVeterinarians.Visible = true;
                        break;

                    case "dataGridViewServices":
                        textBoxServiceID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxServiceName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        panelRecordServices.Visible = true;
                        break;

                    case "dataGridViewMedications":
                        textBoxMedicationID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxNameMedications.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxDescription.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxQuantityInStock.Text = dataGridViewRow.Cells[3].Value.ToString();
                        panelRecordMedications.Visible = true;
                        break;

                    case "dataGridViewMedicationSupplies":
                        textBoxSupplyID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        comboBoxMedicationIDMedicationSuppplies.Text = dataGridViewRow.Cells[1].Value.ToString();
                        dateTimePickerSupplyDate.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxQuantitySupplied.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxSupplierName.Text = dataGridViewRow.Cells[4].Value.ToString();
                        panelRecordMedicationSupplies.Visible = true;
                        break;

                    case "dataGridViewMedicationUsages":
                        textBoxMedicationUsageID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        comboBoxPetIDMedicationUsages.Text = dataGridViewRow.Cells[1].Value.ToString();
                        comboBoxVetIDMedicationUsages.Text = dataGridViewRow.Cells[2].Value.ToString();
                        comboBoxMedicationIDMedicationUsages.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxQuantityUsed.Text = dataGridViewRow.Cells[4].Value.ToString();
                        textBoxPurposeMedicationUsages.Text = dataGridViewRow.Cells[5].Value.ToString();
                        panelRecordMedicationUsages.Visible = true;
                        break;

                    case "dataGridViewServiceUsages":
                        textBoxServiceUsageID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        comboBoxPetIDServiceUsages.Text = dataGridViewRow.Cells[1].Value.ToString();
                        comboBoxVetIDServiceUsages.Text = dataGridViewRow.Cells[2].Value.ToString();
                        comboBoxServiceIDServiceUsages.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxPurposeServiceUsages.Text = dataGridViewRow.Cells[4].Value.ToString();
                        panelRecordServiceUsages.Visible = true;
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
                        string queryClients = $"SELECT * FROM Clients WHERE CONCAT(ClientID, FullName, Phone, Email, Address, RegistrationDate) LIKE '%{textBoxSearchClients.Text}%'";
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
                        string queryServices = $"SELECT * FROM Services WHERE CONCAT(ServiceID, Name) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdServices = new(queryServices, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerServices = cmdServices.ExecuteReader();
                        while (readerServices.Read())
                        {
                            ReadSingleRow(dataGridView, readerServices);
                        }
                        readerServices.Close();
                        break;

                    case "dataGridViewMedications":
                        string queryMeds = $"SELECT * FROM Medications WHERE CONCAT(MedicationID, Name, Description, QuantityInStock) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdMeds = new(queryMeds, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerMeds = cmdMeds.ExecuteReader();
                        while (readerMeds.Read())
                        {
                            ReadSingleRow(dataGridView, readerMeds);
                        }
                        readerMeds.Close();
                        break;

                    case "dataGridViewMedicationSupplies":
                        string querySupplies = $"SELECT * FROM MedicationSupplies WHERE CONCAT(SupplyID, MedicationID, SupplyDate, QuantitySupplied, SupplierName) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdSupplies = new(querySupplies, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerSupplies = cmdSupplies.ExecuteReader();
                        while (readerSupplies.Read())
                        {
                            ReadSingleRow(dataGridView, readerSupplies);
                        }
                        readerSupplies.Close();
                        break;

                    case "dataGridViewMedicationUsages":
                        string queryMedUsages = $"SELECT * FROM MedicationUsages WHERE CONCAT(MedicationUsageID, PetID, VetID, MedicationID, QuantityUsed, Purpose) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdMedUsages = new(queryMedUsages, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerMedUsages = cmdMedUsages.ExecuteReader();
                        while (readerMedUsages.Read())
                        {
                            ReadSingleRow(dataGridView, readerMedUsages);
                        }
                        readerMedUsages.Close();
                        break;

                    case "dataGridViewServiceUsages":
                        string queryServiceUsages = $"SELECT * FROM ServiceUsages WHERE CONCAT(ServiceUsageID, PetID, VetID, ServiceID, Purpose) LIKE '%{textBoxSearchClients.Text}%'";
                        SqlCommand cmdServiceUsages = new(queryServiceUsages, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader readerServiceUsages = cmdServiceUsages.ExecuteReader();
                        while (readerServiceUsages.Read())
                        {
                            ReadSingleRow(dataGridView, readerServiceUsages);
                        }
                        readerServiceUsages.Close();
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
                DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите удалить эту запись?",
            "Подтверждение удаления",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                int index = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows[index].Visible = false;
                switch (dataGridView.Name)
                {
                    case "dataGridViewClients":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
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
                            dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMedications":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMedicationSupplies":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;

                    case "dataGridViewMedicationUsages":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[6].Value = RowState.Deleted;
                        break;

                    case "dataGridViewServiceUsages":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
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
                            var rowStateClients = (RowState)dataGridView.Rows[index].Cells[6].Value;
                            if (rowStateClients == RowState.Existed)
                                continue;
                            if (rowStateClients == RowState.Deleted)
                            {
                                var clientID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM Clients WHERE ClientID = '{clientID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            if (rowStateClients == RowState.Modified)
                            {
                                var clientID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var address = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var registrationDate = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var updateQuery = $"UPDATE Clients SET FullName = '{fullName}', Phone = '{phone}', Email = '{email}', Address = '{address}', RegistrationDate = '{registrationDate}' WHERE ClientID = '{clientID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            if (rowStateClients == RowState.New)
                            {
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var phone = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var email = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var address = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var registrationDate = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var insertQuery = $"INSERT INTO Clients (FullName, Phone, Email, Address, RegistrationDate) VALUES ('{fullName}', '{phone}', '{email}', '{address}', '{registrationDate}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
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
                                FillAllComboBoxes();
                            }
                            if (rowStatePets == RowState.Modified)
                            {
                                var petID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var species = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var breed = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[4].Value.ToString();
                                int? ownerID = null;
                                var ownerName = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                if (!string.IsNullOrEmpty(ownerName))
                                {
                                    var getOwnerIdQuery = $"SELECT ClientID FROM Clients WHERE FullName = '{ownerName}'";
                                    var ownerIdCommand = new SqlCommand(getOwnerIdQuery, dataBase.GetConnection());
                                    var result = ownerIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        ownerID = Convert.ToInt32(result);
                                    }
                                }
                                var updateQuery = $"UPDATE Pets SET Name = '{name}', Species = '{species}', Breed = '{breed}', BirthDate = '{birthDate}', OwnerID = '{ownerID}' WHERE PetID = '{petID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            if (rowStatePets == RowState.New)
                            {
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var species = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var breed = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var birthDate = dataGridView.Rows[index].Cells[4].Value.ToString();
                                int? ownerID = null;
                                var ownerName = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                if (!string.IsNullOrEmpty(ownerName))
                                {
                                    var getOwnerIdQuery = $"SELECT ClientID FROM Clients WHERE FullName = '{ownerName}'";
                                    var ownerIdCommand = new SqlCommand(getOwnerIdQuery, dataBase.GetConnection());
                                    var result = ownerIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        ownerID = Convert.ToInt32(result);
                                    }
                                }
                                var insertQuery = $"INSERT INTO Pets (Name, Species, Breed, BirthDate, OwnerID) VALUES ('{name}', '{species}', '{breed}', '{birthDate}', '{ownerID}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
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
                                FillAllComboBoxes();
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
                                int? postID = null;
                                var postName = dataGridView.Rows[index].Cells[10].Value?.ToString();
                                if (!string.IsNullOrEmpty(postName))
                                {
                                    var getPostIdQuery = $"SELECT PostID FROM Posts WHERE Post = '{postName}'";
                                    var postIdCommand = new SqlCommand(getPostIdQuery, dataBase.GetConnection());
                                    var result = postIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        postID = Convert.ToInt32(result);
                                    }
                                }
                                int? genderID = null;
                                var genderName = dataGridView.Rows[index].Cells[11].Value?.ToString();
                                if (!string.IsNullOrEmpty(genderName))
                                {
                                    var getGenderIdQuery = $"SELECT GenderID FROM Genders WHERE Gender = '{genderName}'";
                                    var genderIdCommand = new SqlCommand(getGenderIdQuery, dataBase.GetConnection());
                                    var result = genderIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        genderID = Convert.ToInt32(result);
                                    }
                                }
                                var updateQuery = $"UPDATE Veterinarians SET FullName = '{fullName}', BirthDate = '{birthDate}', BirthPlace = '{birthPlace}', PassportSeries = '{passportSeries}', PassportNumber = '{passportNumber}', Phone = '{phone}', Email = '{email}', INN = '{inn}', DateOfEmployment = '{dateOfEmployment}', PostID = '{postID}', GenderID = '{genderID}' WHERE VetID = '{vetID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
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
                                int? postID = null;
                                var postName = dataGridView.Rows[index].Cells[10].Value?.ToString();
                                if (!string.IsNullOrEmpty(postName))
                                {
                                    var getPostIdQuery = $"SELECT PostID FROM Posts WHERE Post = '{postName}'";
                                    var postIdCommand = new SqlCommand(getPostIdQuery, dataBase.GetConnection());
                                    var result = postIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        postID = Convert.ToInt32(result);
                                    }
                                }
                                int? genderID = null;
                                var genderName = dataGridView.Rows[index].Cells[11].Value?.ToString();
                                if (!string.IsNullOrEmpty(genderName))
                                {
                                    var getGenderIdQuery = $"SELECT GenderID FROM Genders WHERE Gender = '{genderName}'";
                                    var genderIdCommand = new SqlCommand(getGenderIdQuery, dataBase.GetConnection());
                                    var result = genderIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        genderID = Convert.ToInt32(result);
                                    }
                                }
                                var insertQuery = $"INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmoloyment, PostID, GenderID) VALUES ('{fullName}', '{birthDate}', '{birthPlace}', '{passportSeries}', '{passportNumber}', '{phone}', '{email}', '{inn}', '{dateOfEmployment}', '{postID}', '{genderID}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            break;

                        case "dataGridViewServices":
                            var rowStateServices = (RowState)dataGridView.Rows[index].Cells[2].Value;
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
                                var updateQuery = $"UPDATE Services SET ServiceName = '{serviceName}' WHERE ServiceID = '{serviceID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateServices == RowState.New)
                            {
                                var serviceName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var insertQuery = $"INSERT INTO Services (ServiceName) VALUES ('{serviceName}')";
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
                                FillAllComboBoxes();
                            }
                            if (rowStateMedications == RowState.Modified)
                            {
                                var medicationID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var quantinityInStock = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var updateQuery = $"UPDATE Medications SET Name = '{name}', Description = '{description}', QuantityInStock = '{quantinityInStock}' WHERE MedicationID = '{medicationID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            if (rowStateMedications == RowState.New)
                            {
                                var name = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var description = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var quantinityInStock = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var insertQuery = $"INSERT INTO Medications (Name, Description, QuantinityInStock) VALUES ('{name}', '{description}', '{quantinityInStock}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                                FillAllComboBoxes();
                            }
                            break;

                        case "dataGridViewMedicationSupplies":
                            var rowStateSupplies = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateSupplies == RowState.Existed)
                                continue;
                            if (rowStateSupplies == RowState.Deleted)
                            {
                                var supplyID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM MedicationSupplies WHERE SupplyID = '{supplyID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateSupplies == RowState.Modified)
                            {
                                var supplyID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var medicationName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var oldQuantity = Convert.ToInt32(dataGridView.Rows[index].Cells[3].Value);
                                var newQuantity = Convert.ToInt32(dataGridView.Rows[index].Cells[3].Value);
                                var supplierName = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                int? medicationID = null;
                                if (!string.IsNullOrEmpty(medicationName))
                                {
                                    var getMedIdQuery = $"SELECT MedicationID FROM Medications WHERE Name = '{medicationName}'";
                                    var medIdCommand = new SqlCommand(getMedIdQuery, dataBase.GetConnection());
                                    var result = medIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        medicationID = Convert.ToInt32(result);
                                    }
                                }
                                var updateQuery = $"UPDATE MedicationSupplies SET MedicationID = '{medicationID}', QuantitySupplied = '{newQuantity}', SupplierName = '{supplierName}' WHERE SupplyID = '{supplyID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateSupplies == RowState.New)
                            {
                                var medicationName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var quantitySupplied = Convert.ToInt32(dataGridView.Rows[index].Cells[3].Value);
                                var supplierName = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                int? medicationID = null;
                                if (!string.IsNullOrEmpty(medicationName))
                                {
                                    var getMedIdQuery = $"SELECT MedicationID FROM Medications WHERE Name = '{medicationName}'";
                                    var medIdCommand = new SqlCommand(getMedIdQuery, dataBase.GetConnection());
                                    var result = medIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        medicationID = Convert.ToInt32(result);
                                    }
                                }
                                var insertQuery = $"INSERT INTO MedicationSupplies (MedicationID, QuantitySupplied, SupplierName) VALUES ('{medicationID}', '{quantitySupplied}', '{supplierName}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewMedicationUsages":
                            var rowStateMedUsages = (RowState)dataGridView.Rows[index].Cells[6].Value;
                            if (rowStateMedUsages == RowState.Existed)
                                continue;
                            if (rowStateMedUsages == RowState.Deleted)
                            {
                                var usageID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var medicationName = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var quantityUsed = Convert.ToInt32(dataGridView.Rows[index].Cells[4].Value);
                                var deleteQuery = $"DELETE FROM MedicationUsages WHERE MedicationUsageID = '{usageID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateMedUsages == RowState.Modified)
                            {
                                var usageID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var petName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var vetName = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var medicationName = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var oldQuantity = Convert.ToInt32(dataGridView.Rows[index].Cells[4].Value);
                                var newQuantity = Convert.ToInt32(dataGridView.Rows[index].Cells[4].Value);
                                var purpose = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                int? petID = null;
                                if (!string.IsNullOrEmpty(petName))
                                {
                                    var getPetIdQuery = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                                    var petIdCommand = new SqlCommand(getPetIdQuery, dataBase.GetConnection());
                                    var result = petIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        petID = Convert.ToInt32(result);
                                    }
                                }
                                int? vetID = null;
                                if (!string.IsNullOrEmpty(vetName))
                                {
                                    var getVetIdQuery = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                                    var vetIdCommand = new SqlCommand(getVetIdQuery, dataBase.GetConnection());
                                    var result = vetIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        vetID = Convert.ToInt32(result);
                                    }
                                }
                                int? medicationID = null;
                                if (!string.IsNullOrEmpty(medicationName))
                                {
                                    var getMedIdQuery = $"SELECT MedicationID FROM Medications WHERE Name = '{medicationName}'";
                                    var medIdCommand = new SqlCommand(getMedIdQuery, dataBase.GetConnection());
                                    var result = medIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        medicationID = Convert.ToInt32(result);
                                    }
                                }
                                var updateQuery = $"UPDATE MedicationUsages SET PetID = '{petID}', VetID = '{vetID}', MedicationID = '{medicationID}', QuantityUsed = '{newQuantity}', Purpose = '{purpose}' WHERE MedicationUsageID = '{usageID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateMedUsages == RowState.New)
                            {
                                var petName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var vetName = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var medicationName = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var quantityUsed = Convert.ToInt32(dataGridView.Rows[index].Cells[4].Value);
                                var purpose = dataGridView.Rows[index].Cells[5].Value?.ToString();
                                int? petID = null;
                                if (!string.IsNullOrEmpty(petName))
                                {
                                    var getPetIdQuery = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                                    var petIdCommand = new SqlCommand(getPetIdQuery, dataBase.GetConnection());
                                    var result = petIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        petID = Convert.ToInt32(result);
                                    }
                                }
                                int? vetID = null;
                                if (!string.IsNullOrEmpty(vetName))
                                {
                                    var getVetIdQuery = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                                    var vetIdCommand = new SqlCommand(getVetIdQuery, dataBase.GetConnection());
                                    var result = vetIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        vetID = Convert.ToInt32(result);
                                    }
                                }
                                int? medicationID = null;
                                if (!string.IsNullOrEmpty(medicationName))
                                {
                                    var getMedIdQuery = $"SELECT MedicationID FROM Medications WHERE Name = '{medicationName}'";
                                    var medIdCommand = new SqlCommand(getMedIdQuery, dataBase.GetConnection());
                                    var result = medIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        medicationID = Convert.ToInt32(result);
                                    }
                                }
                                var insertQuery = $"INSERT INTO MedicationUsages (PetID, VetID, MedicationID, QuantityUsed, Purpose) VALUES ('{petID}', '{vetID}', '{medicationID}', '{quantityUsed}', '{purpose}')";
                                new SqlCommand(insertQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewServiceUsages":
                            var rowStateServiceUsages = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateServiceUsages == RowState.Existed)
                                continue;
                            if (rowStateServiceUsages == RowState.Deleted)
                            {
                                var serviceUsageID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"DELETE FROM ServiceUsages WHERE ServiceUsageID = '{serviceUsageID}'";
                                new SqlCommand(deleteQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateServiceUsages == RowState.Modified)
                            {
                                var serviceUsageID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var petName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var vetName = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var serviceName = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var purpose = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                int? petID = null;
                                if (!string.IsNullOrEmpty(petName))
                                {
                                    var getPetIdQuery = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                                    var petIdCommand = new SqlCommand(getPetIdQuery, dataBase.GetConnection());
                                    var result = petIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        petID = Convert.ToInt32(result);
                                    }
                                }
                                int? vetID = null;
                                if (!string.IsNullOrEmpty(vetName))
                                {
                                    var getVetIdQuery = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                                    var vetIdCommand = new SqlCommand(getVetIdQuery, dataBase.GetConnection());
                                    var result = vetIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        vetID = Convert.ToInt32(result);
                                    }
                                }
                                int? serviceID = null;
                                if (!string.IsNullOrEmpty(serviceName))
                                {
                                    var getServiceIdQuery = $"SELECT ServiceID FROM Services WHERE ServiceName = '{serviceName}'";
                                    var serviceIdCommand = new SqlCommand(getServiceIdQuery, dataBase.GetConnection());
                                    var result = serviceIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        serviceID = Convert.ToInt32(result);
                                    }
                                }
                                var updateQuery = $"UPDATE ServiceUsages SET PetID = '{petID}', VetID = '{vetID}', ServiceID = '{serviceID}', Purpose = '{purpose}' WHERE ServiceUsageID = '{serviceUsageID}'";
                                new SqlCommand(updateQuery, dataBase.GetConnection()).ExecuteNonQuery();
                            }
                            if (rowStateServiceUsages == RowState.New)
                            {
                                var petName = dataGridView.Rows[index].Cells[1].Value?.ToString();
                                var vetName = dataGridView.Rows[index].Cells[2].Value?.ToString();
                                var serviceName = dataGridView.Rows[index].Cells[3].Value?.ToString();
                                var purpose = dataGridView.Rows[index].Cells[4].Value?.ToString();
                                int? petID = null;
                                if (!string.IsNullOrEmpty(petName))
                                {
                                    var getPetIdQuery = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                                    var petIdCommand = new SqlCommand(getPetIdQuery, dataBase.GetConnection());
                                    var result = petIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        petID = Convert.ToInt32(result);
                                    }
                                }
                                int? vetID = null;
                                if (!string.IsNullOrEmpty(vetName))
                                {
                                    var getVetIdQuery = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                                    var vetIdCommand = new SqlCommand(getVetIdQuery, dataBase.GetConnection());
                                    var result = vetIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        vetID = Convert.ToInt32(result);
                                    }
                                }
                                int? serviceID = null;
                                if (!string.IsNullOrEmpty(serviceName))
                                {
                                    var getServiceIdQuery = $"SELECT ServiceID FROM Services WHERE ServiceName = '{serviceName}'";
                                    var serviceIdCommand = new SqlCommand(getServiceIdQuery, dataBase.GetConnection());
                                    var result = serviceIdCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        serviceID = Convert.ToInt32(result);
                                    }
                                }
                                var insertQuery = $"INSERT INTO ServiceUsages (PetID, VetID, ServiceID, Purpose) VALUES ('{petID}', '{vetID}', '{serviceID}', '{purpose}')";
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
                        var registrationDate = dateTimePickerRegistrationDate.Value;
                        dataGridView.Rows[selectedRowIndex].SetValues(clientID, fullName, phone, email, address, registrationDate);
                        dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                        break;

                    case "dataGridViewPets":
                        var petID = textBoxPetID.Text;
                        var name = textBoxNamePets.Text;
                        var species = textBoxSpecies.Text;
                        var breed = textBoxBreed.Text;
                        var birthDate = dateTimePickerBirthDatePets.Value;
                        var ownerID = comboBoxOwnerID.Text;
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
                        var genderID = comboBoxGender.Text;
                        var postID = comboBoxPost.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(vetID, fullNameVet, birthDateVet, birthPlace, passportSeries, passportNumber, phoneVet, emailVet, innVet, dateOfEmployement, genderID, postID);
                        dataGridView.Rows[selectedRowIndex].Cells[12].Value = RowState.Modified;
                        break;

                    case "dataGridViewServices":
                        var serviceID = textBoxServiceID.Text;
                        var serviceName = textBoxServiceName.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(serviceID, serviceName);
                        dataGridView.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
                        break;

                    case "dataGridViewMedications":
                        var medicationID = textBoxMedicationID.Text;
                        var nameMed = textBoxNameMedications.Text;
                        var description = textBoxDescription.Text;
                        var priceMed = textBoxQuantityInStock.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(medicationID, nameMed, description, priceMed);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewMedicationSupplies":
                        var supplyID = textBoxSupplyID.Text;
                        var medicationIDSupply = comboBoxMedicationIDMedicationSuppplies.Text;
                        var supplyDate = dateTimePickerSupplyDate.Value;
                        var quantitySupplied = textBoxQuantitySupplied.Text;
                        var supplierName = textBoxSupplierName.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(supplyID, medicationIDSupply, supplyDate, quantitySupplied, supplierName);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;

                    case "dataGridViewMedicationUsages":
                        var medicationUsageID = textBoxMedicationUsageID.Text;
                        var petIDUsage = comboBoxPetIDMedicationUsages.Text;
                        var vetIDUsage = comboBoxVetIDMedicationUsages.Text;
                        var medicationIDUsage = comboBoxMedicationIDMedicationUsages.Text;
                        var quantityUsed = textBoxQuantityUsed.Text;
                        var purposeUsage = textBoxPurposeMedicationUsages.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(medicationUsageID, petIDUsage, vetIDUsage, medicationIDUsage, quantityUsed, purposeUsage);
                        dataGridView.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                        break;

                    case "dataGridViewServiceUsages":
                        var serviceUsageID = textBoxServiceUsageID.Text;
                        var petIDService = comboBoxPetIDServiceUsages.Text;
                        var vetIDService = comboBoxVetIDServiceUsages.Text;
                        var serviceIDUsage = comboBoxServiceIDServiceUsages.Text;
                        var purposeService = textBoxPurposeServiceUsages.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(serviceUsageID, petIDService, vetIDService, serviceIDUsage, purposeService);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
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

                    case "dataGridViewMedications":
                        title.Range.Text = "Данные лекарств";
                        break;

                    case "dataGridViewMedicationSupplies":
                        title.Range.Text = "Данные поставок лекарств";
                        break;

                    case "dataGridViewMedicationUsages":
                        title.Range.Text = "Данные использования лекарств";
                        break;

                    case "dataGridViewServiceUsages":
                        title.Range.Text = "Данные оказания услуг";
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

                    case "dataGridViewMedications":
                        title = "Данные лекарств";
                        break;

                    case "dataGridViewMedicationSupplies":
                        title = "Данные поставок лекарств";
                        break;

                    case "dataGridViewMedicationUsages":
                        title = "Данные использования лекарств";
                        break;

                    case "dataGridViewServiceUsages":
                        title = "Данные оказания услуг";
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
        /// FillAllComboBoxes() Заполняет все внешние ключи
        /// </summary>
        private void FillAllComboBoxes()
        {
            try
            {
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
                comboBoxPost.Items.Clear();
                var postsQuery = "SELECT Post FROM Posts ORDER BY Post";
                var postsCommand = new SqlCommand(postsQuery, dataBase.GetConnection());
                var postsReader = postsCommand.ExecuteReader();
                while (postsReader.Read())
                {
                    comboBoxPost.Items.Add(postsReader.GetString(0));
                }
                postsReader.Close();
                comboBoxGender.Items.Clear();
                var gendersQuery = "SELECT Gender FROM Genders ORDER BY Gender";
                var gendersCommand = new SqlCommand(gendersQuery, dataBase.GetConnection());
                var gendersReader = gendersCommand.ExecuteReader();
                while (gendersReader.Read())
                {
                    comboBoxGender.Items.Add(gendersReader.GetString(0));
                }
                gendersReader.Close();
                comboBoxMedicationIDMedicationSuppplies.Items.Clear();
                comboBoxMedicationIDMedicationUsages.Items.Clear();
                using (var cmd = new SqlCommand("SELECT MedicationID, Name FROM Medications ORDER BY Name", dataBase.GetConnection()))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxMedicationIDMedicationSuppplies.Items.Add(reader.GetString(1));
                            comboBoxMedicationIDMedicationUsages.Items.Add(reader.GetString(1));
                        }
                    }
                }
                comboBoxPetIDMedicationUsages.Items.Clear();
                comboBoxPetIDServiceUsages.Items.Clear();
                using (var cmd = new SqlCommand("SELECT PetID, Name FROM Pets ORDER BY Name", dataBase.GetConnection()))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxPetIDMedicationUsages.Items.Add(reader.GetString(1));
                            comboBoxPetIDServiceUsages.Items.Add(reader.GetString(1));
                        }
                    }
                }
                comboBoxVetIDServiceUsages.Items.Clear();
                comboBoxVetIDMedicationUsages.Items.Clear();
                using (var cmd = new SqlCommand("SELECT VetID, FullName FROM Veterinarians ORDER BY FullName", dataBase.GetConnection()))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxVetIDServiceUsages.Items.Add(reader.GetString(1));
                            comboBoxVetIDMedicationUsages.Items.Add(reader.GetString(1));
                        }
                    }
                }
                comboBoxServiceIDServiceUsages.Items.Clear();
                using (var cmd = new SqlCommand("SELECT ServiceID, ServiceName FROM Services ORDER BY ServiceName", dataBase.GetConnection()))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxServiceIDServiceUsages.Items.Add(
                                reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных в комбобоксы: {ex.Message}");
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
                RefreshDataGrid(dataGridViewMedications, "Medications");
                RefreshDataGrid(dataGridViewMedicationSupplies, "MedicationSupplies");
                RefreshDataGrid(dataGridViewMedicationUsages, "MedicationUsages");
                RefreshDataGrid(dataGridViewServiceUsages, "ServiceUsages");
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
        /// ButtonNewMedicationSupplie_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMedicationSupplies addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewMedicationUsage_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormMedicationSupplies addForm = new();
                addForm.Show();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewServiceUsage_Click() вызывается при нажатии на кнопку "Создать запись" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormServiceUsages addForm = new();
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
        /// ButtonDeleteMedicationSupplie_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMedicationSupplies);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteMedicationUsage_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewMedicationUsages);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteServiceUsage_Click() вызывается при нажатии на кнопку "Удалить" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewServiceUsages);
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
        /// ButtonChangeMedicationSupplie_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMedicationSupplies);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeMedicationUsage_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewMedicationUsages);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeServiceUsage_Click() вызывается при нажатии на кнопку "Изменить" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                Change(dataGridViewServiceUsages);
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
        /// ButtonSaveMedicationSupplie_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewMedicationSupplies);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveMedicationUsage_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewMedicationUsages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveServiceUsage_Click() вызывается при нажатии на кнопку "Сохранить" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewServiceUsages);
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
        /// ButtonWordMedicationSupplie_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMedicationSupplies);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordMedicationUsage_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewMedicationUsages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonWordServiceUsage_Click() вызывается при нажатии на кнопку "Вывод в Word" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWordServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToWord(dataGridViewServiceUsages);
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
        /// ButtonExcelMedicationSupplie_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMedicationSupplie_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMedicationSupplies);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelMedicationUsage_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelMedicationUsage_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewMedicationUsages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonExcelServiceUsage_Click() вызывается при нажатии на кнопку "Вывод в Excel" на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExcelServiceUsage_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel(dataGridViewServiceUsages);
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
        /// DataGridViewMedicationSupplies_CellClick() вызывается при нажатии на ячейку на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMedicationSupplies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMedicationSupplies, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewMedicationUsages_CellClick() вызывается при нажатии на ячейку на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewMedicationUsages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewMedicationUsages, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewServiceUsages_CellClick() вызывается при нажатии на ячейку на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewServiceUsages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridView_CellClick(dataGridViewServiceUsages, selectedRow);
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
        /// TextBoxSearchMedicationSupplies_TextChanged() вызывается при изменении текста на вкладке "Поставки лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMedicationSupplies_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMedicationSupplies);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchMedicationUsages_TextChanged() вызывается при изменении текста на вкладке "Использование лекарств"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchMedicationUsages_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewMedicationUsages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchServiceUsages_TextChanged() вызывается при изменении текста на вкладке "Оказание услуг"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchServiceUsages_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewServiceUsages);
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
    }
}