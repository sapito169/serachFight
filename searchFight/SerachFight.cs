using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace searchFight
{
    public class SerachFight
    {

        private double maximun = -1;
        private string maximunCompetitor = "";
        private Action<string> writer;
        private Dictionary<string, double> winnerMap = new Dictionary<string, double>();
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
            add(winnerMap,searchComparation.competitor, "") ;


        }

        static private void add(Dictionary<string, double> map, string name, string quantity)
        {
            /*Console.WriteLine(map.ContainsKey(name));
            if (map.ContainsKey(name))
            {
                map[name] += quantity;
            }
            else
            {
                map[name] = quantity;
            }*/
        }

        public void terminateAndWrite()
        {
            //Console.WriteLine(winnerMap);
            writer.Invoke("Total winner: "+ maximunCompetitor);
          

        }
    }
}
