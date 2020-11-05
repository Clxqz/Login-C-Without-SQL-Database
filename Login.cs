using Corrupt_Swapper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;

namespace Login_Form_Without_SQL
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {


            password.isPassword = true;


        }

        private void username_OnValueChanged(object sender, EventArgs e)
        {

        }
        protected void SetControlState(bool loading)
        {
            bunifuFlatButton1.Enabled = !loading;
            username.Enabled = !loading;
            password.Enabled = !loading;
            RememberMeCheckBox.Enabled = !loading;
        }
        private async void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string passtxt = password.Text;
            string usertxt = username.Text;
            string passread;
            string userread;
            string path = @"password.txt";
            string user = @"username.txt";


            if (passtxt == File.ReadAllLines(path)[0]&& usertxt == File.ReadAllLines(user)[0])
            {

                MessageBox.Show("Succefully Logged In");
                Form1 fr = new Form1();
                fr.Show();
                Hide();
            }

            else
            {
                MessageBox.Show("Login Incorrect");
            }
  








        }


        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(File.Exists(@"password.txt"))
            {
                File.Delete(@"password.txt");
            }
            if (File.Exists(@"username.txt"))
            {
                File.Delete(@"username.txt");
            }
            string passtxt = password.Text;
            string usertxt = username.Text;
            if (passtxt == password.Text && usertxt == username.Text)
            {
                string path = @"password.txt";
                string user = @"username.txt";
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(passtxt);
                        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden | FileAttributes.System);
                    }
                }
                if (!File.Exists(user))
                {
                    using (StreamWriter sw = File.CreateText(user))
                    {
                        sw.WriteLine(usertxt);
                        File.SetAttributes(user, File.GetAttributes(user) | FileAttributes.Hidden | FileAttributes.System);
                    }
                }

                MessageBox.Show("Account Made");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
         
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
