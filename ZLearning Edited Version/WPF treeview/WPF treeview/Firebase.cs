using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Raqamli_Avlod;
using VideoLibrary;

namespace WPF_treeview
{
    public class Firebase
    {
        IFirebaseConfig config = new FirebaseConfig() 
        {
            AuthSecret = "Buzut1VQR4tgWUAqRYOZFJIIELx4hiHWZVURTHs6",
            BasePath = "https://zlearning-276906.firebaseio.com/"
        };
        public IFirebaseClient client;
        public Firebase()
        {
            client = new FirebaseClient(config);
        }
        
        public async Task<getDataCartaClass> getDataCarta() 
        {
            var get = await client.GetAsync("Carta");
            return get.ResultAs<getDataCartaClass>();
        }
        public async Task<List<getDataStudentClass>> GetDataStudentAsync()
        {
            var get = await client.GetAsync("Students");
            var ob = get.ResultAs<Dictionary<string, getDataStudentClass>>();
            return ob.Values.ToList();
        }
        public async Task SetDataStudentAsync(getDataStudentClass ob, string roll)
        {
            await client.SetAsync<getDataStudentClass>("Students/" + roll, ob);
        }
        public async Task SetControlAsync(getControlClass ob)
        {
            await client.SetAsync("Control/" + Functions.Get_MacAdress(), ob);
        }
        public async Task<getControlClass> GetControlAsync()
        {
            var get = await client.GetAsync("Control/" + Functions.Get_MacAdress());
            if (get == null) return null;
            var ob = get.ResultAs<getControlClass>();
            return ob;
        }
    }
   
}
