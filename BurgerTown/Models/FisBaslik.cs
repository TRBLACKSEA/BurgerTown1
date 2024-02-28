using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class FisBaslik
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _OrderID;

        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
        private int _TableID;

        public int TableID
        {
            get { return _TableID; }
            set { _TableID = value; }
        }
        private DateTime _OrderDate;

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        private bool _PurchaseMethod;

        public bool PurchaseMethod
        {
            get { return _PurchaseMethod; }
            set { _PurchaseMethod = value; }
        }
        private decimal _KDVOrani;

        public decimal KDVOrani
        {
            get { return _KDVOrani; }
            set { _KDVOrani = value; }
        }
        private decimal _KDVMiktari;

        public decimal KDVMiktari
        {
            get { return _KDVMiktari; }
            set { _KDVMiktari = value; }
        }
        private decimal _AraToplam;

        public decimal AraToplam
        {
            get { return _AraToplam; }
            set { _AraToplam = value; }
        }

        private decimal _Toplam;

        public decimal Toplam
        {
            get { return _Toplam; }
            set { _Toplam = value; }
        }

    }
}