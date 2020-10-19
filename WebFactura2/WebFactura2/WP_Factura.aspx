<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WP_Factura.aspx.vb" Inherits="WebFactura2.WP_Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Interfaz Web Facturas</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="author" content="Derek Mejia" />

    <script type="text/javascript">
        function NewWindow(id) {
            window.open("WP_Factura_IMP.aspx?ID=" + id, "width=300,height=300");
        }
    </script>
</head>

<body style="height: 100%; margin: 0; padding: 0;">
    <div class="container">

        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Factura</h3>
                </div>
                <div class="panel-body">

                    <!-- MENSAJES -->
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="row" style="padding: 10px;">
                                <div class="col-md-1" style="padding-top: 5px;"></div>
                                <asp:Label class="label label-success" ForeColor="Green" runat="server" ID="lblMensaje" />
                                <asp:Label class="label label-danger" ForeColor="Red" runat="server" ID="lblError" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <!-- DATOS DEL CLIENTE -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-4" style="padding-top: 5px;">
                            <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Datos del Cliente" runat="server" />
                        </div>

                    </div>
                    <!-- NUMERO DE LA FACTURA -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label9" Font-Size="Medium" Text="# Factura:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtFactura" CssClass="text form-control text-right" runat="server" Enabled="false" Font-Size="12px" />
                        </div>
                    </div>

                    <!-- CEDULA - FECHA -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="lblCedula" Font-Size="Medium" Text="Cedula:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtCedula" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="lblFecha" Font-Size="Medium" Text="Fecha:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtFechaRecepcion" runat="server" type="date" CssClass="text form-control" Style="width: 145px; font-size: 11px;" Enabled="false" />
                        </div>
                    </div>

                    <!-- NOMBRE - APELLIDO -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label2" Font-Size="Medium" Text="Nombre:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtNombre" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label3" Font-Size="Medium" Text="Apellido:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtApellido" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                    </div>

                    <!-- DIRECCION - CIUDAD -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label4" Font-Size="Medium" Text="Dirección:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtDireccion" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label5" Font-Size="Medium" Text="Ciudad:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtCiudad" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                    </div>

                    <!-- TELEFONO - CORREO -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label6" Font-Size="Medium" Text="Teléfono:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtTelefono" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label7" Font-Size="Medium" Text="Correo:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtCorreo" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                    </div>

                    <!-- DESCRIPCION -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Label ID="Label8" Font-Size="Medium" Text="Servicio:" runat="server" />
                        </div>
                        <div class="col-md-3" style="padding-top: 5px;">
                            <asp:TextBox ID="txtDescripcionServicio" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                        </div>
                    </div>

                    <!-- BOTONES -->
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-1" style="padding-top: 5px;"></div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click" CssClass="btn" BackColor="Gray" ForeColor="White" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Button ID="btnFinalizar" Text="Finalizar" runat="server" CssClass="btn" OnClick="btnFinalizar_Click" BackColor="Gray" ForeColor="White" />
                        </div>
                        <div class="col-md-1" style="padding-top: 5px;">
                            <asp:Button ID="btnImprimir" CssClass="btn" Enabled="true" Text="Imprimir" runat="server" OnClick="btnImprimir_Click" BackColor="Gray" ForeColor="White" />
                        </div>
                    </div>

                    <!-- GRILLA -->
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="row" style="padding-top: 10px">
                                <div class="col-md-1" style="padding-top: 5px;"></div>
                                <div class="col-md-10" style="padding-top: 5px;">
                                    <div class="table-responsive">
                                        <asp:Panel ID="pnlGRID" runat="server" CssClass="scrollingControlContainer">
                                            <asp:GridView ID="dgDetalles" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-striped table-bordered table-hover" Font-Size="15px"
                                                OnRowDataBound="dgDetalles_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" HeaderStyle-Width="50px" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:Label
                                                                ID="lblId"
                                                                Text='<%# Bind("ID") %>'
                                                                CssClass="text-center"
                                                                runat="server" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" Font-Size="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Descripcion" HeaderStyle-CssClass="text-center" HeaderStyle-Width="150px" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDescripcion"
                                                                data-width="100%"
                                                                CssClass="text text-right form-control"
                                                                Font-Size="10px"
                                                                Text='<%# Bind("DESCRIPCION") %>'
                                                                Enabled="true"
                                                                AutoPostBack="true"
                                                                OnTextChanged="txtDescripcion_TextChanged"
                                                                onkeyup="mayus(this);" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Base" HeaderStyle-CssClass="text-center" HeaderStyle-Width="150px" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlBase" AutoPostBack="true"
                                                                data-width="100%"
                                                                CssClass="form-control"
                                                                Font-Size="10px"
                                                                runat="server" OnSelectedIndexChanged="ddlBase_SelectedIndexChanged">
                                                                <asp:ListItem Text="" />
                                                                <asp:ListItem Text="Si" />
                                                                <asp:ListItem Text="No" />
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-CssClass="text-center" HeaderStyle-Width="300px" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtCantidad"
                                                                data-width="100%"
                                                                CssClass="text text-right form-control allownumericwithdecimal"
                                                                Font-Size="10px"
                                                                Text='<%# Bind("CANTIDAD") %>'
                                                                Enabled="true"
                                                                AutoPostBack="true"
                                                                OnTextChanged="txtCantidad_TextChanged"
                                                                onkeyup="mayus(this);" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" Font-Size="10px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Valor" HeaderStyle-CssClass="text-center" HeaderStyle-Width="300px" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtValor"
                                                                data-width="100%"
                                                                CssClass="text text-right form-control allownumericwithdecimal"
                                                                Font-Size="10px"
                                                                Text='<%# Bind("VALOR") %>'
                                                                Enabled="true"
                                                                AutoPostBack="true"
                                                                OnTextChanged="txtValor_TextChanged"
                                                                onkeyup="mayus(this);" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" Font-Size="10px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Button ID="lnkBtnAgregar" CssClass="btn" runat="server" Text="+" OnClick="lnkBtnAgregar_Click" Font-Size="10px" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Button ID="lnkBtnQuitar" CssClass="btn" runat="server" Text="-" OnClick="lnkBtnQuitar_Click" OnClientClick="return confirmation();" Font-Size="10px" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" Height="100%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>




                    <!-- FIN -->
                </div>
            </div>

        </form>

    </div>

    <script type="text/javascript">
        //Validaciones importantes        
        $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {

            $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
            $(this).val($(this).val().replace(/[^\d].+/, ""));
            if ((event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        function mayus(e) {
            e.value = e.value.toUpperCase();
        }

        function confirmation() {
            if (confirm('Está seguro de eliminar la línea ?')) {
                return true;
            } else {
                return false;
            }
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            // example - CssClass="allownumericwithdecimal"
            $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {

                $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^\d].+/, ""));
                if ((event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            function mayus(e) {
                e.value = e.value.toUpperCase();
            }
        });

    </script>

</body>
</html>
