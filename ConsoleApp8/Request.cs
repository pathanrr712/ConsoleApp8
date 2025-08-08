using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Request
    {

        public int FromFloor { get; }
        public int ToFloor { get; }

        public Request(int from, int to)
        {
            FromFloor = from;
            ToFloor = to;
        }
    }
}
