using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Model {
    public class Asignatura {

        int id;
        String nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}