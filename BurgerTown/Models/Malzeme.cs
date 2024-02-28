﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class Malzeme
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
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
        private int _CategoryID;

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        private bool _isUsing;

        public bool isUsing
        {
            get { return _isUsing; }
            set { _isUsing = value; }
        }
        private decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

    }
}