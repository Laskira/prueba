using Microsoft.Data.SqlClient;

namespace market.Data
{
    public class Conexion
    {
        public SqlConnection connection = new SqlConnection("Data Source=Yuli;Initial Catalog=market;Integrated Security=True");

    }
}
