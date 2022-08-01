<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEditarProfes.aspx.cs" Inherits="AccesoDatosCOVID.WebFormEditarProfes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <title>Editar profesor</title>
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-light">
      <div class="container-fluid">
        <a class="navbar-brand disabled" href="#">AccesoDatos</a>
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
    <form id="form1" runat="server" class="container mt-3 mb-3">
        <h1 class="mb-3">Editar profesor</h1>
        <div class="row">
            <div class="col-6">
                <div class="mb-3 row">
                <asp:Label ID="Label1" runat="server" Text="Id positivo profe:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxIdPositivoProfe" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label2" runat="server" Text="Fecha de confirmación:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxFechaConfirmado" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label3" runat="server" Text="Comprobación:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxComprobacion" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label4" runat="server" Text="Antecedentes:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxAntecedentes" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label5" runat="server" Text="Riesgo:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxRiesgo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label6" runat="server" Text="N° de contagio:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox6NumContagio" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label8" runat="server" Text="Id del profesor:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxF_Profe" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label9" runat="server" Text="Documento de prueba:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxDoc_Prueba" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label10" runat="server" Text="N° incapacidad:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1PeriodoInca" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label11" runat="server" Text="D'ias de incapacidad:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxDíasInca" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label12" runat="server" Text="Documento incapacidad:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxDoc_Incapacidad" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="Label7" runat="server" Text="Extra:" class="col-sm-3 col-form-label"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBoxExtra" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
         </div> 
  

            <div class="col-6">
                <div class="mb-3 row">
                    <asp:Label ID="Label13" runat="server" Text="Id seguimiento:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxIdSegui" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label14" runat="server" Text="Id positifo profe:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxF_PosiProfe" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label15" runat="server" Text="Id medico:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxIdMedico" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label16" runat="server" Text="Fecha:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label17" runat="server" Text="Forma en que comunico:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxFormComunica" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label18" runat="server" Text="Reporte:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxReporte" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label19" runat="server" Text="Entrevista:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxEntrevista" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <asp:Label ID="Label20" runat="server" Text="Extra:" class="col-sm-3 col-form-label"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBoxExtraSegui" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
         </div>
        <div class="mb-3 row">
            <div class="col-2">
            </div>
            <div class="col-8">
                <asp:Button ID="ButtonAgregar" runat="server" Text="E D I T A R" class="btn btn-success col-sm-12"/>
            </div>
            <div class="col-2">
            </div>
        </div>
        
         <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
    
    </form>
</body>
</html>
