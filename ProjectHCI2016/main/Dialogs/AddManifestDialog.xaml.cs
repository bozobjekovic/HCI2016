﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddManifestDialog.xaml
    /// </summary>
    public partial class AddManifestDialog : Window
    {
        public AddManifestDialog()
        {
            InitializeComponent();
        }

        private void cancelAddManBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addManifestBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
