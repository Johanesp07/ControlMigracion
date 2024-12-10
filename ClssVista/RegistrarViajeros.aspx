<%@ Page Title="" Language="C#" MasterPageFile="~/ClssVista/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarViajeros.aspx.cs" Inherits="ControlMigracion.ClssVista.RegistrarViajeros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content-header">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Editar Viajero</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/CapaPresentacion/RegistroViajeros/RegistrarViajeros.aspx">Viajeros</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Editar Viajero</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <div class="container mt-5">
        <div class="row justify-content-start">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">Datos del Viajero</h3>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre</asp:Label>
                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
                            </div>
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtApellido" CssClass="form-label">Apellido</asp:Label>
                                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"/>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtNroPasaporte" CssClass="form-label">Número de Pasaporte</asp:Label>
                                <asp:TextBox runat="server" ID="txtNroPasaporte" CssClass="form-control" />
                            </div>
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label">Fecha de Nacimiento</asp:Label>
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label runat="server" AssociatedControlID="ddlNacionalidad" CssClass="form-label">Nacionalidad</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlNacionalidad" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione una nacionalidad</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="Agregar_Click" Visible="true" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton runat="server" PostBackUrl="~/Pages/Viajeros/RegistroViajeros.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnActualizar" class="btn btn-success" runat="server" Text="Actualizar" OnClick="Actualizar_Click" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row justify-content-start mt-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">Editar/Eliminar Viajero</h3>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <asp:Label runat="server" AssociatedControlID="ddlViajeros" CssClass="form-label">Seleccionar Viajero</asp:Label>
                                <asp:DropDownList runat="server" ID="ddlViajeros" CssClass="form-select">
                                    <asp:ListItem Value="">Seleccione un viajero</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnEditar" class="btn btn-primary" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
