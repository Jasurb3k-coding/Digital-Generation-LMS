using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using YoutubeExplode;

namespace Raqamli_Avlod
{
    /// <summary>
    /// Interaction logic for AuthorForm.xaml
    /// </summary>
    public partial class AuthorForm : Page
    {
        public AuthorForm()
        {
            InitializeComponent();
            (new Functions()).SetPlaceHolder(PacketNameTxt, "Paket nomi", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(AuthorNameTxt, "Muallif", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(CostTxt, "Paket narxi", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(InfoTxt, "Batafsil", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(PhoneTxt, "Telefon nomer", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(LessonLinkTxt, "Playlist linki", Brushes.Gray, Brushes.Silver, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
        }
        Firebase fire = new Firebase();
        private async void UploadPacketBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Functions.IsInternetConnected())
                {
                    string PlaylistID = YoutubeClient.ParsePlaylistId(LessonLinkTxt.Text);
                    YoutubeClient client = new YoutubeClient();
                    var playlist = await client.GetPlaylistAsync(PlaylistID);
                    getDataStudentClass user = new getDataStudentClass()
                    {
                        Cost = CostTxt.Text,
                        Download = "0",
                        Info = InfoTxt.Text,
                        Link = PlaylistID,
                        LessonCount = playlist.Videos.Count.ToString(),
                        Packet = PacketNameTxt.Text,
                        Payment = "No",
                        Phone = PhoneTxt.Text,
                        Roll = WindowsServer._RollMaker(CostTxt.Text, InfoTxt.Text, PacketNameTxt.Text, AuthorNameTxt.Text),
                        Teacher = AuthorNameTxt.Text,
                        Date = Functions.DateNow
                    };
                    await fire.SetDataStudentAsync(user, user.Roll);
                    ZMessageBox.Show("Muvaqqiyatli yuklandi! :)", "Habar");
                }
                else ZMessageBox.Show("Internet mavjud emas!", "Habar");
            }
            catch
            {
                ZMessageBox.Show("Yuklashda hatolik yuz berdi, maydonlarni to'ldirishda qoidalarga rioya qiling! Playlist linkini to'gri yozing!", "Hatolik");
            }
        }

        private void PaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            (new Payment()).ShowDialog();
        }
    }
}
