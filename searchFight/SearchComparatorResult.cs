using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace searchFight
{
   
    public class SearchComparatorResult
    {
        private  string _competitor;
        private string _result;
        private readonly SearhEngineSource _searhEngineSource;
        public SearchComparatorResult(string competitor, SearhEngineSource searhEngineSource, string result) {
            this._competitor = competitor;
            this._result = result;
            this._searhEngineSource =  searhEngineSource;

        }

        public string competitor
        {
            get { return _competitor; }
            set { _competitor = value; }
        }

        public string result
        {
            get { return _result; }
            set { _result = value; }
        }

        public SearhEngineSource searhEngineSource
        {
            get { return _searhEngineSource; }

        }
    }
}
