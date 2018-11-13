using SubirPuntoNet.Model;
using SubirPuntoNet.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubirPuntoNet.Controller {
    /// <summary>
    /// Descripción breve de RegistrarNota
    /// </summary>
    public class RegistrarNota : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            float valor=float.Parse(context.Request.Params["nota"]);
            float porcentaje = float.Parse(context.Request.Params["porcentaje"]);
            int fk_asignatura = int.Parse(context.Request.Params["asignatura"]);

            Nota n = new Nota();
            n.Valor = valor;
            n.Porcentaje = porcentaje;

            DAO_Asignatura da = new DAO_Asignatura();
            Asignatura a = da.FindById(fk_asignatura);
            n.Asig=a;

            DAO_Nota dn = new DAO_Nota();
            dn.Create(n);


            context.Response.Redirect("../Web/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}