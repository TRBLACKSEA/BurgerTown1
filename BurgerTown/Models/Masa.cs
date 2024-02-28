using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class Masa
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

        private bool _Status;

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private bool _isActive;

        public bool isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

    }
}