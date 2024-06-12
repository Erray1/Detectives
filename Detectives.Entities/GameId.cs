using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectives.Entities
{
    public class GameId
    {
        public string Value { get; set; }
        public static implicit operator GameId(string value)
        {
            return new GameId() { Value = value };
        }
    }
}
