using Sample.Bll.Contract;

namespace Sample.Bll
{
    public class DummyLogic : IDummyLogic
    {
        public string HellloWorld()
        {
            return "Hello, from the other side";
        }
    }
}
