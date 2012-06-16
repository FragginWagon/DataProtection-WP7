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

// Used for the protection of data
using System.Security.Cryptography;

namespace DataProtection
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Global variables
        byte[] dataString;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            // Convert Text data to byte array
            byte[] conversionData = System.Text.Encoding.UTF8.GetBytes(txtData.Text);
            // Convert byte array to Base 64 String
            string tempString = Convert.ToBase64String(conversionData);
            // Protect Data using encryption
            dataString = ProtectedData.Protect(conversionData, null);
            // Show encrypted data in message box
            MessageBox.Show("Encrypted data is : " + tempString);
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            // unprotect data and send to a byte array
            byte[] conversionData = ProtectedData.Unprotect(dataString, null);
            // Write the string to the textbox and then show the text in a message box
            txtData.Text = System.Text.Encoding.UTF8.GetString(conversionData, 0, conversionData.Length);            
            MessageBox.Show("Decrypted data is : " + txtData.Text);
        }

    }
}