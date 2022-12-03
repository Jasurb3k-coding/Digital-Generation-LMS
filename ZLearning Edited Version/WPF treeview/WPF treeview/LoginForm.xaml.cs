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
using System.Windows.Media.Effects;
using Raqamli_Avlod;
using System.IO;

namespace WPF_treeview
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Page
    {
        public LoginForm()
        {
            InitializeComponent();
            //IsmTXT
            (new Functions()).SetPlaceHolder(IsmTxt, "Ism", Brushes.DimGray, Brushes.Gray, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
            (new Functions()).SetPlaceHolder(FamTxt, "Familiya", Brushes.DimGray, Brushes.Gray, new Thickness(0), new Thickness(0), Brushes.Snow, Brushes.Gray);
        }
        Firebase fire = new Firebase();
        getControlClass publicUser = new getControlClass();
        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Functions.IsInternetConnected())
            {
                var user = new getControlClass();
                user.Date = Functions.DateNow;
                user.FIO = IsmTxt.Text + " " + FamTxt.Text;
                user.MacAdress = Functions.Get_MacAdress();
                user.Money = publicUser.Money;
                await fire.SetControlAsync(user);
            }
            Functions.SaveConfigureJson(IsmTxt.Text, FamTxt.Text, "0");
            ZMessageBox.Show("Saqlandi!", "Habar");
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Functions.PublicPath + "Configure.json"))
            {
                Configure config = Functions.LoadConfigureJson();
                IsmTxt.Text = config.FirstName;
                FamTxt.Text = config.LastName;
                //MoneyTxt.Text = config.Money + " so'm";
            }
            else
            {
                Functions.SaveConfigureJson("Ism", "Familiya", "0");
            }
            try
            {
                if (Functions.IsInternetConnected())
                {
                    getControlClass user = await fire.GetControlAsync();
                    publicUser = user;
                    //if (user != null) MoneyTxt.Text = user.Money + " so'm";
                }
            }
            catch 
            {
                ZMessageBox.Show("Serverdan ma'lumot olishda qiyinchilik! Qayta urinib ko'ring!", "Habar");
            }
        }
    }
}
