using SubirPuntoNet.Model;
using SubirPuntoNet.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SubirPuntoNet.Controller
{
    /// <summary>
    /// Summary description for VerNotasHandler
    /// </summary>
    public class VerNotasHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            DAO_Nota dn = new DAO_Nota();
            //int idAsignaturaElegida = int.Parse(context.Request.Form["asignaturaABuscar"].ToString()); 
            int idAsignaturaElegida = int.Parse(context.Request.Params["asignaa"]);
            List<Nota> listaDeNotas = dn.ReadNotasDeLaAsignaturaComoLista(idAsignaturaElegida);

            context.Session["listaDeNotas"] = listaDeNotas;


            context.Response.Redirect("../Web/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}