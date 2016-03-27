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

namespace main.Dialogs
{
    /// <summary>
    /// Interaction logic for AddTagDialog.xaml
    /// </summary>
    public partial class AddTagDialog : Window
    {
        private Tag tag;

        private List<Tag> tags;

        public AddTagDialog(List<Tag> tags)
        {
            InitializeComponent();

            tag = new Tag();
            this.tags = tags;

            this.DataContext = tag;
        }

        private void addTagCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addTagBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression tagID = idTB.GetBindingExpression(TextBox.TextProperty);
            tagID.UpdateSource();
            BindingExpression tagDescription = descrriptionTB.GetBindingExpression(TextBox.TextProperty);
            tagDescription.UpdateSource();

            tags.Add(tag);
            Close();
        }
    }
}
