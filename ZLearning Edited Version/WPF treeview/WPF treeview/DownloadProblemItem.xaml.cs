using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using WPF_treeview;

namespace Raqamli_Avlod
{
    /// <summary>
    /// Interaction logic for DownloadProblemItem.xaml
    /// </summary>
    public partial class DownloadProblemItem : UserControl
    {
        public DownloadProblemItem()
        {
            InitializeComponent();
        }
        public List<getProblemClass> PublicUser = new List<getProblemClass>();
        private void DownloadBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            File.WriteAllText(Functions.PublicPath + "Contest/" + ProblemsNameTxt.Text + ".json", JsonConvert.SerializeObject(PublicUser));
            ZMessageBox.Show("Yuklandi!", "Habar");
        }
    }
}
