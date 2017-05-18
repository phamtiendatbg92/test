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
using System.Windows.Navigation;
using System.Windows.Shapes;
using testdb.Utility;
namespace testdb.View
{
    /// <summary>
    /// Interaction logic for DbOperView.xaml
    /// </summary>
    public partial class DbOperView : UserControl
    {
        public DbOperView()
        {
            InitializeComponent();
        }

        

        private void CreateCongTy_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                congty cty = new congty();
                cty.mack = tbCrMack.Text;
                cty.nhomnganh = cbCrNhomNganh.Text;
                cty.tencty = tbCrTenCty.Text;
                if (tbCrSoLuongCp.Text == "")
                {
                    tbCrSoLuongCp.Text = "0";
                }
                cty.socp = Convert.ToInt32(tbCrSoLuongCp.Text);
                bool result = DataBase.CreateCty(cty);
                if (result)
                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Đã có công ty này rồi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fail");
            }

        }

        private void CreateBctc_Button_Click(object sender, RoutedEventArgs e)
        {
            bctc baocao = new bctc();
            try
            {
                baocao.quy = Convert.ToInt32(crQuy.Text);
                baocao.phiquanly = Convert.ToInt32(crPhiQuanLyDN.Text);
                baocao.nam = Convert.ToInt32(crNam.Text);
                baocao.mack = crMaCk.Text;
                baocao.loinhuantruocthue = Convert.ToInt32(crLNTruocThue.Text);
                baocao.loinhuansauthue = Convert.ToInt32(crLNSauThue.Text);
                baocao.loinhuankhac = Convert.ToInt32(crLNKhac.Text);
                baocao.giavon = Convert.ToInt32(crGiaVon.Text);
                baocao.doanhthuthuan = Convert.ToInt32(crDoanhThuThuan.Text);
                bool result = DataBase.CreateBctc(baocao);
                if (result)
                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Đã có bản ghi này rồi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngu! điền đầy đủ thông tin vào");
            }

        }

        private void UpdateCongTy_Click(object sender, RoutedEventArgs e)
        {
            bctc baocao = DataBase.FindBctc(Convert.ToInt32(bctcId.Content));
        }

        private void Congty_Mack_TextChanged(object sender, TextChangedEventArgs e)
        {
            string mack = tbUdMack.Text;
            congty cty = DataBase.FindCtyByMack(mack);
            if (cty == null)
            {
                return;
            }
            tbUdTenCty.Text = cty.tencty;
            tbUdSoluongCP.Text = cty.socp.ToString();
            cbUdNhomNganh.Text = cty.nhomnganh;
        }

        private void udMaCk_TextChanged(object sender, TextChangedEventArgs e)
        {
            string mack = udMaCk.Text;
            List<bctc> baocaos = DataBase.FindBctcByMack(mack);
            if (baocaos.Count == 0)
            {
                return;
            }
            udQuyCb.Items.Clear();
            udNamCb.Items.Clear();
            for (int i = 0; i < baocaos.Count; i++)
            {
                udQuyCb.Items.Add(baocaos[i].quy);
                udNamCb.Items.Add(baocaos[i].nam);
            }

            UpdateRowData(mack,baocaos[0].quy,baocaos[0].nam);
        }
        private void UpdateRowData(string mack, int quy, int nam)
        {
            bctc baocao = DataBase.FindBctc(mack,quy,nam);
            udDoanhThuThuan.Text = baocao.doanhthuthuan.ToString();
            udGiaVon.Text = baocao.giavon.ToString();
            udPhiQuanLyDN.Text = baocao.phiquanly.ToString();
            udLNTruocThue.Text = baocao.loinhuantruocthue.ToString();
            udLNSauThue.Text = baocao.loinhuansauthue.ToString();
            udLNKhac.Text = baocao.loinhuankhac.ToString();
            bctcId.Content = baocao.ID;
        }

        private void udQuyCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mack = udMaCk.Text;
            int quy = Convert.ToInt32(udQuyCb.SelectedValue);
            int nam = Convert.ToInt32(udNamCb.SelectedValue);
            UpdateRowData(mack, quy, nam);
        }
    }
}
