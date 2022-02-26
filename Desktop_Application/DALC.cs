using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Desktop_Application
{
    class DALC
    {
        

        public static string GetConnectionString()
        {
            string constring = "Data Source=SABUHIPC\\SABUHISQL; Initial Catalog=DB_DesktopApp; Integrated Security=true";
            return constring;

        }




    }
}
