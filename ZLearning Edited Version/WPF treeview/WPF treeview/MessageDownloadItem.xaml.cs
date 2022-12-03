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
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_treeview;

namespace Raqamli_Avlod
{
    /// <summary>
    /// Interaction logic for MessageDownloadItem.xaml
    /// </summary>
    public partial class MessageDownloadItem : UserControl
    {
        public MessageDownloadItem()
        {
            InitializeComponent();
        }

        private void CopyBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(Messagetxt.Text);
            Functions.ToolTipAnimation(SharxToolTip);
        }
    }
}
