using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testdb.ViewModel
{
    public class ScoreViewModel : BaseViewModel
    {
        private List<CoPhieuScore> m_ListCoPhieu = new List<CoPhieuScore>();
        public ScoreViewModel(List<congty> listCty)
        {
            m_ListCoPhieu = new List<CoPhieuScore>();
            for (int i = 0; i < listCty.Count; i++)
            {
                CoPhieuScore cpSore = new CoPhieuScore();
                cpSore.mack = listCty[i].mack;
                m_ListCoPhieu.Add(cpSore);
            }
        }
        public List<CoPhieuScore> ListCoPhieu
        {
            get { return m_ListCoPhieu; }
            set
            {
                m_ListCoPhieu = value;
                OnPropertyChanged("ListCoPhieu");
            }
        }


    }
}
