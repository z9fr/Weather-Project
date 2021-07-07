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
    public partial class login : Form
    {
        public string theLoginName; 

        public login()
        {
            InitializeComponent();
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup thesignup = new signup();
            thesignup.Show();
            this.Hide();

        }

        async private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string name = guna2TextBox1.Text;
                string passwd = guna2TextBox2.Text;

                string url = string.Format("/logmein.php?u={0}&p={1}", name, passwd); // requesting login api 

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        if (mycontent == "success")
                        {
                            this.Hide();
                            theLoginName = name;
                            dashboard thedash = new dashboard(theLoginName);
                            theLoginName = thedash.theSuccesName;
                            thedash.Show();

       
                        }
                        else
                        {
                            MessageBox.Show("Hey! we couldnot Recordnize the Password You provided. Do you Mind Checking it Again ?");
                        }

                    }
                }

            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
