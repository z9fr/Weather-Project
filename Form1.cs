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
using Newtonsoft.Json;

/* 
* 
*/

namespace weatherapp
{
    public partial class Form1 : Form
    {
        const string APPID = ""; // add the api key 
        string cityname = "Colombo";

        public Form1()
        {
            InitializeComponent();
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
                    lbl_temp.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
                    lbl_humidity.Text = string.Format("{0}", outPut.main.humidity);
                    lbl_wind.Text = string.Format("{0}" + " km/h", outPut.wind.speed);
                    lbl_dust.Text = string.Format("{0}", outPut.wind.gust);

                    string wetherIdinStringi = string.Format("{0}", outPut.id);
                    updateimage(wetherIdinStringi, "guna2PictureBox1");

                    string sunrisetime_gmt = string.Format("{0}", outPut.sys.sunrise);
                    string sunrisetime = DateTimeToUnixTimestamp(sunrisetime_gmt);
                    lbl_sunrise.Text = sunrisetime;
                    string sunset_gmt = string.Format("{0}", outPut.sys.sunset);
                    string sunsettime = DateTimeToUnixTimestamp(sunset_gmt);
                    lbl_sunset.Text = sunsettime;

                    lbl_desc.Text = string.Format("{0}", outPut.weather[0].description);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong" + ex.ToString());
                }

            }
        } // update wether 

        void getForcast()
        {
            string url = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat=6.9271&lon=79.8612&exclude=current,minutely,hourly,alerts&appid="); // add the api key

            using (WebClient web = new WebClient())
            {

                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);

                weatherForcast forcast = Object;

                //updateing 1

                //changing unixTimeStamp 
                string unformatdateinString1 = string.Format("{0}", forcast.daily[1].dt);
                string formatedDate1 = returnDate(unformatdateinString1);

                string wetherIdinString = string.Format("{0}", forcast.daily[1].weather[0].id);
                updateimage(wetherIdinString, "guna2PictureBox2");

                lbl1_date.Text = formatedDate1;
                lbl1_condition.Text = string.Format("{0}", forcast.daily[1].weather[0].main); // condition 
                lbl1_desc.Text = string.Format("{0}", forcast.daily[1].weather[0].description); // description 
                lbl1_wind.Text = string.Format("{0}"+" km/h", forcast.daily[1].wind_speed);
                


                // updating date 2 

                string unformatdateinString2 = string.Format("{0}", forcast.daily[2].dt);
                string formatedDate2 = returnDate(unformatdateinString2);

                string wetherIdinString2 = string.Format("{0}", forcast.daily[2].weather[0].id);
                updateimage(wetherIdinString2, "guna2PictureBox3");

                lbl2_date.Text = formatedDate2;
                lbl2_condition.Text = string.Format("{0}", forcast.daily[2].weather[0].main); // condition 
                lbl2_desc.Text = string.Format("{0}", forcast.daily[2].weather[0].description); // description 
                lbl2_wind.Text = string.Format("{0}" + " km/h", forcast.daily[2].wind_speed);

                // updating date 3

                string unformatdateinString3 = string.Format("{0}", forcast.daily[3].dt);
                string formatedDate3 = returnDate(unformatdateinString3);

                string wetherIdinString3 = string.Format("{0}", forcast.daily[3].weather[0].id);
                updateimage(wetherIdinString3, "guna2PictureBox4");

                lbl3_date.Text = formatedDate3;
                lbl3_condition.Text = string.Format("{0}", forcast.daily[3].weather[0].main); // condition 
                lbl3_desc.Text = string.Format("{0}", forcast.daily[3].weather[0].description); // description 
                lbl3_wind.Text = string.Format("{0}" + " km/h", forcast.daily[3].wind_speed);


                // updating date 4
                string unformatdateinString4 = string.Format("{0}", forcast.daily[4].dt);
                string formatedDate4 = returnDate(unformatdateinString4);

                string wetherIdinString4 = string.Format("{0}", forcast.daily[4].weather[0].id);
                updateimage(wetherIdinString4, "guna2PictureBox5");

                lbl4_date.Text = formatedDate4;
                lbl4_condition.Text = string.Format("{0}", forcast.daily[4].weather[0].main); // condition 
                lbl4_desc.Text = string.Format("{0}", forcast.daily[4].weather[0].description); // description 
                lbl4_wind.Text = string.Format("{0}" + " km/h", forcast.daily[4].wind_speed);

                // updating date 5
                string unformatdateinString5 = string.Format("{0}", forcast.daily[5].dt);
                string formatedDate5 = returnDate(unformatdateinString5);

                string wetherIdinString5 = string.Format("{0}", forcast.daily[5].weather[0].id);
                updateimage(wetherIdinString5, "guna2PictureBox6");

                lbl5_date.Text = formatedDate5;
                lbl5_condition.Text = string.Format("{0}", forcast.daily[5].weather[0].main); // condition 
                lbl5_desc.Text = string.Format("{0}", forcast.daily[5].weather[0].description); // description 
                lbl5_wind.Text = string.Format("{0}" + " km/h", forcast.daily[5].wind_speed);



                // updating date 6
                string unformatdateinString6 = string.Format("{0}", forcast.daily[6].dt);
                string formatedDate6 = returnDate(unformatdateinString6);

                string wetherIdinString6 = string.Format("{0}", forcast.daily[6].weather[0].id);
                updateimage(wetherIdinString6, "guna2PictureBox7");

                lbl6_date.Text = formatedDate6;
                lbl6_condition.Text = string.Format("{0}", forcast.daily[6].weather[0].main); // condition 
                lbl6_desc.Text = string.Format("{0}", forcast.daily[6].weather[0].description); // description 
                lbl6_wind.Text = string.Format("{0}" + " km/h", forcast.daily[6].wind_speed);



            }

        } // get the focast 

        public string returnDate(string unformatdateinString)
        {
          
            long unfDate = long.Parse(unformatdateinString);

            System.DateTime dtDateTime = new DateTime(1970, 1, 1);
            dtDateTime = dtDateTime.AddSeconds(unfDate).ToLocalTime();


            string date = dtDateTime.DayOfWeek.ToString();

            return date;

        } // return the date in human readable format

        public void updateimage(string idinString , string boxname )
        {
            int id = int.Parse(idinString);

            if (id >= 200 && id <= 232)
            {
                // thunderstorm (386) 
                if(boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._386;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._386;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if(id >= 300 && id <= 321)
            {
                //dizzle (260) 
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._266;
                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._266;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._266;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._266;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._266;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._266;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._266;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            else if (id >= 500  && id <= 531 )
            {
                //rain (359) 
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._359;
                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._359;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._359;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._359;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._359;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._359;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._359;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 600 && id <= 622)
            {
                //snow (338) 
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._338;
                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._338;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._338;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._338;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._338;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._338;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._338;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 701 && id <= 781)
            {
                //Atmosphere  (260) 
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._260;
                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._260;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._260;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._260;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._260;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._260;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._260;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }

            else if (id == 800)
            {
                //clear (113) 
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._113;
                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._113;

                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._113;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._113;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._113;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._113;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._113;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else if (id >= 801 && id <= 804)
            {
                //clouds (122) 

                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._122;
                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._122;

                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._122;

                }

                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._122;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._122;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._122;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._122;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                if (boxname == "guna2PictureBox2")
                {
                    guna2PictureBox2.Image = Properties.Resources._116;
                }
                else if (boxname == "guna2PictureBox1")
                {
                    guna2PictureBox1.Image = Properties.Resources._116;

                }
                else if (boxname == "guna2PictureBox3")
                {
                    guna2PictureBox3.Image = Properties.Resources._116;

                }
                else if (boxname == "guna2PictureBox4")
                {
                    guna2PictureBox4.Image = Properties.Resources._116;

                }
                else if (boxname == "guna2PictureBox5")
                {
                    guna2PictureBox5.Image = Properties.Resources._116;

                }
                else if (boxname == "guna2PictureBox6")
                {
                    guna2PictureBox6.Image = Properties.Resources._116;

                }
                else if (boxname == "guna2PictureBox7")
                {
                    guna2PictureBox7.Image = Properties.Resources._116;

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }

        } // update the image accoding to the wether condition 

        public string  DateTimeToUnixTimestamp(string unformatdateinString)
        {
            long unfDate = long.Parse(unformatdateinString);

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unfDate).ToLocalTime();
            string date = dtDateTime.ToString("HH:mm:ss:tt");

            return date;

        } // formatting the date 2 

        private void Form1_Load(object sender, EventArgs e)
        {
            getWeather(cityname);
            getForcast();


            this.BackgroundImage = Properties.Resources.dreamling_aura_VSdXJBOAxlU_unsplash;
            guna2Panel1.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel2.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel3.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel4.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel5.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel6.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel7.BackColor = Color.FromArgb(105, Color.Black);
            guna2Panel8.BackColor = Color.FromArgb(105, Color.Black);
            panel1.BackColor = Color.FromArgb(205, Color.DodgerBlue);
            panel2.BackColor = Color.FromArgb(205, Color.DodgerBlue);
            panel3.BackColor = Color.FromArgb(205, Color.DodgerBlue);
            panel4.BackColor = Color.FromArgb(205, Color.DodgerBlue);
            panel5.BackColor = Color.FromArgb(205, Color.DodgerBlue);
            panel6.BackColor = Color.FromArgb(205, Color.DodgerBlue);

        } // on load funtion

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please Enter a Location");
            }
            else
            {
                string newLocation = guna2TextBox1.Text;
                getWeather(newLocation);
            }
        } // search box 

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            login thelogin = new login();
            thelogin.Show();
        } // show the login 



        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_temp_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbl1_date_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_desc_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_cityname_Click(object sender, EventArgs e)
        {

        }


    }
}


