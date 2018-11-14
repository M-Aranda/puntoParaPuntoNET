using SubirPuntoNet.Model;
using SubirPuntoNet.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SubirPuntoNet.Controller {
    /// <summary>
    /// Descripción breve de RegistrarNota
    /// </summary>
    public class RegistrarNota : IHttpHandler, IRequiresSessionState {

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

            if ((dn.PorcentajeCompleto(fk_asignatura) == false) && (dn.SePuedeAgregarLaNota(n)==true)) 
            {
                dn.Create(n);
                //List<Nota> listaDeNotas = dn.ReadNotasDeLaAsignaturaComoLista(n.Asig.Id); //comentado por las consideraciones de la guia
                //context.Session["listaDeNotas"] = listaDeNotas; //comentado por las consideraciones de la guia

              }else
              {
            context.Session["error"] = "No puede agregar esa nota porque sobrepasa el porcentaje maximo o ya se alcanzo";
              }



            context.Response.Redirect("../Web/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}