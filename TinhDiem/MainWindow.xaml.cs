using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace TinhDiem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, int> listDiem = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            ReadConfigFile();
        }
        private void ReadConfigFile()
        {
            HeSo.HeSo_EPS = Convert.ToInt32(ConfigurationManager.AppSettings["HeSo_EPS"]);
            HeSo.HeSo_tangTruongDoanhThuThuan = Convert.ToInt32(ConfigurationManager.AppSettings["HeSo_tangTruongDoanhThuThuan"]);
        }
        private void LayDuLieu(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            string folderName = Directory.GetCurrentDirectory();
            folderName += "\\ChiSo\\";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string maCkString = File.ReadAllText("MaCK.txt");
            string[] maCks = maCkString.Split('_');
            string s1 = "http://finance.vietstock.vn/Controls/Report/Data/GetReport.ashx?rptType=CSTC&scode=";

            string s2 = "&bizType=1&rptUnit=1000000&rptTermTypeID=1&page=1";
            string downloadString = "";
            int length = maCks.Length;
            for (int i = 0; i < length; i++)
            {
                string mack = maCks[i];
                downloadString = client.DownloadString(s1 + mack + s2);
                File.WriteAllText(folderName + mack + ".txt", downloadString, Encoding.UTF8);
                bw.ReportProgress(i * 100 / length);
            }
        }
        private void LocChiSo(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            //Đọc dữ liệu
            string folderName = Directory.GetCurrentDirectory();
            folderName += "\\ChiSo\\";
            string maCkString = File.ReadAllText("MaCK.txt");
            string[] maCks = maCkString.Split('_');
            int length = maCks.Length;
            for (int i = 0; i < length; i++)
            {
                string mack = maCks[i];
                string content = File.ReadAllText(folderName + mack + ".txt", Encoding.UTF8);
                //Init
                ChiSo4Nam chiSo4Nam = new ChiSo4Nam();
                chiSo4Nam.chiSoDic = new Dictionary<int, ChiSo>();
                chiSo4Nam.chiSoDic.Add(0, new ChiSo());
                chiSo4Nam.chiSoDic.Add(1, new ChiSo());
                chiSo4Nam.chiSoDic.Add(2, new ChiSo());
                chiSo4Nam.chiSoDic.Add(3, new ChiSo());
                // Read Data
                if (content == "")
                {
                    continue;
                }
                DocDuLieu(content, chiSo4Nam);
                if (!TinhDiem2(chiSo4Nam))
                {
                    //Console.WriteLine("=========" + mack);
                    continue;
                }
                int diem = TinhDiem(chiSo4Nam);
                listDiem.Add(mack, diem);
                bw.ReportProgress(i * 100 / length);
            }
            Dictionary<string, int> tempDic = new Dictionary<string, int>();
            foreach (var key in listDiem.Keys)
            {
                if (tempDic.Count < 10)
                {
                    tempDic.Add(key, listDiem[key]);
                }
                else
                {
                    foreach (var key1 in tempDic.Keys)
                    {
                        if (tempDic[key1] < listDiem[key])
                        {
                            tempDic.Remove(key1);
                            tempDic.Add(key, listDiem[key]);
                            break;
                        }
                    }
                }
            }
            foreach (var key1 in tempDic.Keys)
            {
                Console.WriteLine("Key: {0}  Value: {1}", key1, tempDic[key1]);
            }

        }
        private bool TinhDiem2(ChiSo4Nam chiSo4Nam)
        {
            ChiSo chiSo1 = chiSo4Nam.chiSoDic[0];
            ChiSo chiSo2 = chiSo4Nam.chiSoDic[1];
            ChiSo chiSo3 = chiSo4Nam.chiSoDic[2];
            ChiSo chiSo4 = chiSo4Nam.chiSoDic[3];
            // Tinh EPS
            double eps1 = (chiSo2.EPS - chiSo1.EPS) * (HeSo.HeSo_EPS - 2);
            double eps2 = (chiSo3.EPS - chiSo2.EPS) * (HeSo.HeSo_EPS - 1);
            double eps3 = (chiSo4.EPS - chiSo3.EPS) * (HeSo.HeSo_EPS);
            // Tinh Doanh thu thuan
            double diem_doanhThuThuan1 = (chiSo2.tangTruongDoanhThuThuan - chiSo1.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan - 2);
            double diem_doanhThuThuan2 = (chiSo3.tangTruongDoanhThuThuan - chiSo2.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan - 1);
            double diem_doanhThuThuan3 = (chiSo4.tangTruongDoanhThuThuan - chiSo3.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan);

            if (eps1 < 0 || eps2 < 0 || eps3 < 0 ||
                diem_doanhThuThuan1 < 0 || diem_doanhThuThuan2 < 0 || diem_doanhThuThuan3 < 0)
                return false;
            else
            {
                return true;
            }
        }
        private int TinhDiem(ChiSo4Nam chiSo4Nam)
        {
            double total = 0;
            ChiSo chiSo1 = chiSo4Nam.chiSoDic[0];
            ChiSo chiSo2 = chiSo4Nam.chiSoDic[1];
            ChiSo chiSo3 = chiSo4Nam.chiSoDic[2];
            ChiSo chiSo4 = chiSo4Nam.chiSoDic[3];
            // Tinh EPS
            double eps1 = (chiSo2.EPS - chiSo1.EPS) * (HeSo.HeSo_EPS - 2);
            double eps2 = (chiSo3.EPS - chiSo2.EPS) * (HeSo.HeSo_EPS - 1);
            double eps3 = (chiSo4.EPS - chiSo3.EPS) * (HeSo.HeSo_EPS);
            // Tinh Doanh thu thuan
            double diem_doanhThuThuan1 = (chiSo2.tangTruongDoanhThuThuan - chiSo1.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan - 2);
            double diem_doanhThuThuan2 = (chiSo3.tangTruongDoanhThuThuan - chiSo2.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan - 1);
            double diem_doanhThuThuan3 = (chiSo4.tangTruongDoanhThuThuan - chiSo3.tangTruongDoanhThuThuan) * (HeSo.HeSo_tangTruongDoanhThuThuan);

            total = eps1 + eps2 + eps3 + diem_doanhThuThuan1 + diem_doanhThuThuan2 + diem_doanhThuThuan3;
            return (int)total;
        }
        private void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void bw_ProgressChanged2(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += LayDuLieu;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }
        private void tinhToanbutton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += LocChiSo;
            bw.ProgressChanged += bw_ProgressChanged2;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }
        private void DocDuLieu(string html, ChiSo4Nam chiSo4Nam)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//span");
            foreach (HtmlNode link in collection)
            {
                if (link.ParentNode != null)
                {
                    HtmlNode tdNode = link.ParentNode;
                    if (tdNode.Attributes["class"].Value == "FR_tBody_colUnit")
                    {
                        if (tdNode.ParentNode != null)
                        {
                            HtmlNode trNode = tdNode.ParentNode;
                            SetDataToObject(trNode.Attributes["id"].Value, chiSo4Nam, link.WriteContentTo());

                        }
                    }
                }
            }
        }
        private void SetDataToObject(string id, ChiSo4Nam chiSo4Nam, string data)
        {
            List<double> listValue = new List<double>();
            switch (id)
            {
                case "53":
                    listValue = ConvertData(data, chiSo4Nam);
                    for (int i = 0; i < listValue.Count; i++)
                    {
                        chiSo4Nam.chiSoDic[i].EPS = listValue[i];
                    }
                    break;
                case "30":
                    listValue = ConvertData(data, chiSo4Nam);
                    for (int i = 0; i < listValue.Count; i++)
                    {
                        chiSo4Nam.chiSoDic[i].tangTruongDoanhThuThuan = listValue[i];
                    }
                    break;
            }
        }
        private List<double> ConvertData(string data, ChiSo4Nam chiSo4Nam)
        {
            List<double> listvalue = new List<double>();
            
            string[] dataArr = data.Split(',');
            int length = dataArr.Length;

            if (length < 4)
            {
                MessageBox.Show("Có lỗi! Số lượng data < 4");
                return null;
            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    double value = Convert.ToDouble(dataArr[i]);
                    listvalue.Add(value);
                }
                catch (Exception ex)
                {
                    listvalue.Add(0);
                }
            }

            return listvalue;
        }

    }
}
