using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Model {
    public class Nota {
        int id;
        float valor;
        float porcentaje;
        Asignatura asig;

        public int Id { get => id; set => id = value; }
        public float Valor { get => valor; set => valor = value; }
        public float Porcentaje { get => porcentaje; set => porcentaje = value; }
        public Asignatura Asig { get => asig; set => asig = value; }
    }
}