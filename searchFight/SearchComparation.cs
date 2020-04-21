using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static searchFight.Validador  ;
namespace searchFight
{
       public class SearchComparation
    {

        
        private readonly HttpRequester httpRequester  ;
        private readonly Extractor extractor;
        private readonly string _competitor;
        private   List<SearhEngineSource> _searhEngineSources;
        private List<SearchComparatorResult> resultCache;
       public    SearchComparation(HttpRequester httpRequester, Extractor extractor,  string competitor, List<SearhEngineSource> searhEngineSources)
        {

            
            this.httpRequester = httpRequester;
            this.extractor = extractor;
            this._searhEngineSources = searhEngineSources;
            this._competitor = competitor;
   
        }

         public  List<SearchComparatorResult> obteinResults( ) {

            if (resultCache == null)
                resultCache= internalExecute();
            return resultCache;
        }


       

        private List<SearchComparatorResult> internalExecute()
        {

            List<SearchComparatorResult> searchFightResults = new List<SearchComparatorResult>();
            foreach (SearhEngineSource searhEngineSource in _searhEngineSources)
            {
                string result = httpRequester.request(searhEngineSource.url + _competitor);
                string extracted = extractor.extract(result, searhEngineSource.prefix, searhEngineSource.sufix);
                searchFightResults.Add(new SearchComparatorResult(_competitor, searhEngineSource, extracted));
            }
            return searchFightResults;
        }

        public double max()
        {
            return obteinResults().Max(r => double.Parse(limpia( r.result)));

        }


        public string competitor
        {
            get
            {
                return _competitor;
            }

        }

        public  string parseToString( )
        {

            string result = _competitor.Replace("%20"," ")+": ";
            List<SearchComparatorResult> list = obteinResults();
            foreach (SearchComparatorResult current in list)
            {
                result +=  current.searhEngineSource.smallName + ": " + current.result + " ";
            }


            return result.Trim();
        }
    }
}
