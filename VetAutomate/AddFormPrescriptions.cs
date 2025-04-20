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
                var petName = textBoxPetIDPrescriptions.Text;
                string queryPet = $"SELECT PetID FROM Pets WHERE Name = '{petName}'";
                SqlCommand commandPet = new(queryPet, dataBase.GetConnection());
                dataBase.OpenConnection();
                object resultPet = commandPet.ExecuteScalar();
                var petID = resultPet?.ToString() ?? "0";
                var vetName = textBoxVetIDPrescriptions.Text;
                string queryVet = $"SELECT VetID FROM Veterinarians WHERE FullName = '{vetName}'";
                SqlCommand commandVet = new(queryVet, dataBase.GetConnection());
                object resultVet = commandVet.ExecuteScalar();
                var vetID = resultVet?.ToString() ?? "0";
                var medName = textBoxMedicationIDPrescriptions.Text;
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