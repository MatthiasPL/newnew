using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace testPOST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Funkcja();
        }
        public void Funkcja()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://trackapi.nutritionix.com/v2/natural/nutrients");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["x-app-id"] = "0128e9a3";
            httpWebRequest.Headers["x-app-key"] = "38e703f742f5baa7b4bbe96e2d9b26a5";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    query ="pierogi"
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
}
