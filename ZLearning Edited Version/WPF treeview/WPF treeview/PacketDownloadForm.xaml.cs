using Raqamli_Avlod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace WPF_treeview
{
    /// <summary>
    /// Interaction logic for PacketDownloadForm.xaml
    /// </summary>
    public partial class PacketDownloadForm : Page
    {
        public PacketDownloadForm()
        {
            InitializeComponent();
        }
        Firebase fire = new Firebase();
        List<getDataStudentClass> list = new List<getDataStudentClass>();
        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            list = await fire.GetDataStudentAsync();
            One("Umumiy", true);
        }
        private async void One(string Key,  bool all)
        {
            try
            {
                PacketItemsPanel.Children.Clear();
                if (!all)
                {
                    foreach (var l in list)
                    {
                        if (l.Packet.ToLower().Contains(Key.ToLower()))
                        {
                            PacketDownloadItem item = new PacketDownloadItem();
                            item.InfoTxt.Text = l.Info;
                            item.DownloadTxt.Text = l.Download;
                            item.PacketName.Text = l.Packet;
                            item.AuthorName.Text = l.Teacher;
                            item.Link = l.Link;
                            item.LessonCountTxt.Text = l.LessonCount + " ta";
                            item.Payment = l.Payment;
                            item.DemoLink = l.DemoLink;
                            //item.MoneyTxt.Text = l.Cost;
                            item.PacketImg.ImageSource = new BitmapImage(new Uri(Functions.get_icon_for_packet(l.Packet)));
                            await Functions.Load_ControlsAsync(this, PacketItemsPanel, item);
                        }
                    }
                }
                else
                {
                    foreach (var l in list)
                    {
                        PacketDownloadItem item = new PacketDownloadItem();
                        if (l.Payment.ToLower() == "yes")
                        {
                            item.InfoTxt.Text = l.Info;
                            item.DownloadTxt.Text = l.Download;
                            item.PacketName.Text = l.Packet;
                            item.AuthorName.Text = l.Teacher;
                            item.Link = l.Link;
                            item.LessonCountTxt.Text = l.LessonCount + " ta";
                            item.DemoLink = l.DemoLink;
                            //item.MoneyTxt.Text = l.Cost + " so'm";
                            item.PacketImg.ImageSource = new BitmapImage(new Uri(Functions.get_icon_for_packet(l.Packet)));
                            await Functions.Load_ControlsAsync(this, PacketItemsPanel, item);
                        }
                    }
                }
            }
            catch { }
        }
        private void BtnUmumiy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, true);
        }

        private void BtnCPlusbtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnCSharp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnJava_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnPython_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnJS_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnPhp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnAndroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void BtnArduino_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, sender);
            One(((TextBlock)sender).Text, false);
        }

        private void searchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) search();
        }

        private void SearchBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            search();
        }
        private async void search()
        {
            string x = searchTxt.Text.ToLower();
            if (searchTxt.Text == "Izlash") x = "";
            PacketItemsPanel.Children.Clear();
            foreach (var l in list)
            {
                if (l.Packet.ToLower().Contains(x) ||
                    l.Cost.ToLower().Contains(x) ||
                    l.Info.ToLower().Contains(x) ||
                    l.Payment.ToLower().Contains(x) ||
                    l.Teacher.ToLower().Contains(x))
                {
                    var item = new PacketDownloadItem();
                    //item.MoneyTxt.Text = l.Cost + " so'm"; item.DemoLink = l.DemoLink;
                    item.DownloadTxt.Text = l.Download; item.InfoTxt.Text = l.Info;
                    item.Link = l.Link;
                    item.LessonCountTxt.Text = l.LessonCount;
                    item.PacketName.Text = l.Packet; item.Payment = l.Payment;
                    item.AuthorName.Text = l.Teacher;
                    item.PacketImg.ImageSource = new BitmapImage(new Uri(Functions.get_icon_for_packet(l.Packet)));
                    await Functions.Load_ControlsAsync(this, PacketItemsPanel, item);
                }
            }
        }

        private void RefreshBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Functions.menu_design(MenuDockPanel, BtnUmumiy);
            One(BtnUmumiy.Text, true);
        }
    }
}
