using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class ProducerModel
    {
        private TMDT_DB3Entities context = null;
        public ProducerModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<NHASANXUAT> ListAll()
        {
            var res = context.Database.SqlQuery<NHASANXUAT>("SP_NHASANXUAT").ToList();
            return res;
        }
        public string GetProducerByID(int Ma)
        {
            return context.NHASANXUATs.SingleOrDefault(p => p.MA == Ma).TEN;
        }
        public int Insert(NHASANXUAT temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
            {
                context.NHASANXUATs.Add(temp);   
            }
            context.SaveChanges();
            return temp.MA;
        }
        public NHASANXUAT GetByID(int ma)
        {
            return context.NHASANXUATs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(NHASANXUAT temp)
        {
            try
            {
                NHASANXUAT oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TEN = temp.TEN;
                    oder.DAXOA = temp.DAXOA;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(NHASANXUAT temp)
        {
            try
            {
                NHASANXUAT oder = GetByID(temp.MA);
                if (oder != null)
                {
                    temp.DAXOA = true;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}