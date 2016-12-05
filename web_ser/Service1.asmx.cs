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
        public DataSet dato_equipo(String cod_equipo)
        {
            sb.AppendFormat(" SELECT * FROM equipo WHERE codigo_equipo={0}", cod_equipo);

            conn = conexion.GetConnection();
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
        public DataSet dato_empleado(String no_empleado)
        {
            sb.AppendFormat(" SELECT * FROM usuarios WHERE no_empleado={0}", no_empleado);

            conn = conexion.GetConnection();
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
        public void nuevo_resguardo(String id_empleado, String id_equipo)
        {
            sb.Append("INSERT INTO resguardo VALUES");
            sb.AppendFormat("(null,'{0}','{1}',now())", id_empleado, id_equipo);

            conn = conexion.GetConnection();
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
        public DataSet datos(String nombre)
        {

            sb.Append(" select id_resguardo, id_empleado, nombre,  codigo_equipo, concat (marca, ' ', modelo, ' ', no_modelo) as pc, depto, fecha  FROM resguardo");
            sb.AppendFormat(" INNER JOIN equipo ON id_equipo = codigo_equipo INNER JOIN usuarios ON no_empleado = id_empleado WHERE nombre = '{0}';", nombre);

            conn = conexion.GetConnection();
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
