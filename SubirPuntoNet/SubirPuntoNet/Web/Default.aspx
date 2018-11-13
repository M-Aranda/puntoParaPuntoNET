<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubirPuntoNet.Web.Default" %>
<%@ Import Namespace="SubirPuntoNet.Model.DAO" %>}
<%@ Import Namespace="SubirPuntoNet.Model.DAO" %>

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

            
            %>
        <select name="asignatura">
            <option value="1">wee</option>
            <option value="2">feed him</option>
            <option value="3">to the</option>

        </select>
        <input type="submit" value="Registrar nota">
    </form>
    <br>
    <br>
    <select>
        <option>I brought you into</option>
        <option>this place</option>
        <option>and I can</option>
        <option>take you out</option>
    </select>
    <br>
    <br>
    <br>
    <br>
    <button value="verNotas">Ver notas</button>
    <br>
    <br>
    <br>
    <table border="1">
        <tr>
            <td>ID</td>
            <td>Nota</td>
            <td>Porcentaje</td>
            <td>Nota * Porcentaje</td>   
        </tr>

    </table>
    <button value="eliminarNota">Eliminar nota</button>
    <h4>Porcentaje ingresado: </h4>






</body>
</html>
