﻿using SubirPuntoNet.Model;
using SubirPuntoNet.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SubirPuntoNet.Controller
{
    /// <summary>
    /// Summary description for EliminarNotaHandler
    /// </summary>
    public class EliminarNotaHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            DAO_Nota dn = new DAO_Nota();
            int id = int.Parse(context.Request.Params["idAEliminar"]);
            Nota n = dn.FindById(id);
            dn.Delete(id);
            //List<Nota> listaDeNotas = dn.ReadNotasDeLaAsignaturaComoLista(n.Asig.Id); //comentado por las consideraciones de la guia
            //context.Session["listaDeNotas"] = listaDeNotas; comentado por las consideraciones de la guia




            context.Response.Redirect("../Web/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}