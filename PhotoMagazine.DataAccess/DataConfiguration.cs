using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.DataAccess
{
    public class DataConfiguration
    {
        public string ConnectionString { get; set; }

        public DataConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}
