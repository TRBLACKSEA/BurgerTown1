using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class Kategori
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private int _UpCategoryID;

        public int UpCategoryID
        {
            get { return _UpCategoryID; }
            set { _UpCategoryID = value; }
        }
        private bool _isMainCategory;

        public bool isMainCategory
        {
            get { return _isMainCategory; }
            set { _isMainCategory = value; }
        }

    }
}