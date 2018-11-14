<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubirPuntoNet.Web.Default" %>
<%@ Import Namespace="SubirPuntoNet.Model.DAO" %>
<%@ Import Namespace="SubirPuntoNet.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap-theme.min.css">
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>


</head>

<body>
    <form action="../Controller/RegistrarNota.ashx" method="post">
        <h5>Nota</h5>
        <input type="text" name="nota" required>
        <h5>Porcentaje</h5>
        <input type="text" name="porcentaje" required>
        <h5>Asignatura</h5>
        <%
            DAO_Asignatura da = new DAO_Asignatura();
            List<Asignatura> asignaturas = da.ReadComoLista();
            %>
        <select name="asignatura">
        <%
            foreach (Asignatura a in asignaturas)
            {%>
            <option name="idAsignaturaParaDarNota" value=<%= a.Id%>><%=a.Nombre%></option>
            <%} %>
        </select>
        <input type="submit" value="Registrar nota">
    </form>
    <br>

    <%
        if (Session["error"] != null)
        {%>
            <h2><%=Session["error"]%></h2>
        <%
                Session.Clear();
            }
        %>

    <div id="Notas" name="Notas">
    <br>
    <form action="../Controller/VerNotasHandler.ashx" method="post">
        <select name="asignaa">
        <%
            foreach (Asignatura a in asignaturas)
            {%>
            <option name="idAsignatura" value=<%= a.Id%>><%=a.Nombre%></option>
            <%} %>
        </select>
        <input type="submit" value="Ver Notas">
    </form>
    <br>
    <table id="tablaDeNotas" border="1">
        <tr>
            <td>ID</td>
            <td>Nota</td>
            <td>Porcentaje</td>
            <td>Nota * Porcentaje</td>
            <td>Accion</td>
        </tr>

        <%
            float promedio=0;
            float porcIgresado = 0;
            List<Nota> listaDeNotas=(List<Nota>)Session["listaDeNotas"];
            if (listaDeNotas != null)
            {
                
                foreach (Nota n in listaDeNotas)
                {%>
            
                    <tr>
                        <td><%=n.Id %></td>
                        <td><%=n.Valor %></td>
                        <td><%=n.Porcentaje %></td>
                        <td><%=Math.Round((n.Valor*(n.Porcentaje/100)),1)%></td>
                        <td>
                            <form id="eliminacion" action="../Controller/EliminarNotaHandler.ashx" method="post">
                            <input type="hidden" name="idAEliminar" value=<%=n.Id%>>
                            <input type="submit" value="Eliminar" onclick="confirmacion()">
                            </form>
                        </td>
                    </tr>


                <%
                        porcIgresado +=n.Porcentaje;
                        promedio += n.Valor * (n.Porcentaje / 100);
                    }


                %>

        

            <%}
                Session.Clear();
            %>




    </table>

    <div name="porcNOEs100">
        <h4>Porcentaje ingresado:<%=porcIgresado %></h4>
    </div>


     <%if (porcIgresado == 100)
         {%>
        <h4>Promedio:<%=promedio%> </h4>
        <% float notaNecesaria = (((promedio * .7f)-4.0f))/.3f;
            notaNecesaria = Math.Abs(notaNecesaria);

            %> 
        <h4>Necesitas un: <%=Math.Round(notaNecesaria, 2)%></h4>
         <%}%>


    
    </div>





</body>

    <script src="../jQuery/JQuery.js"></script>
            <script>
            function confirmacion() {
               $('#eliminacion').submit(function () {
               var seleccion = $("#datos").val();
               var r = confirm("Seguro que quiere eliminar a " + seleccion+"?");
               if (r) {
               return true;
                } else if (!r) {
               return false;
                }
                     // return r; si se apreto cancelar es falso y no pasa nada, si es true se hace el submit
                   });
                 }
        </script>


</html>
