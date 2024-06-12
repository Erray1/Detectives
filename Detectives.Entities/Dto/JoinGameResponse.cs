using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectives.Entities.Dto
{
    public class JoinGameResponse
    {
        public bool IsSuccesful => StatusCode == JoinGameStatusCode.Success;
        public JoinGameStatusCode StatusCode { get; set; }
        public GameConnectionToken? ConnectionToken { get; set; }
    }
}
