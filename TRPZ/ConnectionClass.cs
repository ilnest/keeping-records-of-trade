using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TRPZ
{
    class ConnectionClass
    {
        public static string connectionString = @"Data Source=(local);Initial Catalog=shop;Integrated Security=True";

        public static SqlConnection Connection { get; set; }

        public static User CurrUser { get; set; }
    }
}
