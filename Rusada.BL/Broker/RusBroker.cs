using Rusada.BL.Model;
using Rusada.DL.DAL;
using Rusada.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.BL.Broker
{
    public class RusBroker : IRusBroker
    {
        public IRusDBAccess _dBAccess;
        public RusBroker(IRusDBAccess dBAccess)
        {
            _dBAccess = dBAccess;
        }

        public string addNewFlight(FlightDetails details)
        {
            string response = string.Empty;
            try
            {
                if (details != null)
                {
                    DBFlightDetails dbflight = new DBFlightDetails();
                    dbflight.Make = details.Make;
                    dbflight.Model = details.Model;
                    dbflight.Registration = details.Registration;
                    dbflight.Location = details.Location;
                    response = _dBAccess.addNewFlight(dbflight);
                }
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public List<FlightDetails> flightDetails()
        {
            List<FlightDetails> flights = null;
            try
            {
                List<DBFlightDetails> dbflightsDetails = _dBAccess.flightDetails();
                if (dbflightsDetails != null && dbflightsDetails.Count > 0)
                {
                    flights = new List<FlightDetails>();
                    foreach (DBFlightDetails dbflight in dbflightsDetails)
                    {
                        FlightDetails flight = new FlightDetails();
                        flight.Id = dbflight.Id;
                        flight.Model = dbflight.Model;
                        flight.Make = dbflight.Make;
                        flight.Registration = dbflight.Registration;
                        flight.Location = dbflight.Location;
                        flight.CreatedDate = dbflight.CreatedDate;
                        flights.Add(flight);
                    }
                }
            }
            catch(Exception ex)
            {
                flights = null;
            }
            return flights;
        }
    }
}
