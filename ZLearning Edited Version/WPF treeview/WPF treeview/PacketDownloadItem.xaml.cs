using Raqamli_Avlod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
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
using VideoLibrary;
using YoutubeExplode;

namespace WPF_treeview
{
    /// <summary>
    /// Interaction logic for PacketDownloadItem.xaml
    /// </summary>
    public partial class PacketDownloadItem : UserControl
    {
        public PacketDownloadItem()
        {
            InitializeComponent();
        }
        Firebase fire = new Firebase();
        public string Link { get; set; }
        public string DemoLink { get; set; }
        public string Payment { get; set; }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //SoundPlayer mplayer = new SoundPlayer("Musics/123.wav");
            //mplayer.Play();
        }

        private async void DownloadDemoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Functions.IsInternetConnected())
                {
                    DownloadDemoBtn.IsEnabled = false;
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.IsIndeterminate = true;

                    YoutubeClient client = new YoutubeClient();
                    var playlist = await client.GetPlaylistAsync(Link);
                    string videoId = playlist.Videos[0].Id;
                    YouTube youTube = YouTube.Default;
                    var videos = await youTube.GetAllVideosAsync("https://www.youtube.com/watch?v=" + videoId);
                    File.WriteAllBytes(Functions.PublicPath + videos.ToList()[1].FullName, await videos.ToList()[1].GetBytesAsync());
                    Process.Start(Functions.PublicPath + videos.ToList()[1].FullName);

                    progressBar.Visibility = Visibility.Hidden;
                    DownloadDemoBtn.IsEnabled = true;
                }
                else
                {
                    ZMessageBox.Show("Intenet ishlamayapti!", "Habar");
                }
            }
            catch
            {
                progressBar.Visibility = Visibility.Hidden;
                DownloadDemoBtn.IsEnabled = true;
                ZMessageBox.Show("Serverdan ma'lumot olishda qiyinchilik bor yoki o'qituvchi video yuklashda mualliflik huquqidan chetga chiqqan!", "Habar");
            }
        }

        private async void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadBtn.IsEnabled = false;
                if (Functions.IsInternetConnected())
                {
                    if (ZMessageBox.Show("Rostdan ham yuklamoqchimisz!", "So'rov") == ZMessageBox.ZButtons.Oktbn)
                    {
                        var control = await fire.GetControlAsync(); //control ni yuklab oldm

                        var get = await fire.client.GetAsync("Students/" + WindowsServer._RollMaker("0", InfoTxt.Text, PacketName.Text, AuthorName.Text));
                        var user = get.ResultAs<getDataStudentClass>();
                        if (int.Parse(control.Money) >= int.Parse(user.Cost))
                        {
                            progressBar.Visibility = Visibility.Visible;
                            progressBar.IsIndeterminate = false;
                            //asosiy code
                            string qoldiq_pul = (int.Parse(control.Money) - int.Parse(user.Cost)).ToString();
                            var new_control = new getControlClass();
                            new_control.Date = Functions.DateNow;
                            new_control.FIO = control.FIO;
                            new_control.MacAdress = Functions.Get_MacAdress();
                            new_control.Money = qoldiq_pul;
                            await fire.SetControlAsync(new_control);
                            user.Download = (int.Parse(user.Download) + 1).ToString();
                            await fire.SetDataStudentAsync(user, WindowsServer._RollMaker("0", InfoTxt.Text, PacketName.Text, AuthorName.Text));
                            //yuklash
                            YoutubeClient client = new YoutubeClient();
                            var playlist = await client.GetPlaylistAsync(user.Link);
                            progressBar.Value = 0; progressBar.Maximum = playlist.Videos.Count;

                            YouTube youtube = YouTube.Default;
                            foreach (var video in playlist.Videos)
                            {
                                try
                                {
                                    if (!Directory.Exists(Functions.PublicPath + "Packets/" + user.Teacher + " - " + user.Packet))
                                        Directory.CreateDirectory(Functions.PublicPath + "Packets/" + user.Teacher + " - " + user.Packet);

                                    var videoList = await youtube.GetAllVideosAsync("https://www.youtube.com/watch?v=" + video.Id);
                                    progressBar.Value = progressBar.Value + 1;
                                    File.WriteAllBytes(Functions.PublicPath + "Packets/" + user.Teacher + " - " + user.Packet + "/" + videoList.ToList()[1].FullName, await videoList.ToList()[1].GetBytesAsync());

                                    Functions.VideoEncryptor(Functions.PublicPath + "Packets/" + user.Teacher + " - " + user.Packet + "/" + videoList.ToList()[1].FullName);
                                }
                                catch { continue; }
                            }
                            progressBar.Value = 0;
                            progressBar.Visibility = Visibility.Hidden;
                            ZMessageBox.Show("Yuklash tamomlandi!", "Habar");
                        }
                        else (new Payment()).ShowDialog();
                    }
                }
                else ZMessageBox.Show("Internet mavjud emas!", "habar");
                DownloadBtn.IsEnabled = true;
            }
            catch
            {
                DownloadBtn.IsEnabled = true;
                progressBar.Visibility = Visibility.Hidden;
                ZMessageBox.Show("Server sizni so'rovingizga javob bera olmadi! Qayta urinib ko'ring!", "Server");
            }
        }
    }
}
