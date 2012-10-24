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
    public partial class Page1 : PhoneApplicationPage
    {
        List<string> stopCodes = new List<string>();
        String url = "http://bt4u.org/BT4U_WebService.asmx/GetScheduledStopCodes?routeShortName=";
        String bus = "";
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if (parameters.ContainsKey("Text"))
            {
                //textBlock1.Text = parameters["Text"];
                url += parameters["Text"];
                bus = parameters["Text"];
                HttpGet(url);

            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String stopCode = listBox1.SelectedItem.ToString();
            String uri = "/Page2.xaml?Stop=" + stopCode + "&Bus=" + bus;
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));

        }

        public void HttpGet(String url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(url, UriKind.Absolute));
        }

        public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            XDocument doc = XDocument.Parse(e.Result.ToString());

            foreach (XElement element in doc.Descendants("StopCode"))
            {
                Console.WriteLine(element);
                //textBlock1.Text += element.Value + "\n ";
                stopCodes.Add(element.Value);
            }
            listBox1.ItemsSource = stopCodes;

        }
      
    }
}