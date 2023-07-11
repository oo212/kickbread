using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer
{
   public class MyData
    {
        public static Dictionary<string, string> dict_userData = new Dictionary<string, string>();
    }

    public class RankingData
    {
        public string username = "";
        public int BurgerBun = 0;
        public int Bagel = 0;
        public int Toast = 0;
        public int Baguette = 0;
        public int Breadstick = 0;
    }
}
