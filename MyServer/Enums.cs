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
        login,
        dialog,
        createRole,
        RegisterAccount,
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
        public const short usernamne = 10;
    }

    public class DictKey{

        public const short dialog = 1;
        public const short player = 2;
        public const short error = 3;

    }

}
