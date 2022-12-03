using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Raqamli_Avlod
{
    /// <summary>
    /// Interaction logic for ZMessageBox.xaml
    /// </summary>
    public partial class ZMessageBox : Window
    {
        public ZMessageBox()
        {
            InitializeComponent();
        }
        static ZButtons Btn { get; set; }
        public enum ZButtons
        {
            Oktbn,
            CloseBtn
        }
        public static ZButtons Show(string Xabar, string Sarlavha)
        {
            ZMessageBox form = new ZMessageBox();
            form.Title = Sarlavha;
            form.MessageTxt.Text = Xabar;
            form.ShowDialog();
            return Btn;
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Btn = ZButtons.Oktbn;
            this.Hide();        
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Btn = ZButtons.CloseBtn;
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Btn =ZButtons.CloseBtn;
        }
    }
}
