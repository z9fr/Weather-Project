using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace weatherapp
{
    
    public partial class widget : Form
    {
        public string city;
        const string APPID = ""; // api key

        public widget()
        {
            InitializeComponent();

            string message, title, defaultValue;
            object myValue;


            //set Prompt 
            message = "Please Enter a Location";
            title = "Location for Widget";

            // display Message
            myValue = Interaction.InputBox(message, title);

            if((string) myValue == "")
            {
                closetheWidget();
            }
            else
            {
                city = myValue.ToString();
                getWeather(city);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
             getWeather(city);
        }


        void closetheWidget()
        {
            this.Hide();
            //show the error page
        }

        private void widget_Load(object sender, EventArgs e)
        {
            guna2Panel8.BackColor = Color.FromArgb(105, Color.Black);
        }

        void getWeather(string theCity)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?appid={0}&units=metric&cnt=6&q={1}", APPID, theCity);

                try
                {
                    var json = web.DownloadString(url);
                    //json convertion 
                    var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);
                    weatherInfo.root outPut = result;

                    lbl_cityname.Text = string.Format("{0}", outPut.name);
                    lbl_country.Text = string.Format("{0}", outPut.sys.country);

                    label4.Text = string.Format("{0}"+" C", outPut.main.temp);

                    string wetherIdinStringi = string.Format("{0}", outPut.id);
                    updateimage(wetherIdinStringi, "guna2PictureBox3");

                    string sunrisetime_gmt = string.Format("{0}", outPut.sys.sunrise);
                    string sunset_gmt = string.Format("{0}", outPut.sys.sunset);

                    label3.Text = string.Format("{0}", outPut.weather[0].description);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong" + ex.ToString());
                }

            }
        } // update wether 

        public void updateimage(string idinString, string boxname)
        {
            int id = int.Parse(idinString);

            if (id >= 200 && id <= 232)
            {
                // thunderstorm (386) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._386;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 300 && id <= 321)
            {
                //dizzle (260) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._266;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            else if (id >= 500 && id <= 531)
            {
                //rain (359) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._359;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 600 && id <= 622)
            {
                //snow (338) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._338;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 701 && id <= 781)
            {
                //Atmosphere  (260) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._260;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }

            else if (id == 800)
            {
                //clear (113) 
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._113;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 801 && id <= 804)
            {
                //clouds (122) 

                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._122;
                }

                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._116;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }

        } // update the image accoding to the wether condition 

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
