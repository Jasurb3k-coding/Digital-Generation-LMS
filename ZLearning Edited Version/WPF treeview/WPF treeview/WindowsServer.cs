using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Raqamli_Avlod
{
    class WindowsServer
    {
        public static void Student_json_write(string Cost, string DemoLink, string Download, string Info, string LessonCount, string Link, string PacketName, string Payment, string Roll, string Author)
        {
            var user = new getDataStudentClass()
            {
                Cost = Cost,
                DemoLink = DemoLink,
                Download = Download,
                Info = Info,
                Link = Link,
                Packet = PacketName,
                Payment = Payment,
                Roll = Roll,
                Teacher = Author
            };
            var dict_user = new KeyValuePair<string, getDataStudentClass>(Roll, user);
            string json = JsonConvert.SerializeObject(dict_user);
            //write string to file
            using(WebClient client = new WebClient())
            {
                client.Headers["content-type"] = "application/json";
                client.UploadFile(@"Fonts/", "post", "salom.json");
            }
        }
        public static string _RollMaker(string Cost, string Info, string Packetname, string Author)
        {
            string result = "";
            result += (Info[Info.Length - 1] * Info[0] - Info[Info.Length / 2]).ToString();
            result += (Packetname[Packetname.Length / 2] + 1).ToString();
            result += (Packetname[Packetname.Length - 1] * 3).ToString();
            result += Author.Substring(Author.Length / 2, 2) + Author.Substring(Author.Length / 3, 2);
            string _result = "";
            foreach (var c in result) if (char.IsLetterOrDigit(c)) _result += c;
            return _result;
        }
    }
    public class getDataCartaClass
    {
        public string About { get; set; }
        public string Pin { get; set; }
        public string Type { get; set; }
        public string username { get; set; }
    }
    public class getDataStudentClass
    {
        public string Cost { get; set; }
        public string DemoLink { get; set; }
        public string Download { get; set; }
        public string Info { get; set; }
        public string Link { get; set; }
        public string LessonCount { get; set; }
        public string Packet { get; set; }
        public string Payment { get; set; }
        public string Phone { get; set; }
        public string Roll { get; set; }
        public string Teacher { get; set; }
        public string Date { get; set; }

    }
    public class getControlClass
    {
        public string Date { get; set; }
        public string FIO { get; set; }
        public string Money { get; set; }
        public string MacAdress { get; set; }
    }
    public class Configure
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Money { get; set; }
    }
    public class getProblemClass
    {
        public Test Test1 { get; set; }
        public Test Test2 { get; set; }
        public Test Test3 { get; set; }
        public string Text { get; set; }
    }
    public class Test
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
