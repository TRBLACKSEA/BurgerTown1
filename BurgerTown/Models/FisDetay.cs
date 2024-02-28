using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class FisDetay
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _FisBaslikID;

        public int FisBaslikID
        {
            get { return _FisBaslikID; }
            set { _FisBaslikID = value; }
        }
        private string _Malzemeler;

        public string Malzemeler
        {
            get { return _Malzemeler; }
            set { _Malzemeler = value; }
        }
        private int _UygulananKampanyaID;

        public int UygulananKampanyaID
        {
            get { return _UygulananKampanyaID; }
            set { _UygulananKampanyaID = value; }
        }



    }
}