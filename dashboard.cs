using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;
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

namespace weatherapp
{
    public partial class dashboard : Form
    {
        const string APPID = "0e0810d7d0c0468cce11d4ac3b1c992e";

        public double mintemp1;
        public double maxtemp1;
        public double date1;

        public double mintemp2;
        public double maxtemp2;
        public double date2;

        public double mintemp3;
        public double maxtemp3;
        public double date3;

        public double mintemp4;
        public double maxtemp4;
        public double date4;

        public double mintemp5;
        public double maxtemp5;
        public double date5;

        public double mintemp6;
        public double maxtemp6;
        public double date6;

        public double humility;
        public double wind_speed;
        public double pressure;
        public double wind_gust;
        public double feels_like;
        public string theSuccesName;
        public dashboard(string thLoginName)
        {
            theSuccesName = thLoginName;

            const string APPID = ""; // add the api key 
            string cityname = "Colombo";

            InitializeComponent();

            double value1 = 10.1;

            getWeather();
            

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Lowest Temprature",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(1,mintemp1 ),
                        new ObservablePoint(2,mintemp2 ),
                        new ObservablePoint(3,mintemp3 ),
                        new ObservablePoint(4,mintemp4 ),
                        new ObservablePoint(5,mintemp5 ),
                        new ObservablePoint(6,mintemp6 )
                    },
                    PointGeometrySize = 15

                   
                },

                new LineSeries
                {
                    Title = "Highest Temprature",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(1,maxtemp1 ),
                        new ObservablePoint(2,maxtemp2 ),
                        new ObservablePoint(3,maxtemp3 ),
                        new ObservablePoint(4,maxtemp4 ),
                        new ObservablePoint(5,maxtemp5 ),
                        new ObservablePoint(6,maxtemp6 )
                    },
                    PointGeometrySize = 15

                }


            };

        }

        void getTodayInfo(string theCity)
        {
            using (WebClient web = new WebClient())
            {
                label6.Text = "Statestics of the Day at " + theCity;
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?appid={0}&units=metric&cnt=6&q={1}", APPID , theCity);

                try
                {
                    var json = web.DownloadString(url);
                    //json convertion 
                    var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);
                    weatherInfo.root outPut = result;

                    // update humility
                    humility = double.Parse(string.Format("{0}", outPut.main.humidity));
                    solidGauge1.From = 0;
                    solidGauge1.To = 100;
                    solidGauge1.Value = humility;

                    //update wind speed 
                    wind_speed = double.Parse(string.Format("{0}", outPut.wind.speed));
                    solidGauge2.From = 0;
                    solidGauge2.To = 100;
                    solidGauge2.Value = wind_speed;

                    //update pressure 
                    pressure = double.Parse(string.Format("{0}", outPut.main.pressure));
                    solidGauge3.From = 0;
                    solidGauge3.To = 10000;
                    solidGauge3.Value = pressure;

                    //update wind_gust
                    wind_gust = double.Parse(string.Format("{0}", outPut.wind.gust));
                    solidGauge4.From = 0;
                    solidGauge4.To = 100;
                    solidGauge4.Value = wind_gust;

                    //feels_like
                    feels_like = double.Parse(string.Format("{0}", outPut.main.feels_like));
                    solidGauge5.From = 0;
                    solidGauge5.To = 100;
                    solidGauge5.Value = feels_like;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong" + ex.ToString());
                }

            }
        }


        void getWeather()
        {
            string url = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat=6.9271&lon=79.8612&exclude=current,minutely,hourly,alerts&appid="); // add the api key

            using (WebClient web = new WebClient())
            {
                try
                {
                    var json = web.DownloadString(url);
                    var Object = JsonConvert.DeserializeObject<weatherForcast>(json);
                    weatherForcast forcast = Object;

                    mintemp1  = double.Parse(string.Format("{0}", forcast.daily[1].temp.min));
                     maxtemp1 = double.Parse(string.Format("{0}", forcast.daily[1].temp.max));
                   // date1 = returnDate(string.Format("{0}", forcast.daily[1].dt));
                     

                     mintemp2 = double.Parse(string.Format("{0}", forcast.daily[2].temp.min));
                     maxtemp2 = double.Parse(string.Format("{0}", forcast.daily[2].temp.max));
                     //date2 = returnDate(string.Format("{0}", forcast.daily[2].dt));

                     mintemp3 = double.Parse(string.Format("{0}", forcast.daily[3].temp.min));
                     maxtemp3 = double.Parse(string.Format("{0}", forcast.daily[3].temp.max));
                    // date3 = returnDate(string.Format("{0}", forcast.daily[3].dt));

                     mintemp4 = double.Parse(string.Format("{0}", forcast.daily[4].temp.min));
                     maxtemp4 = double.Parse(string.Format("{0}", forcast.daily[4].temp.max));
                  //   date4 = returnDate(string.Format("{0}", forcast.daily[4].dt));

                     mintemp5 = double.Parse(string.Format("{0}", forcast.daily[5].temp.min));
                     maxtemp5 = double.Parse(string.Format("{0}", forcast.daily[5].temp.max));
                  //   date5 = returnDate(string.Format("{0}", forcast.daily[5].dt));

                     mintemp6 = double.Parse(string.Format("{0}", forcast.daily[6].temp.min));
                     maxtemp6 = double.Parse(string.Format("{0}", forcast.daily[6].temp.max));
                   //  date6 = returnDate(string.Format("{0}", forcast.daily[6].dt));


                }
                catch(Exception ex)
                {
                    MessageBox.Show("Something went Wrong"+ ex.ToString());
                }
            }
        } // update wether 


        public double returnDate(string unformatdateinString)
        {

            long unfDate = long.Parse(unformatdateinString);

            System.DateTime dtDateTime = new DateTime(1970, 1, 1);
            dtDateTime = dtDateTime.AddSeconds(unfDate).ToLocalTime();
            string date = dtDateTime.ToString();
            double datenw = double.Parse(date);

            return datenw;

        } // return the date in human readable format

        private void dashboard_Load(object sender, EventArgs e)
        {
            getTodayInfo("colombo");
            //  login theSuccessLogin = new login();
            // MessageBox.Show(login.theLoginName);
            // set the user name
            try
            {
                lbl_cityname.Text = "Welcome Back " + theSuccesName;
            }
            catch (System.NullReferenceException ex)
            {
                lbl_cityname.Text = "Welcome back";
                MessageBox.Show(ex.ToString());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            widget thewidget = new widget();
            thewidget.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            resetpassword resetPass = new resetpassword(theSuccesName);
            resetPass.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter a city");
            }
            else
            {
                string cityname = guna2TextBox1.Text;
                getTodayInfo(cityname);
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
