using forma_1;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for Contest.xaml
    /// </summary>
    public partial class Contest : Page
    {
        public Contest()
        {
            InitializeComponent();
        }
        Firebase fire = new Firebase();
        public static string eventMessage { get; set; }
        private void CopyProblemTextBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(ProblemTextTxt.Text);
            Functions.ToolTipAnimation(SharxToolTip1);
        }

        private void CopyCodeTextBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(CodeTxt.Text);
            Functions.ToolTipAnimation(SharxToolTip2);
        }

        private void LoadFileBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Nullable<bool> result = ofd.ShowDialog();
            if (result.Value)
            {
                CodeTxt.Text = File.ReadAllText(ofd.FileName);
            }
        }
        ZCompilator compilator = new ZCompilator();
        private void CompileCodeBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string result = compilator.Compile(CodeTxt.Text, LangCombobox.Text, ProblemCombobox.Text, "Qabul qilindi", "Noto'g'ri javob", "Kompilatorda xatolik");
            ZMessageBox.Show(result, "Xabar");

            if (result == "Qabul qilindi")
            {
                if (!File.Exists(Functions.PublicPath + "SolvedProblem.txt")) File.WriteAllText(Functions.PublicPath + "SolvedProblem.txt", "");
                var lines = File.ReadAllLines(Functions.PublicPath + "SolvedProblem.txt").ToList();
                if (!lines.Contains(ProblemCombobox.Text)) lines.Add(ProblemCombobox.Text);
                File.WriteAllLines(Functions.PublicPath + "SolvedProblem.txt", lines.ToArray());
                SolvedCountTxt.Text = lines.Count.ToString() + "/" + ProblemCombobox.Items.Count.ToString();
                SolvedProcentTxt.Text = (lines.Count * 100 / ProblemCombobox.Items.Count).ToString() + "%";
            }
        }

        private async void RefreshBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var get = await fire.client.GetAsync("Problems");
                var list = get.ResultAs<Dictionary<string, List<getProblemClass>>>();
                ProblemItemsPanel.Children.Clear();
                foreach (var l in list)
                {
                    string ProblemName = l.Key;
                    string ProblemCount = (l.Value.Count - 1).ToString();
                    var item = new DownloadProblemItem();
                    item.PublicUser = l.Value;
                    item.ProblemsNameTxt.Text = ProblemName;
                    item.ProblemsCountTxt.Text = ProblemCount;
                    await Functions.Load_ControlsAsync(this, ProblemItemsPanel, item);
                }
               
            }
            catch 
            {
                ZMessageBox.Show("Serverdan ma'lumot yuklashda xatolik yuz berdi! Qayta urinib ko'ring!", "Xabar");
            }
        }

        private void RefreshOfflineBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Functions.PublicPath + "Contest");
                var files = info.GetFiles();
                ProblemCombobox.Items.Clear();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".json")
                    {
                        List<getProblemClass> problems = JsonConvert.DeserializeObject<List<getProblemClass>>(File.ReadAllText(file.FullName));
                        problems.RemoveAt(0);
                        for (int i = 1; i <= problems.Count; i++)
                        {
                            ProblemCombobox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file.Name) + "-" + i.ToString());
                        }
                    }
                }
                ProblemCombobox.SelectedIndex = 0;
                //
                if (!string.IsNullOrEmpty(ProblemCombobox.Text))
                {
                    if (!File.Exists(Functions.PublicPath + "SolvedProblem.txt")) File.WriteAllText(Functions.PublicPath + "SolvedProblem.txt", "");
                    SolvedCountTxt.Text = File.ReadAllLines(Functions.PublicPath + "SolvedProblem.txt").Length.ToString() + "/" + ProblemCombobox.Items.Count.ToString();
                    SolvedProcentTxt.Text = (File.ReadAllLines(Functions.PublicPath + "SolvedProblem.txt").Length * 100 / ProblemCombobox.Items.Count).ToString() + "%";
                }
                //
                ProblemsListBox.Items.Clear();
                foreach (var item in ProblemCombobox.Items)
                {
                    var chBox = new CheckBox();
                    chBox.Foreground = Brushes.Black;
                    chBox.Content = item.ToString();
                    ProblemsListBox.Items.Add(chBox);
                }
            }
            catch 
            {
                ZMessageBox.Show("Ma'lumot yuklashda xatolik yuz berdi! Qayta urinib ko'ring!", "Xabar");
            }
        }

        private void ProblemCombobox_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ProblemCombobox.Text))
                {
                    string[] common = ProblemCombobox.Text.Split('-');
                    string FileName = common[0] + ".json";
                    int Order = int.Parse(common[1]);
                    string Json = File.ReadAllText(Functions.PublicPath + "Contest/" + FileName);
                    var list = JsonConvert.DeserializeObject<List<getProblemClass>>(Json);
                    list.RemoveAt(0);
                    ProblemTextTxt.Text = list[Order - 1].Text;
                }
            }
            catch 
            {
                ZMessageBox.Show("Ma'lumot yuklashda xatolik yuz berdi! Qayta urinib ko'ring!", "Xabar");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshOfflineBtn_MouseUp(sender, null);
            ProblemCombobox_DropDownClosed(sender, null);
            RefreshBtn_MouseUp(sender, null);
            
        }
        System.Timers.Timer timer = new System.Timers.Timer();
        private void StartContest_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string Token = TokenTxt.Text;
            var _Masala = new List<string>();
            foreach(var item in ProblemsListBox.Items)
            {
                var ob = (CheckBox)item;
                if (ob.IsChecked == true) _Masala.Add(ob.Content.ToString());
            }

            ContestBot contestBot = new ContestBot();
            contestBot.Start(Token, _Masala);
            //
            timer.Interval = 1;
            timer.Elapsed += vaqt_ketdi;
            timer.Start();
        }

        private void vaqt_ketdi(object sender, ElapsedEventArgs e)
        {
            if (!ActionsListbox.Items.Contains(eventMessage))
            {
                ActionsListbox.Items.Add(eventMessage);
            }
        }
    }
}
