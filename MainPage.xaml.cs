using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String busName = textBox1.Text;
            String uri = "/Page1.xaml?Text=";
            if (busName.Equals("Hethwood"))
            {
                uri += "HWD";
            }

            if (busName.Equals("Crc"))
            {
                uri += "CRC";
            }

            if (busName.Equals("Hokie Express"))
            {
                uri += "HXP";
            }

            if (busName.Equals("University Mall Shuttle"))
            {
                uri += "UMS";
            }

            if (busName.Equals("Progress Street"))
            {
                uri += "PRG";
            }

            if (busName.Equals("Two Town Trolley"))
            {
                uri += "TTT";
            }

            if (busName.Equals("Main Street North"))
            {
                uri += "MSN";
            }

            if (busName.Equals("Main Street South"))
            {
                uri += "MSS";
            }

            if (busName.Equals("University City Boulevard"))
            {
                uri += "UCB";
            }

            if (busName.Equals("Harding Avenue"))
            {
                uri += "HDG";
            }

            if (busName.Equals("Patrick Henry"))
            {
                uri += "PH";
            }

            if (busName.Equals("Tom's Creek"))
            {
                uri += "TC";
            }
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
    }
}