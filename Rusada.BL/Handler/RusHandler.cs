using Rusada.BL.Broker;
using Rusada.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.BL.Handler
{
    public class RusHandler :IRusHandler
    {
        public IRusBroker _rusBroker;
        public RusHandler(IRusBroker rusBroker)
        {
            _rusBroker = rusBroker; 
        }

        public string addNewFlight(FlightDetails details)
        {
            return _rusBroker.addNewFlight(details);
        }

        public List<FlightDetails> flightDetails()
        {
            return _rusBroker.flightDetails();
        }
    }
}
