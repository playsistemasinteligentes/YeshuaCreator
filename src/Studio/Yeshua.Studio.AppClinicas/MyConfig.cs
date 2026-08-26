using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClinicas
{
    public class MyConfig
    {
        public MyConfig() { }
        public string ReadConectionString { get; set; }
        public string WriteConectionString { get; set; }
        public string Source { get; set; }
        public string Project { get; set; }
    }
}
