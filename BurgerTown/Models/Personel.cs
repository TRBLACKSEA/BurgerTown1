using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class Personel
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private bool _isAdmin;

        public bool isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

    }
}