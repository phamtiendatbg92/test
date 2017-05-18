using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testdb.Utility
{
    public static class DataBase
    {
        private static stocksqlEntities dataBaseEntities = new stocksqlEntities();
        public static List<congty> GetAllCty()
        {
            List<congty> abc = dataBaseEntities.congty.ToList();
            return abc;
        }
        public static List<bctc> GetAllbctc()
        {
            List<bctc> abc = dataBaseEntities.bctc.ToList();
            return abc;
        }
        public static congty FindCtyByMack(string mack)
        {
            List<congty> temp = dataBaseEntities.congty.ToList();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].mack.Equals(mack, StringComparison.InvariantCultureIgnoreCase))
                {
                    return temp[i];
                }
            }
            return null;
        }
        public static bctc FindBctc(int id)
        {
            List<bctc> temp = dataBaseEntities.bctc.ToList();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].ID == id)
                {
                    return temp[i];
                }
            }
            return null;
        }
        public static bctc FindBctc(string mack, int quy, int nam)
        {
            List<bctc> temp = dataBaseEntities.bctc.ToList();
            bctc result = new bctc();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].mack.Equals(mack, StringComparison.InvariantCultureIgnoreCase) 
                    && temp[i].quy == quy 
                    && temp[i].nam == nam)
                {
                    result = temp[i];
                }
            }
            return result;
        }
        public static List<bctc> FindBctcByMack(string mack)
        {
            List<bctc> temp = dataBaseEntities.bctc.ToList();
            List<bctc> result = new List<bctc>();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].mack.Equals(mack, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(temp[i]);
                }
            }
            return result;
        }
        public static bool CreateCty(congty cty)
        {
            List<congty> temp = dataBaseEntities.congty.ToList();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].mack.Equals(cty.mack, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }
            dataBaseEntities.congty.Add(cty);
            dataBaseEntities.SaveChanges();
            return true;
        }
        public static bool CreateBctc(bctc bctc)
        {
            List<bctc> temp = dataBaseEntities.bctc.ToList();
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                if (temp[i].mack == bctc.mack && temp[i].nam == bctc.nam && temp[i].quy == bctc.quy)
                {
                    return false;
                }
            }
            dataBaseEntities.bctc.Add(bctc);
            dataBaseEntities.SaveChanges();
            return true;
        }
        public static bool UpdateCty(congty cty)
        {
            congty temp = dataBaseEntities.congty.First(i => i.mack == cty.mack);
            temp.nhomnganh = cty.nhomnganh;
            temp.socp = cty.socp;
            temp.tencty = cty.tencty;
            dataBaseEntities.SaveChanges();
            return true;
        }
        public static bool UpdateBctc(bctc baocao)
        {
            bctc temp = dataBaseEntities.bctc.First(i => i.ID == baocao.ID);
            if (temp == null)
            {
                return false;
            }
            temp.giavon = baocao.giavon;
            temp.doanhthuthuan = baocao.doanhthuthuan;
            temp.loinhuankhac = baocao.loinhuankhac;
            temp.loinhuansauthue = baocao.loinhuansauthue;
            temp.loinhuantruocthue = baocao.loinhuantruocthue;
            temp.mack = baocao.mack;
            temp.nam = baocao.nam;
            temp.phiquanly = baocao.phiquanly;
            temp.quy = baocao.quy;
            return true;
        }
        public static bool DelteCty(string mack)
        {
            congty temp = dataBaseEntities.congty.First(i => i.mack == mack);
            if (temp == null)
            {
                return false;
            }
            dataBaseEntities.congty.Remove(temp);
            return true;
        }
        public static bool DelteBctc(int id)
        {
            bctc temp = dataBaseEntities.bctc.First(i => i.ID == id);
            if (temp == null)
            {
                return false;
            }
            dataBaseEntities.bctc.Remove(temp);
            return true;
        }
    }
}
