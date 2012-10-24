using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.Phone.Controls;

namespace PhoneApp1
{
    public partial class Page2 : PhoneApplicationPage
    {
        List<string> times = new List<string>();
        String url = "http://www.bt4u.org/BT4U_WebService.asmx/GetNextDepartures?routeShortName=";
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if (parameters.ContainsKey("Bus"))
            {
               url += parameters["Bus"] + "&stopCode=" + parameters["Stop"];

                HttpGet(url);
            }

        }

        public void HttpGet(String url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
        }

        public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            XDocument doc = XDocument.Parse(e.Result);

            foreach (XElement element in doc.Descendants("AdjustedDepartureTime"))
            {
                Console.WriteLine(element);
                //textBlock1.Text += element.Value + "\n ";
                string timeElement = element.Value;
                timeElement = timeElement.Substring(10, 12);
                times.Add(timeElement);
            }
            listBox1.ItemsSource = times;

        }
    }
}