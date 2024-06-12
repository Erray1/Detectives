using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectives.Entities.SessionCommands
{
    public class ErrorAtProceedingCommandMessage
    {
        public ErrorMessageType ErrorType { get; set; }
        public string Message { get; set; }
    }
}
