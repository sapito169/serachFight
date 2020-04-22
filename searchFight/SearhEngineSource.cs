using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace searchFight
{
   public class SearhEngineSource
    {
        private readonly string _prefix;
        private readonly string _sufix;
        private readonly string _url;
        private   string _smallName;

        public SearhEngineSource(string prefix,string sufix,string url, string smallName)
        {
            this._prefix = prefix;
            this._sufix=sufix;
            this._url = url;
            this._smallName = smallName;
        }

        public string sufix
        {
            get { return _sufix; }

        }
        public string prefix
        {
            get { return _prefix; }

        }

        public string smallName
        {
            get { return _smallName; }
            set {   _smallName=value; }
        }

        public string url
        {
            get { return _url; }

        }
         
    }
}
