using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace searchFight
{
   
    public class SearchComparatorResult
    {
        readonly string _competitor;
        readonly string _result;
        readonly SearhEngineSource _searhEngineSource;
        public SearchComparatorResult(string competitor, SearhEngineSource searhEngineSource, string result) {
            this._competitor = competitor;
            this._result = result;
            this._searhEngineSource =  searhEngineSource;

        }

        public string competitor
        {
            get { return _competitor; }
             
        }

        public string result
        {
            get { return _result; }

        }

        public SearhEngineSource searhEngineSource
        {
            get { return _searhEngineSource; }

        }
    }
}
