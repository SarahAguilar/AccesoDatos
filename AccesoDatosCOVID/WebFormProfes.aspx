<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormProfes.aspx.cs" Inherits="AccesoDatosCOVID.WebFormProfes" %>

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
              <a class="nav-link" href="WebForm2.aspx">Alumnos</a>
            </li>
          </ul>
        </div>
      </div>
    </nav> <%--Fin del navbar--%>
    <form id="form1" runat="server" class ="container mt-4"> 
        <div class="row">
            <h1 class="mb-3">Detalle profesor</h1>
            <div class="row">
                <div class="col-8">
                    <asp:GridView ID="GridViewUnProfe" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewUnProfe_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <br />
                </div>
                <div class="col-4">
                    <asp:Button ID="Modificar" runat="server" Text="Editar profesor" OnClick="Modificar_Click" />
                    <asp:Button ID="Eliminar" runat="server" Text="Eliminar profesor" />
                    <br />
                </div>
            </div> <%--fin div row--%>
            <div class="row">
                <div class="col-4">
                    <asp:TextBox ID="TextBoxStatus2" runat="server" disabled></asp:TextBox>
                    <br />
                    <br />
        <h1 class="mb-3">Editar Profesor </h1>
        <p class="mb-3">Registro de Empleado </p>
        <p class="mb-3">
            <asp:TextBox ID="txtRE" runat="server" Width="163px"></asp:TextBox>
        </p>
        <p class="mb-3">Nombre </p>
        <p class="mb-3">
            <asp:TextBox ID="txtNom" runat="server" Width="160px"></asp:TextBox>
        </p>
        <p class="mb-3">Apellido Paterno </p>
        <p class="mb-3">
            <asp:TextBox ID="ApellidoPa" runat="server" Width="159px"></asp:TextBox>
        </p>
        <p class="mb-3">Apellido Materno </p>
        <p class="mb-3">
            <asp:TextBox ID="ApellidoMa" runat="server" Width="164px"></asp:TextBox>
        </p>
        <p class="mb-3">Genero </p>
        <p class="mb-3">
            <asp:TextBox ID="Genero" runat="server" Width="162px"></asp:TextBox>
        </p>
        <p class="mb-3">Categoria </p>
        <p class="mb-3">
            <asp:TextBox ID="Categoria" runat="server" Width="166px"></asp:TextBox>
        </p>
        <p class="mb-3">Correo </p>
        <p class="mb-3">
            <asp:TextBox ID="Correo" runat="server" Width="238px"></asp:TextBox>
        </p>
        <p class="mb-3">Celular </p>
        <p class="mb-3">
            <asp:TextBox ID="Celular" runat="server" Width="177px"></asp:TextBox>
        </p>
                </div>
                <div class="col-4">
                    
                </div>
                <div class="col-4">
                    
                </div>
            </div>
            <div class="col-10 ">
                <asp:Button ID="ButtonEditar" runat="server" Text="Agregar registro" class="btn btn-success mt-3 mb-3 " OnClick="ButtonEditar_Click"/>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" class="mb-5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="226px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
               
            </div> <%--fin div col-10 --%>
            <div class="col-2">
            </div><%--fin div col-2 --%>     
            <div class="row mt-mb-3">
                <asp:Label ID="LabelMsj" runat="server" Text=""></asp:Label>
                <div class="col-5 mt-3">
                    <h5><asp:Label ID="LabelPrueba" runat="server" Text="Añadir documento de prueba COVID"></asp:Label>
                    </h5>
                    <asp:FileUpload ID="FileUploadPrueba" runat="server" class="form-control mb-3"/>
                    <asp:Button ID="ButtonPrueba" runat="server" Text="Subir Prueba" class="btn btn-outline-info" OnClick="ButtonPrueba_Click"/>
                    <asp:TextBox ID="TextBoxStatus" runat="server" disabled CssClass="mt-3" Width="487px" placeholder="Status"></asp:TextBox>
                </div><%--fin div col-5 --%>   
                <div class="col-5 mt-3">
                    <h5><asp:Label ID="LabelIncapacidad" runat="server" Text="Añadir documento de incapacidad"></asp:Label>
                    </h5>
                    <asp:FileUpload ID="FileUploadIncapacidad" runat="server" class="form-control mb-3"/>   
                    <asp:Button ID="ButtonIncapacidad" runat="server" Text="Subir incapacidad" class="btn btn-outline-info" OnClick="ButtonIncapacidad_Click"/>
                    <br />
                    
                </div><%--fin div col-5 --%>   
                <div class="col-2 mt-3">
                    
                    <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar registro" class="btn btn-danger" OnClick="ButtonEliminar_Click"/>
                </div><%--fin div col-2 mt-3--%>  
                
            </div><%--fin div row mt-mb-3 --%>    
            
        </div> <%--fin div row --%>        <%--fin del form con container--%>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
        
    </form>
  </body>
</html>

