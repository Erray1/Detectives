using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectives.Entities.Dto
{
    public class CreateGameResponse
    {
        public bool IsSuccesful { get; set; }
        public string? ErrorMessage { get; set; }
        public GameId GameId { get; set; }
    }
}
