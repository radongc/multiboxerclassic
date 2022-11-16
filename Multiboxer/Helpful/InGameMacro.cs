using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiboxer
{
    public class InGameMacro
    {
        public string Name { get; private set; }

        public string Content { get; private set; }

        public InGameMacro(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
