using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace IM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DBInit dBInit = new DBInit();
            dBInit.initDB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_registered_Click(object sender, EventArgs e)
        {
            Signup sForm = new Signup();
            sForm.Show();
            this.Hide();
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if(login_showPass.Checked) 
            {
                login_password.PasswordChar = '\0';
            }
            else
            {
                login_password.PasswordChar = '*';
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LogIn logIn = new LogIn();
                bool loginIsValid = logIn.loginValidate(login_username.Text, login_password.Text);

                if(loginIsValid)
                {
                    MainForm mainForm = new MainForm();
                    MainForm2 mainForm2 = new MainForm2();
                    string thelevel = logIn.userGetLevel(login_username.Text, login_password.Text);
                    if(thelevel == "ADMIN")
                    {
                        MainForm mainform = new MainForm();

  
                        mainForm.Show();
                        this.Hide();
                    }
                    else if(thelevel == "USER")
                    {
                        mainForm2.Show();
                        this.Hide();
                    }
                                
                }
                else
                {
                    MessageBox.Show("Incorrect Username/Password/level", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
