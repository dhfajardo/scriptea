using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Parsing
{
    public interface  INTerminal
    {
        void Process(Parser parser);
    }
}
