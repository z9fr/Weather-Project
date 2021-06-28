using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weatherapp
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login thelogin = new login();
            thelogin.Show();
            this.Hide();
        }

        async private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name_validate = guna2TextBox1.Text;
            string email_validate = guna2TextBox2.Text;
            string username_validate = guna2TextBox3.Text;
            string password_validate = guna2TextBox4.Text;

            if(name_validate == "" | email_validate == "" | username_validate == "" | password_validate == "")
            {
                MessageBox.Show("Eh we expect all the fields");
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    string name = guna2TextBox1.Text;
                    string email = guna2TextBox4.Text;
                    string username = guna2TextBox2.Text;
                    string password = guna2TextBox3.Text;

                    string url = string.Format("/createacc.php?uname={0}&pass={1}&email={2}&name={3}", username, password, email, name); // php api 

                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();

                            if (mycontent.Contains("successfully"))
                            {
                                MessageBox.Show("Hey! we have Added you to Our Super Secret Database Please Login Now ;)");
                                this.Hide();
                                login logmein = new login();
                                logmein.Show();
                            }
                            else
                            {
                                MessageBox.Show("Hey! Something went wrong can you try again ?");
                            }

                        }
                    }

                }

            }



        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
