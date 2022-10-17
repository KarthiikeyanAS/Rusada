using Rusada.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.BL.Handler
{
    public interface IRusHandler
    {
        List<FlightDetails> flightDetails();
        string addNewFlight(FlightDetails details);
    }
}
