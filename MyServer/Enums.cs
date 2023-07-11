using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer
{
    class Enums
    {

    }

    public enum OpCode
    {
        dialog = 1,
        login = 2,
        buyThing = 3,

        createRole,
        RegisterAccount,
        QueryRanking,
        UpdateNumber,
        SendBread,
        QueryUsername,
    }

    public enum EventCode
    {

    }

    public class ParameterCode
    {
        public const short Account = 6;
        public const short Password = 7;
        public const short error = 8;
        public const short player = 9;
        public const short username = 10;

        public const short RankingDataList = 11;
        public const short MyRanking = 12;

        public const short BurgerBun = 13;
        public const short Bagel = 14;
        public const short Toast = 15;
        public const short Baguette = 16;
        public const short Breadstick = 17;

        public const short BreadType = 18;
        public const short sendusername = 19;
    }

    public class DictKey{

        public const short dialog = 1;
        public const short player = 2;
        public const short error = 3;

    }

}
