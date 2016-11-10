using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Serv
{
    public class Class1
    {
        public static MySqlConnection NewCon;
        public static string ConStr = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd= ;";

        public static MySqlConnection GetConnection()
        {
            NewCon = new MySqlConnection(ConStr);
            return NewCon;
        }
    }

}