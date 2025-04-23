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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VetAutomate
{
    public partial class AddFormPrescriptions : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormPrescriptions()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
            comboBoxPetIDPrescriptions.Items.Clear();
            var petsQuery = "SELECT Name FROM Pets ORDER BY Name";
            var petsCommand = new SqlCommand(petsQuery, dataBase.GetConnection());
            var petsReader = petsCommand.ExecuteReader();
            while (petsReader.Read())
            {
                comboBoxPetIDPrescriptions.Items.Add(petsReader.GetString(0));
            }
            petsReader.Close();
            comboBoxVetIDPrescriptions.Items.Clear();
            var vetsQuery = "SELECT FullName FROM Veterinarians ORDER BY FullName";
            var vetsCommand = new SqlCommand(vetsQuery, dataBase.GetConnection());
            var vetsReader = vetsCommand.ExecuteReader();
            while (vetsReader.Read())
            {
                comboBoxVetIDPrescriptions.Items.Add(vetsReader.GetString(0));
            }
            vetsReader.Close();
            comboBoxMedicationIDPrescriptions.Items.Clear();
            var medicationsQuery = "SELECT Name FROM Medications ORDER BY Name";
            var medicationsCommand = new SqlCommand(medicationsQuery, dataBase.GetConnection());
            var medicationsReader = medicationsCommand.ExecuteReader();
            while (medicationsReader.Read())
            {
                comboBoxMedicationIDPrescriptions.Items.Add(medicationsReader.GetString(0));
            }
            medicationsReader.Close();
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
                var petName = comboBoxPetIDPrescriptions.Text;
                string queryPet = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                dataBase.OpenConnection();
                object resultPet = commandPet.ExecuteScalar();
                var petID = resultPet?.ToString() ?? "0";
                var vetName = comboBoxVetIDPrescriptions.Text;
                string queryVet = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                object resultVet = commandVet.ExecuteScalar();
                var vetID = resultVet?.ToString() ?? "0";
                var medName = comboBoxMedicationIDPrescriptions.Text;
                string queryMed = $"SELECT MedicationID FROM Medications WHERE Name = '{medName}'";
                SqlCommand commandMed = new(queryMed, dataBase.GetConnection());
                object resultMed = commandMed.ExecuteScalar();
                var medicationID = resultMed?.ToString() ?? "0";
                var dosage = textBoxDosage.Text;
                var instructions = textBoxInstructions.Text;
                var insertQuery = $"INSERT INTO Prescriptions (PetID, VetID, MedicationID, Dosage, Instructions) VALUES ('{petID}', '{vetID}', '{medicationID}', '{dosage}', '{instructions}')";
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