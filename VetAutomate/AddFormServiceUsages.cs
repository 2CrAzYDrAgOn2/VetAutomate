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
        }
        /// <summary>
        /// ButtonSave_Click() вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
