using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class Kampanya
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
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _isUsing;

        public bool isUsing
        {
            get { return _isUsing; }
            set { _isUsing = value; }
        }
        private decimal _Discount;

        public decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

    }
}