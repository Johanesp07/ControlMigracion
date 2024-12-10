<%@ Page Title="" Language="C#" MasterPageFile="~/ClssVista/Menu.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="ControlMigracion.ClssVista.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <!-- Sección para listar Entradas -->
        <div class="card mb-4">
            <div class="card-header">
                <h4>Entradas</h4>
            </div>
            <div class="card-body">
                <div class="row">
                </div>
                <br />
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="gvEntradas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IDEntrada" HeaderText="ID de Entrada" />
                                <asp:BoundField DataField="IDViajero" HeaderText="ID de Viajero" />
                                <asp:BoundField DataField="FechaEntrada" HeaderText="Fecha de Entrada" DataFormatString="{0:g}" />
                                <asp:BoundField DataField="IDPaisOrigen" HeaderText="País de Origen" />
                                <asp:BoundField DataField="IDUsuarioRegistro" HeaderText="Registrado por" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <!-- Sección para listar Salidas -->
        <div class="card mb-4">
            <div class="card-header">
                <h4>Salidas</h4>
            </div>
            <div class="card-body">
                <div class="row">
                </div>
                <br />
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="gvSalidas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IDSalida" HeaderText="ID de Salida" />
                                <asp:BoundField DataField="IDViajero" HeaderText="ID de Viajero" />
                                <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" DataFormatString="{0:g}" />
                                <asp:BoundField DataField="IDPaisDestino" HeaderText="País de Destino" />
                                <asp:BoundField DataField="IDUsuarioRegistro" HeaderText="Registrado por" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
