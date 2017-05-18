using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testdb.ViewModel
{
    public class DbOperViewModel : BaseViewModel
    {
        private bctc m_baoCao = new bctc();

        public bctc Baocao
        {
            get { return m_baoCao; }
            set { m_baoCao = value; }
        }
        public string MaCK
        {
            get { return m_baoCao.mack; }
            set
            {
                m_baoCao.mack = value;
                OnPropertyChanged("MaCK");
            }
        }
        public int doanhthuthuan
        {
            get { return m_baoCao.doanhthuthuan; }
            set
            {
                m_baoCao.doanhthuthuan = value;
                OnPropertyChanged("doanhthuthuan");
            }
        }
        public int giavon
        {
            get { return m_baoCao.giavon; }
            set
            {
                m_baoCao.giavon = value;
                OnPropertyChanged("giavon");
            }
        }
        public int phiquanly
        {
            get { return m_baoCao.phiquanly; }
            set
            {
                m_baoCao.phiquanly = value;
                OnPropertyChanged("phiquanly");
            }
        }
        public int loinhuantruocthue
        {
            get { return m_baoCao.loinhuantruocthue; }
            set
            {
                m_baoCao.loinhuantruocthue = value;
                OnPropertyChanged("loinhuantruocthue");
            }
        }
        public int loinhuansauthue
        {
            get { return m_baoCao.loinhuansauthue; }
            set
            {
                m_baoCao.loinhuansauthue = value;
                OnPropertyChanged("loinhuansauthue");
            }
        }
        public int loinhuankhac
        {
            get { return m_baoCao.loinhuankhac; }
            set
            {
                m_baoCao.loinhuankhac = value;
                OnPropertyChanged("loinhuankhac");
            }
        }
        public int quy
        {
            get { return m_baoCao.quy; }
            set
            {
                m_baoCao.quy = value;
                OnPropertyChanged("quy");
            }
        }
        public int nam
        {
            get { return m_baoCao.nam; }
            set
            {
                m_baoCao.nam = value;
                OnPropertyChanged("nam");
            }
        }
    }
}
