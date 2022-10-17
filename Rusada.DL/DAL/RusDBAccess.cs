using Rusada.DL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DL.DAL
{
    public class RusDBAccess : IRusDBAccess
    {
        public RusDBAccess()
        {

        }

        public string addNewFlight(DBFlightDetails details)
        {
            string response = string.Empty;
            try
            {
                string connString = EnvironmentSettings.connectionString;
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("AddNewFlight", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> prm = new List<SqlParameter>()
                     {
                         new SqlParameter("@Make", SqlDbType.VarChar) {Value = details.Make},
                         new SqlParameter("@Model", SqlDbType.VarChar) {Value = details.Model},
                         new SqlParameter("@Registration", SqlDbType.VarChar) {Value = details.Registration},
                         new SqlParameter("@Location", SqlDbType.VarChar) {Value = details.Location}
                     };
                        command.Parameters.AddRange(prm.ToArray());

                        SqlParameter param = command.Parameters.Add("@FlightID", SqlDbType.Int);
                        param.Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        
                        if ((int)param.Value > 0)
                        {
                            response = "Save success.";
                        }
                        else
                        {
                            response = "Save failed.";
                        }
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public List<DBFlightDetails> flightDetails()
        {
            List<DBFlightDetails> lstFlightDetails = null;
            try
            {
                string connString = EnvironmentSettings.connectionString;
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetAirCraftList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        lstFlightDetails = new List<DBFlightDetails>();
                        while (reader.Read())
                        {
                            DBFlightDetails details = new DBFlightDetails();
                            details.Id = Convert.ToInt32(reader["Id"].ToString());
                            details.Make = reader["Make"] == DBNull.Value ? String.Empty : reader["Make"].ToString();
                            details.Model = reader["Model"] == DBNull.Value ? String.Empty : reader["Model"].ToString();
                            details.Registration = reader["Registration"] == DBNull.Value ? String.Empty : reader["Registration"].ToString();
                            details.Location = reader["Location"] == DBNull.Value ? String.Empty : reader["Location"].ToString();
                            details.CreatedDate = reader["CreatedDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["CreatedDate"].ToString());
                            lstFlightDetails.Add(details);
                        }
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                lstFlightDetails = null;
            }
            return lstFlightDetails;
        }
    }
}
