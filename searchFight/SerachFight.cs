﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static searchFight.Validador;

namespace searchFight
{
    public class SerachFight
    {

        private double maximun = -1;
        private string maximunCompetitor = "";
        private Action<string> writer;
        private List<SearchComparatorResult> searchComparatorResult;

        public SerachFight(Action<string> writer)
        {
            this.writer = writer;
        }
        public void addAndExecute(SearchComparation searchComparation)
        {

             
            writer.Invoke(  searchComparation.parseToString() +"\n");
            double currentMax=searchComparation.max();
            if ( currentMax>maximun)
            {
                maximun = currentMax;
                maximunCompetitor = searchComparation.competitor;
            }

            //List<SearchComparatorResult> list = searchComparation.obteinResults();
            searchComparatorResult = add(searchComparatorResult, searchComparation.obteinResults()) ;


        }

        static private List<SearchComparatorResult> add(List<SearchComparatorResult> old, List<SearchComparatorResult> current )
        {
            /*SearchComparatorResult
                string _result;
        
                SearhEngineSource{
                    _prefix;
                    _sufix;
                    _url;
                    _smallName;
                 }
             */
            if (old == null)
            {
                old = current;

            }
            else
            {
                for(int c = 0; c < current.Count; c++)
                {
                    if (double.Parse(limpia(old[c].result)) >  double.Parse(limpia(current[c].result) ))
                    {
                        old[c].result = current[c].result;
                        old[c].searhEngineSource.smallName = current[c].result;
                    } 
                }

            }
            return old;
        }

        public void terminateAndWrite()
        {
            //Console.WriteLine(winnerMap);
            writer.Invoke("Total winner: "+ maximunCompetitor);
          

        }
    }
}
