<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrosEvaluacion.aspx.cs" Inherits="PrimerParcial.UI.Registros.RegistrosEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Primer Parcial</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group">
                        <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                        <div class="col-md-2">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="BUrcar" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdTextBox" ErrorMessage="*" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
                    </div>

                    <%-- Fecha--%>
                    <div class="form-group">
                        <label for="fechaTextBox" class="col-md-3 control-label input-sm">Fecha: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="Estudiante" class="col-md-3 control-label input-sm">Estudiante: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ID="EstudianteTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Estudiante" runat="server" MaxLength="200"
                                ControlToValidate="EstudianteTextBox"
                                ErrorMessage="Campo Estudiante obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Estudiante obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Estudiante
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="Categoria:" class="col-md-3 control-label input-sm">Categoria: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ID="CategoriaTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Categoria" runat="server" MaxLength="200"
                                ControlToValidate="CategoriaTextBox"
                                ErrorMessage="Campo Categoria obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Categoria obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Categoria
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="Valor:" class="col-md-3 control-label input-sm">Valor: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="ValorTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="Logrado:" class="col-md-3 control-label input-sm">Logrado: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="LogradoTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="AgregardoButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                    </div>
                    <div class="table-responsive">
                        <div class="center">
                            <asp:GridView ID="GridView"
                                runat="server"
                                class="table table-condensed table-bordered table-responsive"
                                CellPadding="4" ForeColor="#333333" GridLines="None">

                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Remover">
                                        <ItemTemplate>
                                            <asp:Button ID="RemoveLinkButton" runat="server" CausesValidation="false" CommandName="Select"
                                                Text="Remover " class="btn btn-success btn-sm" OnClick="RemoveLinkButton_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Total:" class="col-md-3 control-label input-sm">Total: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="TotalTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Es necesario elegir ID valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un ID valido.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
