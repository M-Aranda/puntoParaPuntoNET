using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Model.DAO {
    public class DAO_Nota : Conexion, IDAO<Nota> {
        public DAO_Nota() : base("bd_prueba_3_java") {
        }

        public void Create(Nota ob) {
            Ejecutar("INSERT INTO nota VALUES ("+ob.Valor+", "+ob.Porcentaje+", "+ob.Asig.Id+" )");
        }

        public void Delete(int id) {
            Ejecutar("DELETE FROM nota WHERE id="+id+" ");
        }

        public DataTable Read() {
            return Ejecutar("SELECT * FROM nota");
        }

        public void Update(Nota ob) {
            Ejecutar("UPDATE nota SET valor="+ob.Valor+", porcentaje="+ob.Porcentaje+", asignatura="+ob.Asig+" WHERE id="+ob.Id+"  ");
        }


        public List<Nota> ReadComoLista() {
            List<Nota> lista = new List<Nota>();
            DataTable dt = Read();

            Nota n = null;
            for (int i = 0; i < dt.Rows.Count; i++) {
                n = new Nota();
                n.Id = int.Parse(dt.Rows[i][0].ToString());
                n.Valor= int.Parse(dt.Rows[i][1].ToString());
                n.Porcentaje= int.Parse(dt.Rows[i][2].ToString());
                
                int idAsig= int.Parse(dt.Rows[i][3].ToString());
                DAO_Asignatura da = new DAO_Asignatura();
                n.Asig = da.FindById(idAsig);

                lista.Add(n);
            }

            return lista;

        }
        

    }
}