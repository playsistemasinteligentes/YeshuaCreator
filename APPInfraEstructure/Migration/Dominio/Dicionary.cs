using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace Dominio
{
    public class Dicionary 
    {
        private Entity Entity {  get; set; }
        private List<Column> Columns { get; set; }
    }
}