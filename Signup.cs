using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IM
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            DBInit dDBInit = new DBInit();
            dDBInit.initDB();
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if(signup_level.Text == "" || signup_username.Text == ""
                || signup_password.Text == "" || signup_firstname.Text == "" || signup_middlename.Text == "" || signup_lastname.Text == "" || signup_position.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LogIn logIn = new LogIn();
                bool usernameIsValid = logIn.signupValidate(signup_username.Text.Trim());

                if (usernameIsValid)
                {
                    MessageBox.Show(signup_username.Text + " is already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UserCRUD crud = new UserCRUD();
                    crud.addUser(signup_username.Text.Trim(),
                        signup_firstname.Text.Trim(),
                        signup_lastname.Text.Trim(),
                        signup_middlename.Text.Trim(),
                        signup_password.Text.Trim(),
                        signup_level.Text.Trim()
                        );

                        MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                }
            }
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if(signup_showPass.Checked)
            {
                signup_password.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            
            pictureBoxAU.Show();
            label10.ForeColor = Color.White;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            mainForm.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            mainForm.Show();
        }
    }
}
