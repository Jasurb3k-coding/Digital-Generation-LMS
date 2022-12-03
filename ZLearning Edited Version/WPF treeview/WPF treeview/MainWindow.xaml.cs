using Raqamli_Avlod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace WPF_treeview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Firebase fire = new Firebase();
        MessageForm msgForm = new MessageForm();
        Desktop desktop = new Desktop();
        LoginForm loginForm = new LoginForm();
        Contest contest = new Contest();
        PacketDownloadForm packetDownloadForm = new PacketDownloadForm();
        AuthorForm authorForm = new AuthorForm();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Functions.AccessToFolder(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Functions.FirstWork();
            //introduction
            if (!File.Exists(Functions.PublicPath + "Configure.json"))
            {
                Functions.SaveConfigureJson("Ism", "Familiya", "0");
            }
            //internet control
            var conf = Functions.LoadConfigureJson();
            try
            {
                if (Functions.IsInternetConnected())
                {
                    var control = await fire.GetControlAsync();

                    if (control == null)
                    {
                        await fire.SetControlAsync(new getControlClass() { Date = Functions.DateNow, FIO = conf.FirstName + " " + conf.LastName, MacAdress = Functions.Get_MacAdress(), Money = "0" });
                    }
                    else
                    {
                        if (control.Money != conf.Money)
                        {
                            Functions.SaveConfigureJson(conf.FirstName, conf.LastName, control.Money);
                        }
                        await fire.SetControlAsync(new getControlClass() { Date = Functions.DateNow, FIO = conf.FirstName + " " + conf.LastName, MacAdress = Functions.Get_MacAdress(), Money = control.Money });
                    }

                }
                //main
                if (!File.Exists(Functions.PublicPath + "MessageCache.txt")) File.WriteAllText(Functions.PublicPath + "MessageCache.txt", "");
                msgForm.MessagePanel.Children.Clear();
                if (Functions.IsInternetConnected())
                {
                    int newMessageCount = 0;
                    var get = await fire.client.GetAsync("Message");
                    int k = 1;
                    var dict = get.ResultAs<List<string>>();
                    dict.Reverse();
                    foreach (var d in dict)
                    {
                        if (d != null)
                        {
                            MessageDownloadItem item = new MessageDownloadItem();
                            item.MessageOrderTxt.Text = k.ToString();
                            item.Messagetxt.Text = d;
                            await Functions.Load_ControlsAsync(msgForm, msgForm.MessagePanel, item);
                            //save msg
                            msgForm.msgList += d + "\n";
                            if (!File.ReadAllText(Functions.PublicPath + "MessageCache.txt").Contains(d)) newMessageCount++;
                            k++;
                        }
                    }
                    k = 1;
                }
            }
            catch
            {
                ZMessageBox.Show("Serverdan ma'lumot olishda qiyinchilik yuz berdi!", "Habar");
            }
        }

        private void dragPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //this.DragMove();
            if(e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
                else this.WindowState = WindowState.Normal;
            }
        }

        private void DesktopBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = desktop;
        }

        private void Messagebtn_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = msgForm;
            File.WriteAllText(Functions.PublicPath + "MessageCache.txt", msgForm.msgList);
            if (msgForm.MessagePanel.Children.Count == 0) Window_Loaded(sender, null);
        }

        private void ProblemsBtn_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = contest;
        }

        private void PacketDownloadBtn_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = packetDownloadForm;
        }

        private void PacketUploadBtn_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = authorForm;
        }

        private void SettingsBtn_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _Frame.Content = loginForm;
        }

        private void MenuBorder_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MenuBorder.Visibility = Visibility.Collapsed;
        }

        private void MenuBtn_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MenuBorder.Visibility = Visibility.Visible;
        }

        private void minBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maxBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        private void exitBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
