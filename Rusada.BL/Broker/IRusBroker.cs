using Rusada.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.BL.Broker
{
    public interface IRusBroker
    {
        List<FlightDetails> flightDetails();
        string addNewFlight(FlightDetails details);
    }
}
