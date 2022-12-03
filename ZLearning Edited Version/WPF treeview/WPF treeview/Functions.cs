using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Media.Effects;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.AccessControl;
using Raqamli_Avlod;
using FireSharp.Extensions;
using System.Text.RegularExpressions;
using YoutubeExplode;
using VideoLibrary;

namespace WPF_treeview
{
    class Functions
    {
        string placeHolderText = null;
        SolidColorBrush gotColor = Brushes.White, lostColor = Brushes.Silver;
        Brush gotForeColor = Brushes.Black, lostForeColor = Brushes.Gray;
        Thickness gotBorderThickness = new Thickness(0), lostBoderThickness = new Thickness(0);
        public static string DateNow = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        public static string PublicPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ZLearning Desktop\";
        public void SetPlaceHolder(TextBox tBox, string text, SolidColorBrush got, SolidColorBrush lost, Thickness gotThickness, Thickness lostThickness, Brush gForeColor, Brush lForeColor)
        {
            tBox.GotFocus += tBox_GotFocus;
            tBox.LostFocus += tBox_LostFocus;
            placeHolderText = text;
            gotColor = got;
            lostColor = lost;
            gotBorderThickness = gotThickness;
            lostBoderThickness = lostThickness;
            gotForeColor = gForeColor;
        }
        private void tBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = placeHolderText;
                ((TextBox)sender).Foreground = lostColor;
                ((TextBox)sender).BorderThickness = lostBoderThickness;
                ((TextBox)sender).Foreground = lostForeColor;
            }
        }

        private void tBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
            ((TextBox)sender).Foreground = gotColor;
            ((TextBox)sender).BorderThickness = gotBorderThickness;
            ((TextBox)sender).Foreground = gotForeColor;
        }
        public static void animation_opacity(Control control, double from, double to, double time)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, new Duration(TimeSpan.FromMilliseconds(time)));
            control.BeginAnimation(Window.OpacityProperty, doubleAnimation);
        }
        public static void ToolTipAnimation(ToolTip SharxToolTip)
        {
            SharxToolTip.IsOpen = true;
            SharxToolTip.Opacity = 0;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 1));
            SharxToolTip.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }
        public static string get_icon_for_packet(string packetName)
        {
            if (packetName.ToLower().Contains("c#")) return System.IO.Path.GetFullPath(@"..\..\LangImages/C#.png");
            else if (packetName.ToLower().Contains("c++")) return System.IO.Path.GetFullPath(@"..\..\LangImages/c++.png");
            else if (packetName.ToLower().Contains(" c ")) return System.IO.Path.GetFullPath(@"..\..\LangImages/C_.png");
            else if (packetName.ToLower().Contains("python")) return System.IO.Path.GetFullPath(@"..\..\LangImages/Python.png");
            else if (packetName.ToLower().Contains("swift")) return System.IO.Path.GetFullPath(@"..\..\LangImages/Swift.png");
            else if (packetName.ToLower().Contains("php")) return System.IO.Path.GetFullPath(@"..\..\LangImages\PHP.png");
            else if (packetName.ToLower().Contains("java")) return System.IO.Path.GetFullPath(@"..\..\LangImages/Java.png");
            else if (packetName.ToLower().Contains("css")) return System.IO.Path.GetFullPath(@"..\..\LangImages/CSS.png");
            else if (packetName.ToLower().Contains("html")) return System.IO.Path.GetFullPath(@"..\..\LangImages/HTML.png");
            else if (packetName.ToLower().Contains("cmd")) return System.IO.Path.GetFullPath(@"..\..\LangImages/CMD.png");
            else if (packetName.ToLower().Contains("linux")) return System.IO.Path.GetFullPath(@"..\..\LangImages/Linux.png");
            else if (packetName.ToLower().Contains("robot")) return System.IO.Path.GetFullPath(@"..\..\LangImages/bot.png");
            else if (packetName.ToLower().Contains("video")) return System.IO.Path.GetFullPath(@"..\..\LangImages/video.png");
            else return System.IO.Path.GetFullPath(@"..\..\LangImages/default.png");
        }
        private delegate void funskiya_delegat(ListBox ct, PacketItem it);
        public static async Task Load_ControlsAsync(Page window, ListBox listbox, PacketItem control)
        {
            await Task.Run(() =>
            {
                window.Dispatcher.Invoke(new Action(() =>
                {
                    listbox.Items.Add(control);
                }));
            });
        }
        public static async Task Load_ControlsAsync(Page window, StackPanel listbox, MessageDownloadItem control)
        {
            await Task.Run(() =>
            {
                window.Dispatcher.Invoke(new Action(() =>
                {
                    listbox.Children.Add(control);
                }));
            });
        }
        public static async Task Load_ControlsAsync(Page window, WrapPanel wrapPanel, PlayVideo control)
        {
            await Task.Run(() =>
            {
                window.Dispatcher.Invoke(new Action(() =>
                {
                    wrapPanel.Children.Add(control);
                }));
            });
        }
        public static async Task Load_ControlsAsync(Page window, WrapPanel wrapPanel, PacketDownloadItem control)
        {
            await Task.Run(() =>
            {
                window.Dispatcher.Invoke(new Action(() =>
                {
                    wrapPanel.Children.Add(control);
                }));
            });
        }
        public static async Task Load_ControlsAsync(Page window, StackPanel stackPanel, DownloadProblemItem control)
        {
            await Task.Run(() =>
            {
                window.Dispatcher.Invoke(new Action(() =>
                {
                    stackPanel.Children.Add(control);
                }));
            });
        }
        public static void menu_design(DockPanel MenuDockPanel, object sender)
        {
            var controls = MenuDockPanel.Children;
            foreach (var control in controls)
            {
                if (((TextBlock)control).Name == ((TextBlock)sender).Name) ((TextBlock)sender).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#107EFF "));
                else ((TextBlock)control).Foreground = Brushes.Black;
            }
        }
        public static string Get_MacAdress()
        {
            var macAddr =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();
            return macAddr;
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReversedValue);
        public static bool IsInternetConnected()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        public static void AccessToFolder(string Path)
        {
            string Username = Environment.UserName;
            string Domain = Environment.UserDomainName;

            DirectoryInfo info = new DirectoryInfo(Path);
            DirectorySecurity security = new DirectorySecurity();
            security.AddAccessRule(new FileSystemAccessRule(Domain + @"\" + Username, FileSystemRights.FullControl, AccessControlType.Allow));
            info.SetAccessControl(security);
        }
        public static void FirstWork()
        {
            try
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ZLearning Desktop")) 
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ZLearning Desktop");
                
                if (!Directory.Exists(PublicPath + "Packets")) Directory.CreateDirectory(PublicPath + "Packets");
                if (!Directory.Exists(PublicPath + "Messages")) Directory.CreateDirectory(PublicPath + "Messages");
                if (!Directory.Exists(PublicPath + "Contest")) Directory.CreateDirectory(PublicPath + "Contest");
                
                if (!Directory.Exists(PublicPath + "Packets/Abrorbek Abdullayev - PHP dasturlash tili (boshlang'ich)")) 
                    Directory.CreateDirectory(PublicPath + "Packets/Abrorbek Abdullayev - PHP dasturlash tili (boshlang'ich)");
                
                if (!Directory.Exists(PublicPath + "Packets/Digital Generation Uzbekistan - Robototehnika"))
                    Directory.CreateDirectory(PublicPath + "Packets/Digital Generation Uzbekistan - Robototehnika");
               
                if (!Directory.Exists(PublicPath + "Packets/Muhammadkarim To'xtaboyev - C# da sizni qiziqtirgan loyihalar to'plami"))
                    Directory.CreateDirectory(PublicPath + "Packets/Muhammadkarim To'xtaboyev - C# da sizni qiziqtirgan loyihalar to'plami");
                
                if (!Directory.Exists(PublicPath + "Packets/Muhammadkarim To'xtaboyev - C# dasturlash tili, Console, Windows Form, UI Frameworks"))
                    Directory.CreateDirectory(PublicPath + "Packets/Muhammadkarim To'xtaboyev - C# dasturlash tili, Console, Windows Form, UI Frameworks");
               
                if (!Directory.Exists(PublicPath + "Packets/Muhammadkarim To'xtaboyev - CMD tricklardan foydalanish (boshlang'ich)"))
                    Directory.CreateDirectory(PublicPath + "Packets/Muhammadkarim To'xtaboyev - CMD tricklardan foydalanish (boshlang'ich)");
               
                if (!Directory.Exists(PublicPath + "Packets/Qudrat Abdurahimov - C++ dasturlash tilini o'raganamiz"))
                    Directory.CreateDirectory(PublicPath + "Packets/Qudrat Abdurahimov - C++ dasturlash tilini o'raganamiz");
               
                if (!Directory.Exists(PublicPath + "Packets/Suxrob Hojiyev - HTML tili (boshlang'ich)"))
                    Directory.CreateDirectory(PublicPath + "Packets/Suxrob Hojiyev - HTML tili (boshlang'ich)");
              
                if (!Directory.Exists(PublicPath + "Packets/Zarif Qodirov - C++ dasturlash tili (boshlang'ich)"))
                    Directory.CreateDirectory(PublicPath + "Packets/Zarif Qodirov - C++ dasturlash tili (boshlang'ich)");


            }
            catch { }
        }
        public static void SaveConfigureJson(string FirstName, string LastName, string Money)
        {
            var cfg = new Configure()
            {
                FirstName = FirstName,
                LastName = LastName,
                Money = Money
            };
            string json = cfg.ToJson();
            File.WriteAllText(PublicPath + "Configure.json", json);
        }
        public static Configure LoadConfigureJson()
        {
            if (!File.Exists(PublicPath + "Configure.json"))
            {
                SaveConfigureJson("Ism", "Familiya", "0");
            }
            return JsonConvert.DeserializeObject<Configure>(File.ReadAllText(PublicPath + "Configure.json"));
        }
        public static void VideoEncryptor(string Path)
        {
            if (File.Exists(Path))
            {
                byte[] baytlar = File.ReadAllBytes(Path);
                byte Temp = baytlar[3];
                baytlar[3] = baytlar[5];
                baytlar[5] = Temp;
                File.WriteAllBytes(Path, baytlar);
            }
        }

    }
   
}
