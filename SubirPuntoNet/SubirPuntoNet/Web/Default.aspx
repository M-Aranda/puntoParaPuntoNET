<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubirPuntoNet.Web.Default" %>
<%@ Import Namespace="SubirPuntoNet.Model.DAO" %>
<%@ Import Namespace="SubirPuntoNet.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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
                        <td><%=(n.Valor*(n.Porcentaje/100))%></td>
                        <td>
                            <form action="../Controller/EliminarNotaHandler.ashx" method="post">
                            <input type="hidden" name="idAEliminar" value=<%=n.Id%>>
                            <input type="submit" value="Eliminar">
                            </form>
                        </td>
                    </tr>


                <%
                    porcIgresado +=n.Valor*(n.Porcentaje/100);
                    }


                %>

        

            <%}
                Session.Clear();
            %>




    </table>

    <div name="porcNOEs100">
        <h4>Porcentaje ingresado:<%=porcIgresado %></h4>
    </div>


    <div name="porcEs100">
        <h4>Promedio: </h4>
        <h4>Necesitas un: </h4>
    </div>

    






</body>
</html>
