using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;

namespace Serv
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Service1 : System.Web.Services.WebService
    {

        StringBuilder sb = new StringBuilder();
        MySqlConnection conn;
        DataSet ds = new DataSet();
    
    
        [WebMethod]
        public DataSet Todo()
        {
            sb.Append("SELECT * FROM dat ");
            
            conn = Class1.GetConnection();
            conn.Open();

            MySqlCommand newCmd = conn.CreateCommand();

            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = sb.ToString();
            newCmd.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(newCmd);
            da.Fill(ds);

            conn.Close();
            return ds;
        }



        [WebMethod]
        public void Insertar_uno(String nombre, String firma, String depto)
        {
            sb.Append("INSERT INTO dat VALUES");
            sb.AppendFormat("(null,'{0}','{1}','{2}')", nombre, firma, depto);

            conn= Class1.GetConnection();
            conn.Open();

            MySqlCommand newCmd = conn.CreateCommand();

            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = sb.ToString();
            MySqlDataReader sdr = newCmd.ExecuteReader();
            String nom = null;

            if (sdr.Read())
            {
                nom = sdr.GetValue(0).ToString();
            }

            conn.Close();       
        }


        [WebMethod]
        public void UP(String no_empleado, String nombre, String firma, String depto)
        {
            sb.Append(" UPDATE dat SET");
            sb.AppendFormat(" nombre='{1}',firma='{2}',depto='{3}' WHERE no_empleado={0};", no_empleado, nombre, firma, depto);

            conn = Class1.GetConnection();
            conn.Open();

            MySqlCommand newCmd = conn.CreateCommand();

            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = sb.ToString();
            MySqlDataReader sdr = newCmd.ExecuteReader();
            String nom = null;

            if (sdr.Read())
            {
                nom = sdr.GetValue(0).ToString();
            }

            conn.Close();
        }


        [WebMethod]
        public void Borra_uno(String id)
        {
            sb.Append(" DELETE FROM dat");
            sb.AppendFormat(" WHERE no_empleado={0};", id);

            conn = Class1.GetConnection();
            conn.Open();

            MySqlCommand newCmd = conn.CreateCommand();

            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = sb.ToString();
            MySqlDataReader sdr = newCmd.ExecuteReader();
            String nombre = null;

            if (sdr.Read())
            {
                nombre = sdr.GetValue(0).ToString();
            }

            conn.Close();    
        }
            
    }

}