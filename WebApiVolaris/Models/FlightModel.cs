using System.Data.SqlClient;

namespace WebApiVolaris.Models
{
    public class FlightModel
    {

        //Coneccion Azure
        string Connectionstring = "Server=tcp:sqlservervuelos.database.windows.net,1433;Initial Catalog=sqlservervuelos;Persist Security Info=False;User ID=sqlvuelos;Password=vuelos.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? Date { get; set; }
        public string? Hour { get; set; }
        public string? Status { get; set; }
        public double Logitude { get; set; }
        public double Latitude { get; set; }

        public PositionModel? ActualPosition { get; set; }

        public List<PositionModel>? RouteLastTravel { get; set; }

        public ApiResponse GetAll()
        {
            List<FlightModel> list = new List<FlightModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Connectionstring))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Flight " +
                                  "INNER JOIN Position ON Flight.IDActualPosition = Position.IDPosition";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new FlightModel
                                {
                                    ID = (int)reader["IDFlight"],
                                    Name = reader["Name"].ToString(),
                                    Picture = reader["Picture"].ToString(),
                                    Date = reader["Date"].ToString(),
                                    Hour = reader["Hour"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    Logitude = (double)reader["Longitude"],
                                    Latitude = (double)reader["Latitude"],
                                    ActualPosition = new PositionModel
                                    {
                                        Id = (int)reader["IDPosition"],
                                        Latitude = (double)reader["Latitude"],
                                        Longitude = (double)reader["Longitude"]
                                    }
                                });
                            }
                        }
                    }
                }
                return new ApiResponse
                {
                    IsSuccess =true,
                    Message = "Los Vuelos fueron obtenidos correctamente",
                    Result = list
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
