using Rusada.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DL.DAL
{
    public interface IRusDBAccess
    {
        List<DBFlightDetails> flightDetails();
        string addNewFlight(DBFlightDetails details);

    }
}
