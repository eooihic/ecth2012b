using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.B2B.Models.ViewModels
{
    public class AutionRecoreList
    {
        private static AutionRecoreList instance;
        private static int currentID = 1;
        private static List<AutionRecordModel> list = null;
        private AutionRecoreList()
        {
            list = new List<AutionRecordModel>();
        }
        public static AutionRecoreList GetInstance()
        {
            if (instance == null)
            {
                instance = new AutionRecoreList();
                return instance;
            }
            else 
            {
                return instance;
            }
        }
        public List<AutionRecordModel> GetList()
        {
            return list;
        }
        public bool AddAutionRecord(AutionRecordModel item)
        {
            foreach (var c in list)
            {
                if( (c.username == item.username
                    && c.passwork == item.passwork
                    && c.productID == item.productID
                    && c.price == item.price 
                    && c.phone == item.phone 
                    && c.email == item.email)
                    || (item.email == "")
                    || (item.email == null))
                {
                    return false;
                }
            }
            item.id = currentID++;
            list.Add(item);
            return true;
        }
        public static List<AutionRecordModel> GetAutionRecordByProductID(string ma)
        {
            var temp = new List<AutionRecordModel>();
            foreach (var item in list)
            {
                if (item.productID == ma)
                    temp.Add(item);
            }
            return temp;
        }
        public AutionRecordModel GetByID(int id)
        {
            foreach (var item in list)
            {
                if (item.id == id)
                    return item;
            } 
            return null;
        }
        public bool RemoveById(int id)
        {
            foreach (var item in list)
            {
                if (item.id == id)
                {
                    list.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}