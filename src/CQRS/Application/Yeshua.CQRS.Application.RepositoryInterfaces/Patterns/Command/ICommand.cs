using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Command
{
    public interface ICommand
    {

    }

    public interface IOperationalTelemetryCommand
    {
        string OperationalEntity { get; }
        string? OperationalRecordId { get; }
    }
}
