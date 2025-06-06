﻿using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
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

namespace VetAutomate
{
    public partial class AddFormVeterinarians : Form
    {
        private readonly DataBase dataBase = new();

        public AddFormVeterinarians()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase.OpenConnection();
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
                var fullName = textBoxFullName.Text;
                var birthDate = dateTimePickerBirthDateVeterinarians.Value;
                var birthPlace = textBoxBirthPlace.Text;
                var passportSeries = textBoxPassportSeries.Text;
                var passportNumber = textBoxPassportNumber.Text;
                var phone = maskedTextBoxPhoneVeterinarians.Text;
                var email = textBoxEmailVeterinarians.Text;
                var inn = textBoxINNVeterinarians.Text;
                var dateOfEmployment = dateTimePickerDateOfEmployment.Value;
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
                var insertQuery = $"INSERT INTO Veterinarians (FullName, BirthDate, BirthPlace, PassportSeries, PassportNumber, Phone, Email, INN, DateOfEmployment, PostID, GenderID) VALUES ('{fullName}', '{birthDate}', '{birthPlace}', '{passportSeries}', '{passportNumber}', '{phone}', '{email}', '{inn}', '{dateOfEmployment}', '{postID}', '{genderID}')";
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