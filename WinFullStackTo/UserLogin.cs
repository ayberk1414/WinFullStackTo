using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFullStackTo.Entities;
using WinFullStackTo.Forms;
using WinFullStackTo.Messages;

namespace WinFullStackTo
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
               var userFullName= GetUserName(txtUser.Text,txtPassword.Text);
              if(!string.IsNullOrEmpty(userFullName))
                {
                    NotesForm noteForm = new NotesForm(userFullName);
                    noteForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(Messages.Message.UserNameAndPassword);
                }

            }
            else
            {
                MessageBox.Show(Messages.Message.Field);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private string? GetUserName(string userName,string password)
        {
            SqlConnection sqlConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB; database=TutorialDB;Integrated Security=True;");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "Select * from Users where UserName= @username and Password=@password";
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", password);
    
            var dataReader = command.ExecuteReader();
                
            string fullname = "";
            while (dataReader.Read())
            {
                fullname = Convert.ToString(dataReader[1]);

            }
            sqlConnection.Close();
            return fullname;
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {


            Application.Exit();
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
