using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Parsing
{
    public interface  INTerminal
    {
        object Process(Parser parser, SortedDictionary<string, object> parameters);
    }
}
