using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DL.Model
{
    public class DBFlightDetails
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Registration { get; set; }
        public string? Location { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
