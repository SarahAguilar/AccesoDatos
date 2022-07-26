<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AccesoDatosCOVID.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-light">
      <div class="container-fluid">
        <a class="navbar-brand disabled" href="#">AccesoDatos</a>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="WebForm1.aspx">Profesores</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Alumnos</a>
            </li>
          </ul>
        </div>
      </div>
    </nav> <%--Fin del navbar--%>
    <form id="form1" runat="server" class ="container mt-4"> 
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" class="btn btn-info"/>
            <asp:TextBox ID="TextBox1" runat="server" Width="210px"></asp:TextBox>

        </div>
    </form><%--fin del form con container--%>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
  </body>
</html>
