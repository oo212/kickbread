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
        diaolog = 1,//对话
        login = 2,//登录
        buyThing = 3,//购买物品

        createRole,
    }

    public enum EventCode
    {
        restart,//重启
        paiMing,//排名
        chuJiChengHao,//初级称号
    }

    public class ParameterCode
    {
        public const short Account = 6;
        public const short Password = 7;

        public const short error = 8;

        public const short player = 9;
        public const short usernamne = 10;
    }

    public class DictKey{

        public const short dialog = 1;
        public const short player = 2;
        public const short error = 3;

        //public const short buyThing = 4;
        //public const short chengHao = 5;
    }

}
