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



        public List<Nota> ReadNotasDeLaAsignaturaComoLista(int fk_asig)
        {
            DAO_Asignatura da = new DAO_Asignatura();
            DataTable dt= Ejecutar("SELECT * FROM nota WHERE asignatura=" + fk_asig + " ");
            List<Nota> lista = new List<Nota>();

            Nota n = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                n = new Nota();
                n.Id = int.Parse(dt.Rows[i][0].ToString());
                n.Valor = float.Parse(dt.Rows[i][1].ToString());
                n.Porcentaje = float.Parse(dt.Rows[i][2].ToString());
                int idAsig = int.Parse(dt.Rows[i][3].ToString());
                n.Asig = da.FindById(idAsig);

                lista.Add(n);

            }

            return lista;



        }

        public Boolean PorcentajeCompleto(int asig)
        {
            Boolean completo = false;
            DataTable dt = Ejecutar("SELECT SUM(porcentaje) FROM nota WHERE asignatura="+asig+" ");
            if (dt.Rows[0][0] == null)
            {
                completo = false;
            }
            else if(dt.Rows[0][0] != null)
            {
                float porc = float.Parse(dt.Rows[0][0].ToString());//System.FormatException: 'Input string was not in a correct format.'
                if (porc == 100)
                {
                    completo = true;
                }
                else
                {
                    completo = false;
                }

            }
           
            return completo;
        }


        public Boolean SePuedeAgregarLaNota(Nota n)
        {
            Boolean sePuede = true;

            DataTable dt = Ejecutar("SELECT SUM(porcentaje) FROM nota WHERE asignatura="+n.Asig.Id+"");
            float porcentajeAlmacenado = float.Parse(dt.Rows[0][0].ToString());
            float suma = porcentajeAlmacenado + n.Porcentaje;

            if (suma >= 100)
            {
                sePuede = false;
            }

            return sePuede;

        }


        public Nota FindById(int id)
        {
            Nota n = null;

            DAO_Asignatura da = new DAO_Asignatura();

            DataTable dt = Ejecutar("SELECT * FROM nota WHERE id=" + id + " ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                n = new Nota();
                n.Id =int.Parse(dt.Rows[i][0].ToString());
                n.Valor = float.Parse(dt.Rows[i][1].ToString());
                n.Porcentaje = float.Parse(dt.Rows[i][2].ToString());
                int idAsig = int.Parse(dt.Rows[i][3].ToString());
                n.Asig = da.FindById(idAsig);

            }

            return n;
        }


    }
}