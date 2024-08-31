using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Migration
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class MigrationAttribute : Attribute
    {
        public int Id { get; }

        public MigrationAttribute(int id)
        {
            Id = id;
        }
    }
}
