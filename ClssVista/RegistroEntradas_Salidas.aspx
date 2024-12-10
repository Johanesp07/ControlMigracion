<%@ Page Title="" Language="C#" MasterPageFile="~/ClssVista/Menu.Master" AutoEventWireup="true" CodeBehind="RegistroEntradas_Salidas.aspx.cs" Inherits="ControlMigracion.ClssVista.RegistroEntradas_Salidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="app-content-header">
        <br />
        <br />
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Registro de Entradas y Salidas</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Default.aspx">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Registro de Entradas y Salidas</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <!-- Sección de Entradas -->
    <div class="card mb-4">
        <div class="card-header bg-primary text-white">
            <h4 class="mb-0">Entradas</h4>
        </div>
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlViajeroEntrada" CssClass="form-label">Viajero:</asp:Label>
                    <asp:DropDownList ID="ddlViajeroEntrada" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="txtFechaEntrada" CssClass="form-label">Fecha de Entrada:</asp:Label>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlPaisOrigen" CssClass="form-label">País de Origen:</asp:Label>
                    <asp:DropDownList ID="ddlPaisOrigen" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlUsuario2" CssClass="form-label">Transaccion Realidada por::</asp:Label>
                    <asp:DropDownList ID="ddlUsuario2" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <br />
                    <asp:Button ID="btnRegistrarEntrada" runat="server" Text="Registrar Entrada" CssClass="btn btn-primary" OnClick="btnRegistrarEntrada_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Sección de Salidas -->
    <div class="card">
        <div class="card-header bg-success text-white">
            <h4 class="mb-0">Salidas</h4>
        </div>
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlViajeroSalida" CssClass="form-label">Viajero:</asp:Label>
                    <asp:DropDownList ID="ddlViajeroSalida" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="txtFechaSalida" CssClass="form-label">Fecha de Salida:</asp:Label>
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlPaisDestino" CssClass="form-label">País de Destino:</asp:Label>
                    <asp:DropDownList ID="ddlPaisDestino" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="ddlUsuario" CssClass="form-label">Transaccion Realidada por::</asp:Label>
                    <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <br />
                    <asp:Button ID="btnRegistrarSalida" runat="server" Text="Registrar Salida" CssClass="btn btn-success" OnClick="btnRegistrarSalida_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
