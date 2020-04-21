using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace searchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpRequester httpRequester =new HttpRequester() ;
            Extractor extractor= new Extractor();
           
            List<SearhEngineSource> searhEngineSources = new List<SearhEngineSource>();

            searhEngineSources.Add(new SearhEngineSource("<span class=\"sb_count\">", "resultados</span><span class=\"ftrB\"><a class=\"ftrH\" id=\"h5076\"", "https://www.bing.com/search?q=","MSN"));
           // searhEngineSources.Add(new SearhEngineSource("<div id=\"result - stats\">Cerca de", "resultados<nobr>" , "https://www.google.com/search?q=", "Google"));


             
            SerachFight serachFight = new SerachFight((x) => Console.WriteLine(x));

            

            serachFight.addAndExecute(new SearchComparation(httpRequester, extractor, ".net", searhEngineSources));
           // serachFight.addAndExecute(new SearchComparation(httpRequester, extractor, "java", searhEngineSources));


            serachFight.terminateAndWrite();


        }


    }
}
