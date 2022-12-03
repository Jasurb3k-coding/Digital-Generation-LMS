using Raqamli_Avlod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Desktop.xaml
    /// </summary>
    public partial class Desktop : Page
    {
        public Desktop()
        {
            InitializeComponent();
        }

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                listbox.Items.Clear();
                DirectoryInfo info = new DirectoryInfo(Functions.PublicPath + "Packets");
                DirectoryInfo[] dirs = info.GetDirectories();
                foreach (var dir in dirs)
                {
                    string[] full_name = dir.Name.Split('-');
                    string authorName = full_name[0].Trim(), packetName = full_name[1].Trim();
                    PacketItem item = new PacketItem();
                    item.AuthorName.Text = authorName;
                    item.PacketName.Text = packetName;
                    item.PacketImg.ImageSource = new BitmapImage(new Uri(Functions.get_icon_for_packet(packetName)));
                    await Functions.Load_ControlsAsync(this, listbox, item);
                }
            }
            catch
            {
                ZMessageBox.Show(" Ba'zi ma'lumotlar o'chirilgan!", "Xabar");
            }
        }
        private async void listbox_MouseUpAsync(object sender, MouseButtonEventArgs e)
        {
            try
            {
                VideoListPanel.Children.Clear();
                PacketItem item = (PacketItem)listbox.SelectedItem;
                string authorName = item.AuthorName.Text;
                string packetName = item.PacketName.Text;
                PacketNameTxt.Text = packetName;
                DirectoryInfo info = new DirectoryInfo(Functions.PublicPath + "Packets/" + authorName + " - " + packetName);
                FileInfo[] files = info.GetFiles();
                VideosCountTxt.Text = files.Length.ToString() + " ta video";
                foreach (var file in files)
                {
                    PlayVideo video = new PlayVideo();
                    video.VideoNameTxt.Text = file.Name;
                    video.file_path = file.FullName;
                    await Functions.Load_ControlsAsync(this, VideoListPanel, video);
                }
            }
            catch
            {
                ZMessageBox.Show("Ma'lumot topilmadi!", "Xabar");
            }
        }

        private void searchtxt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                listbox.Items.Clear();
                string text = searchtxt.Text.ToLower();
                DirectoryInfo info = new DirectoryInfo(Functions.PublicPath + "Packets");
                var dirs = info.GetDirectories();
                foreach (var dir in dirs)
                {
                    string[] lines = dir.Name.Split('-');
                    string Author = lines[0].Trim(), Packet = lines[1].Trim();
                    if (Author.ToLower().Contains(text) || Packet.ToLower().Contains(text))
                    {
                        var item = new PacketItem();
                        item.AuthorName.Text = Author;
                        item.PacketName.Text = Packet;
                        item.PacketImg.ImageSource = new BitmapImage(new Uri(Functions.get_icon_for_packet(Packet)));
                        listbox.Items.Add(item);
                    }
                }
            }
            catch { }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listbox.SelectedItems.Count > 0)
                {
                    if (ZMessageBox.Show("Rostdan ham o'chirmoqchimisiz?", "Xabar") == ZMessageBox.ZButtons.Oktbn)
                    {
                        PacketItem item = (PacketItem)listbox.SelectedItem;
                        DirectoryInfo info = new DirectoryInfo(Functions.PublicPath + "Packets/" + item.AuthorName.Text + " - " + item.PacketName.Text);
                        var files = info.GetFiles();
                        foreach (var file in files) File.Delete(file.FullName);
                        Directory.Delete(info.FullName);
                        listbox.Items.Remove(listbox.SelectedItem);
                        ZMessageBox.Show("O'chirildi!", "Xabar");
                    }
                }
                else ZMessageBox.Show("Avval biror to'plamni tanlang!", "Xabar");
            }
            catch 
            {
                ZMessageBox.Show("Fayllar foydalanilyapti", "Xabar");
            }
        }
    }
}
