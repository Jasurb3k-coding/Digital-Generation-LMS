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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_treeview;

namespace Raqamli_Avlod
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        Firebase fire = new Firebase();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var ob = await fire.getDataCarta();
                CartaAuthorTxt.Text = ob.username;
                CartaInfoTxt.Text = ob.About;
                CartaPingTxt.Text = ob.Pin;
                CartaTypeTxt.Text = ob.Type;
            }
            catch
            {
                ZMessageBox.Show("Serverdan ma'lumot olishda qiyinchilik yuz berdi!", "Habar");
            }
        }
    }
}
