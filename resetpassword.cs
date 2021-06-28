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

    public partial class resetpassword : Form
    {
        public string uname;

        public resetpassword(string theUserNameCookie)
        {
            uname = theUserNameCookie;
            InitializeComponent();
        }

        async private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(tboxPass.Text== "" | tboxPassConfirm.Text == "" | emailtbox.Text =="")
            {
                MessageBox.Show("please enter the password");
            }
            else if(tboxPass.Text != tboxPassConfirm.Text)
            {
                MessageBox.Show("password should be same in the both fields");
            }
            else if(tboxPass.Text == tboxPass.Text)
            {
               

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string password = tboxPass.Text;
                        string mail = emailtbox.Text;

                        string url = string.Format("/update.php?uname={0}&pass={1}&mail={2}", uname, password, mail); // add the php api link

                        using (HttpResponseMessage response = await client.GetAsync(url))
                        {
                            using (HttpContent content = response.Content)
                            {
                                string mycontent = await content.ReadAsStringAsync();

                                if (mycontent.Contains("updated"))
                                {
                                    this.Hide();
                                    MessageBox.Show("We rememberd your new Password. Next time Use it!");
                                }
                                else
                                {
                                    MessageBox.Show("Internal Server error");
                                }

                            }
                        }

                    }
                }
                catch(Exception ex)
                {
                    //do something
                }

            }
            else
            {
                MessageBox.Show("Something went Wrong!!!");
            }
        }

        private void resetpassword_Load(object sender, EventArgs e)
        {
            lbl_cityname.Text = "Hello " + uname;
        }
    }
}
