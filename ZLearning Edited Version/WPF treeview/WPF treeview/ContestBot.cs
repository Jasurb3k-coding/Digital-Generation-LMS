using forma_1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using WPF_treeview;

namespace Raqamli_Avlod
{
    class ContestBot
    {
        TelegramBotClient Bot;
        Dictionary<long, ContestBotUserShablon> Dict = new Dictionary<long, ContestBotUserShablon>();
        List<string> Masalalar_List = new List<string>();
        public void Start(string _Token, List<string> _Masalalar)
        {
            Masalalar_List = _Masalalar;
            Bot = new TelegramBotClient(_Token);
            Bot.OnMessage += Xabar_kelganda;
            Bot.StartReceiving();
            Contest.eventMessage = "Chempionat boshlandi!";
        }

        private async void Xabar_kelganda(object sender, MessageEventArgs e)
        {
            string _Text = e.Message.Text;
            long _Id = e.Message.Chat.Id;
            if (!Dict.Keys.Contains(_Id)) Dict[_Id] = new ContestBotUserShablon();

            if(_Text == "/start" || !Dict.Keys.Contains(_Id))
            {
                await Bot.SendTextMessageAsync(_Id, "FIO ni yuboring!");
                Dict[_Id].Oxirgi_Buyruq = "FIO";
            }
            else if(Dict[_Id].Oxirgi_Buyruq == "FIO" || _Text == "Menyuga qaytish")
            {
                if(string.IsNullOrEmpty(Dict[_Id].FIO)) Dict[_Id].FIO = _Text;
                if(!Masalalar_List.Contains("Menyuga qaytish")) Masalalar_List.Add("Menyuga qaytish");
                var Reply = Klaviatura(Masalalar_List.ToArray());
                await Bot.SendTextMessageAsync(_Id, "Qaysi masalani yubormoqchisiz!", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Reply);
                Dict[_Id].Oxirgi_Buyruq = "Masala";
            }
            else if(Dict[_Id].Oxirgi_Buyruq == "Masala")
            {
                Dict[_Id].Masala = _Text;
                var Reply = Klaviatura(new string[] {"Python", "C++", "Java", "Menyuga qaytish"});
                await Bot.SendTextMessageAsync(_Id, "Dasturlash tilini tanlang!", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Reply);
                Dict[_Id].Oxirgi_Buyruq = "Til";
            }
            else if(Dict[_Id].Oxirgi_Buyruq == "Til")
            {
                Dict[_Id].TIl = _Text;
                Button btn = new Button();
                //
                string[] common = Dict[_Id].Masala.Split('-');
                string FileName = common[0] + ".json";
                int Order = int.Parse(common[1]);
                string Json = File.ReadAllText(Functions.PublicPath + "Contest/" + FileName);
                var list = JsonConvert.DeserializeObject<List<getProblemClass>>(Json);
                list.RemoveAt(0);;
                //
                var Reply = Klaviatura(new string[] { "Menyuga qaytish" });
                await Bot.SendTextMessageAsync(_Id, "Yechimni yuboring!\nMasala sharti:\n" + list[Order - 1].Text, Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Reply);
                Dict[_Id].Oxirgi_Buyruq = "Yechim";
            }
            else if(Dict[_Id].Oxirgi_Buyruq == "Yechim")
            {
                Dict[_Id].Yechim = _Text;
                ZCompilator compiler = new ZCompilator();
                string _Res = compiler.Compile(Dict[_Id].Yechim, Dict[_Id].TIl, Dict[_Id].Masala, "Qabul qilindi!", "Xatolik", "Kompilatorda xatolik!");
                await Bot.SendTextMessageAsync(_Id, _Res);
            }
        }
        private ReplyKeyboardMarkup Klaviatura(string[] Arr)
        { 
            List<KeyboardButton[]> cols = new List<KeyboardButton[]>();
            foreach(var Elem in Arr)
            {
                var keyboardBtn = new KeyboardButton(Elem);
                var row = new List<KeyboardButton>();
                row.Add(keyboardBtn);
                cols.Add(row.ToArray());
            }
            return new ReplyKeyboardMarkup(cols.ToArray());
        }
    }
    public class ContestBotUserShablon
    {
        public string FIO { get; set; }
        public string Masala { get; set; }
        public string TIl { get; set; }
        public string Yechim { get; set; }
        public string Oxirgi_Buyruq { get; set; }
    }

}
