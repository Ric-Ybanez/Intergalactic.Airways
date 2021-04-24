using Intergalactic.Airways.Common.Model;
using System.Collections.Generic;

namespace Intergalactic.Airways.Common.Response
{
    public class StarshipResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Starship> Results { get; set; }
    }
}
