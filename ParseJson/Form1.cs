using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  WebClient   URI 所識別的資源中，傳送與接收資料的常見方法。
        ///  await obj.DownloadFileTaskAsync("http://data.ntpc.gov.tw/NTPC/od/data/api/IMC123/?$format=json", "007.json");
        ///  await 運算子套用至非同步方法的工作，以暫停執行方法，直到等候的工作完成。 工作代表進行中的工作。
        ///     await 使用的非同步方法必須以 async 關鍵字修改。 
        ///「這種方法，透過使用 async 修飾詞來定義和通常包含一或多個 await 運算式，稱為「非同步方法」(async method)。」
        ///
        /// File.ReadAllText("007.json");
        ///  ReadAllText開啟文字檔，讀取檔案的所有行，然後關閉檔案。
        /// JArray json陣列
        /// 
        /// arr.Children()陣列的子項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            WebClient obj = new WebClient();
            await obj.DownloadFileTaskAsync("http://data.ntpc.gov.tw/NTPC/od/data/api/IMC123/?$format=json", "007.json");

            string json = File.ReadAllText("007.json");

            JArray arr = JArray.Parse(json);
            var query = from hp in arr.Children()
                        select new
                        {
                            名稱=hp["spot_name"],
                            地區=hp["type"],
                            地址=hp["address"],

                        };
            dataGridView1.DataSource = query.ToArray();
        }
    }
}
