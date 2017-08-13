using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomOfSon.Models.EF;
namespace RoomOfSon.Models.DAO
{
    public class ConfirmPayment
    {
        dbQLCT db = new dbQLCT();
        public int id { get; set; }
        public int idsubmieter { get; set; }
        public int idreceiver { get; set; }
        public string namesubmiter { get; set; }
        public string namereceiver { get; set; }
        public float money { get; set; }
        public DateTime datetime { get; set; }
        public bool status { get; set; }
        public List<ConfirmPayment> GetList(tblUser actor)
        {
            List<ConfirmPayment> lcfpm = new List<ConfirmPayment>();
            var ListConfirm = (from pm in db.tblPayments
                               join act in db.tblUsers on pm.IDActor equals act.ID
                               join receiver in db.tblUsers on pm.IDUser equals receiver.ID
                               orderby pm.Datetime descending
                               select new
                               {
                                   pm.ID,
                                   IDSubmiter = act.ID,
                                   submiter = act.Fullname,
                                   IDreceiver = receiver.ID,
                                   rcver = receiver.Fullname,
                                   pm.Money,
                                   pm.Datetime,
                                   pm.Status

                               }
                               ).ToList();

            foreach (var it in ListConfirm)
            {
                ConfirmPayment temp = new ConfirmPayment();
                temp.id = it.ID;
                temp.idreceiver = it.IDreceiver;
                temp.namereceiver = it.rcver;
                temp.idsubmieter = it.IDSubmiter;
                temp.namesubmiter = it.submiter;
                temp.money = float.Parse(it.Money.ToString());
                temp.datetime = (DateTime)it.Datetime;
                temp.status = (bool)it.Status;
                lcfpm.Add(temp);
            }
            return lcfpm;
        }
    }
}