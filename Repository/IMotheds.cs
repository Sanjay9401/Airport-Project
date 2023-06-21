

using Airport_Project.Model;
using System.Data.SqlClient;

namespace Airport_Project.Repository
{
    public interface IMethods
    {
        List<city> GetAllCities();
        List<airport> airportsbtwcities(string from, string to);
        city GetCity(String K);
    }
    public class Methods : IMethods
    {
        SqlConnection conn = null;
        public Methods()
        {
            conn = new SqlConnection("Data Source=LTPCHE032527972;Initial Catalog=airportdb;Integrated Security=True");
        }

        public List<airport> airportsbtwcities(string from, string to)
        {
            city from1 = GetCity(from);
            city To = GetCity(to);
            List<airport> k = new List<airport>();
            return k;
        }

        public List<city> GetAllCities()
        {


            SqlCommand cmd = new SqlCommand("Select * from cityinfo", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<city> list = new List<city>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    city city = new city();
                    city.CITY = reader["CITYNAME"].ToString();
                    city.LATITUDE = Convert.ToDouble(reader["LAT"]);
                    city.LONGITUDE = Convert.ToDouble(reader["LONG"]);
                    list.Add(city);

                }
            }
            conn.Close();
            return list;
        }

        public city GetCity(string K)
        {
            SqlCommand cmd = new SqlCommand($"Select * from CITIES WHERE CITY={K}", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            city K1 = new city();
            if (reader != null)
            {
                while (reader.Read())
                {
                    K1.CITY = reader["CITY"].ToString();
                    K1.LATITUDE = Convert.ToDouble(reader["LATITUDE"]);
                    K1.LONGITUDE = Convert.ToDouble(reader["LONGITUDE"]);
                }
            }
            else
            {
                K1 = null;
            }
            conn.Close();
            return K1;
        }
    }
}
