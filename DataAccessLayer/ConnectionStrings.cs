using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConnectionStrings
    {
        public static string ConStrTest = @"Data Source=.\SQLEXPRESS; Initial Catalog=Esvit2020; Integrated Security=True";
        public static string ConStrEsvit ="Data Source = 192.168.0.24, 1433; Network Library = DBMSSOCN; Initial Catalog = esvit2020; User ID = esvit2021; Password=s3ss1st3m1";
    }
}
