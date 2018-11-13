using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Model.DAO {
    public class DAO_Asignatura : Conexion, IDAO<Asignatura> {
        public DAO_Asignatura() : base("bd_prueba_3_java") {
        }

        public void Create(Asignatura ob) {
            Ejecutar("INSERT INTO asignatura VALUES ('"+ob.Nombre+"')");
        }

        public void Delete(int id) {
            Ejecutar("DELETE FROM asignatura WHERE id="+id+" ");
        }

        public DataTable Read() {
            DataTable dt = Ejecutar("SELECT * FROM asignatura");

            return dt;
        }

        public void Update(Asignatura ob) {
            Ejecutar("UPDATE asignatura SET nombre='"+ob.Nombre+"' WHERE id="+ob.Id+" ");
        }


        public List<Asignatura> ReadComoLista() {
            List<Asignatura> lista = new List<Asignatura>();

            DataTable dt = Read();

            Asignatura c = null;
            for (int i = 0; i < dt.Rows.Count; i++) {
                c = new Asignatura();
                c.Id = int.Parse(dt.Rows[i][0].ToString());
                c.Nombre = dt.Rows[i][1].ToString();
                lista.Add(c);
            }
           
            return lista;
        }

        public Asignatura FindById(int id) {
            Asignatura a = null;

            DataTable dt=Ejecutar("SELECT * FROM asignatura WHERE id= "+id+"");

            for (int i = 0; i < dt.Rows.Count; i++) {
                a = new Asignatura();
                a.Id = int.Parse(dt.Rows[i][0].ToString());
                a.Nombre = dt.Rows[i][1].ToString();

            }


            return a;
        }


    }
}