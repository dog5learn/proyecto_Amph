
#<Center>Proyecto Amphenol


## Tabla De Contenidos

- Introducción
- Objetivos
- Problematica
- Interfaz
- Código

- - -

## Introducción
- El principal objetivo tener el mayor control de los equipos de computo y accesorios que son entregados a cada empleado.

+ Evitar perdidas para la empresa.


* Evitar conflictos.

- - -

## Objetivos
- El principal objetivo tener el mayor control de los equipos de computo y accesorios que son entregados a cada empleado.

- Evitar perdidas para la empresa.

- Evitar conflictos.
- - -
## Problemática
El principal problema es:

- Mala organización de los archivos.
- Perdida de documentos.
- No tener control de la informacion.

- - -
##Interfaz
- En esta sección se muestran las ventanas que requiere el programa para obtener un mayor control dentro de la empresa.<br>
En la Img.1.0. En la Img.1.0 se muestra la ventana principal, que contiene elementos como nuevo ,buscar ,firmar e imprimir.<br>
![src='Ventana1.png'](https://github.com/Lobo10/proyecto_Amph/blob/master/ventana1.png)<br>
Img.1.0. Ventana Principal<br>

- En la Img. 1.1 Observamos la ventana de la opción ‘VentanaNuevo’<br>
![src='ventana2'](https://github.com/Lobo10/proyecto_Amph/blob/master/ventanaNuevo2.png)<br>
Img.1.1. Ventana 'Nuevo'<br>
- En la Img. 1.2 , se muestra la ventana ‘Buscar’ con los campos correspondientes ‘No. Empleado’ <br>![src='ventanaBuscar'](https://github.com/Lobo10/proyecto_Amph/blob/master/ventanaBuscarModif.png)<br>
Img.1.2. Ventana'Buscar'


<br>
- La Img. 1.3 , muestra la ventana ‘Firmar’ , que nos indica en el recuadro donde se encuentra la firma .

- A su vez tenemos dos botones aceptar y cancelar en caso que la firma sea correcta o no sea legible. <br>
![src='ventana4'](https://github.com/Lobo10/proyecto_Amph/blob/master/ventana4.png)<br>
Img.1.4. Ventana 'Firmar'<br>

## Codigo
- Aqui se realiza la clase conexion.



	 	namespace Serv
	 	{
      	public class Class1
      	{
        	public static MySqlConnection NewCon;
        	public static string ConStr = "Server=localhost;Port=3306;
            Database=test;Uid=root;Pwd= ;";

        	public static MySqlConnection GetConnection()
        	{
            	NewCon = new MySqlConnection(ConStr);
            	return NewCon;
        	}
       	}

       }

- - -
- En nuestro servicio web se establecen los metodos de  acceso a la base de datos.


		

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
        	public void Insertar_uno(String nombre, String firma, String 			 depto)
        	{
            	sb.Append("INSERT INTO dat VALUES");
            	sb.AppendFormat("(null,'{0}','{1}','{2}')", nombre, firma, 			   depto);

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
        	public void UP(String no_empleado, String nombre, String firma, 		  String depto)
        	{
            	sb.Append(" UPDATE dat SET");
            	sb.AppendFormat(" nombre='{1}',firma='{2}',depto='{3}' WHERE 			 no_empleado={0};", no_empleado, nombre, firma, depto);

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
