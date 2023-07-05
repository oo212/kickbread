

    public class Enums
    {

    }

    public enum OpCode
    {
        diaolog = 1,
        login = 2,
        buyThing = 3,

        createRole,
    }

    public enum EventCode
    {
        restart,
        paiMing,
        chuJiChengHao,
    }

    public class ParameterCode
    {
        public const short Account = 6;
        public const short Password = 7;

        public const short error = 8;

        public const short player = 9;
        public const short username = 10;
}

    public class DictKey
    {

        public const short dialog = 1;
        public const short player = 2;
        public const short error = 3;

        public const short buyThing = 4;
        public const short chengHao = 5;
    }

