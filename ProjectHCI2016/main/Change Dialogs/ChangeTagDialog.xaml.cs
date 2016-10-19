using model;
using System;
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
using Xceed.Wpf.Toolkit;

namespace main.Change_Dialogs
{
    /// <summary>
    /// Interaction logic for ChangeTagDialog.xaml
    /// </summary>
    public partial class ChangeTagDialog : Window
    {
        private Tag selectedTag;

        public ChangeTagDialog(int index)
        {
            InitializeComponent();

            selectedTag = MainWindow.Tags.ElementAt(index);

            this.DataContext = this;
        }

        private void changeTagBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression tagID = idTB.GetBindingExpression(TextBox.TextProperty);
            tagID.UpdateSource();
            BindingExpression tagColor = colorPicker.GetBindingExpression(ColorPicker.SelectedColorProperty);
            tagColor.UpdateSource();
            BindingExpression tagDescription = descrriptionTB.GetBindingExpression(TextBox.TextProperty);
            tagDescription.UpdateSource();
            Close();
        }

        private void addTagCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Tag SelectedTag
        {
            get
            {
                return selectedTag;
            }

            set
            {
                selectedTag = value;
            }
        }
    }
}
