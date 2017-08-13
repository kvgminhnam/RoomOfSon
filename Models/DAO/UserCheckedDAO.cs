using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomOfSon.Models.EF;

namespace RoomOfSon.Models.DAO
{
    public class UserCheckedDAO
    {
        dbQLCT db = new dbQLCT();
        public tblUser UserChecked { get; set; }
        public bool IsChecked { get; set; }
        public List<UserCheckedDAO> GetList()
        {
            List<UserCheckedDAO> ListUser = new List<UserCheckedDAO>();

            foreach (tblUser it in db.tblUsers.ToList())
            {
                UserCheckedDAO us = new UserCheckedDAO();
                us.IsChecked = false;
                us.UserChecked = it;
                ListUser.Add(us);
            }
            return ListUser;
        }
    }
}