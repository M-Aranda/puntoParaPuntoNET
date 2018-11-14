using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Model {
    public class Conexion {
        private SqlConnection con; // Connection
        private SqlCommand sen;	// Statement
        public SqlDataReader rs; // ResultSet

        public Conexion(String bd) {
            con = new SqlConnection(
                    /*
                    "Data Source=localhost;" +
                    "Initial Catalog=" + bd + "; " +
                    "User id=sa; " +
                    "Password=123456;"
                    */
                    "Data Source=localhost;" +
                    "Initial Catalog=" + bd + "; " +
                    "Integrated Security=true; "
                );

            /*
            Autenticación de windows
            "Data Source=ServerName;" +
            "Initial Catalog=DataBaseName;" +
            "Integrated Security=SSPI;";
            */

            // url de conexión
        }

        public DataTable Ejecutar(String query) {
            Console.WriteLine("QUERY=" + query);
            DataTable dt = null;

            con.Open();
            sen = new SqlCommand(query, con);

            if (query.ToLower().Contains("select")) {
                rs = sen.ExecuteReader();
                dt = new DataTable();
                dt.Load(rs);
            } else { //insert, update, delete
                sen.ExecuteNonQuery();
            }
            Cerrar();

            return dt;
        }

        public void Cerrar() {
            con.Close();
        }
    }
}


