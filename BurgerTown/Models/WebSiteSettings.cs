using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class WebSiteSettings
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Facebook;

        public string Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }
        private string _Instagram;

        public string Instagram
        {
            get { return _Instagram; }
            set { _Instagram = value; }
        }
        private string _Twitter;

        public string Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }
        private string _Mail;

        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        private string _Adress;

        public string Adress
        {
            get { return _Adress; }
            set { _Adress = value; }
        }
        private string _Keywords;

        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }


    }
}