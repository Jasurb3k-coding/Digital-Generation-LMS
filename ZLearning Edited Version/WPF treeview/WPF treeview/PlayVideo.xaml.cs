using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Raqamli_Avlod;
namespace WPF_treeview
{
    /// <summary>
    /// Interaction logic for PlayVideo.xaml
    /// </summary>
    public partial class PlayVideo : UserControl
    {
        public PlayVideo()
        {
            InitializeComponent();
        }
        public string file_path = null;

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string CachePath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                var baytlar = File.ReadAllBytes(file_path);
                byte temp = baytlar[5];
                baytlar[5] = baytlar[3];
                baytlar[3] = temp;
                File.WriteAllBytes(CachePath + "/z.mp4", baytlar);
                Process.Start(CachePath + "/z.mp4");
            }
            catch
            {
                ZMessageBox.Show("Faylni shifrdan ochish xatolik yuz berdi!", "Habar");
            }
        }
    }
}
