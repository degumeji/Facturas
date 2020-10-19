Imports CONTROLADORES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class WP_Factura
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim clscliente As clsCliente
    Dim clsFacturaCab As clsFacturaCab
    Dim clsFacturaDet As clsFacturaDet

    Dim bdcliente As bdCliente
    Dim bdfacturacab As bdFacturaCab
    Dim bdfacturadet As bdFacturaDet

    Public Property vslistclsFacturaDet As List(Of clsFacturaDet)
        Get
            If IsNothing(ViewState("vslistclsFacturaDet")) Then
                Return Nothing
            End If
            Return CType(ViewState("vslistclsFacturaDet"), List(Of clsFacturaDet))
        End Get
        Set(value As List(Of clsFacturaDet))
            ViewState("vslistclsFacturaDet") = value
        End Set
    End Property

#End Region

#Region "Eventos"
    Public Sub nuevo()
        Try
            lblError.Visible = False
            lblMensaje.Visible = False
            btnFinalizar.Enabled = True
            btnImprimir.Enabled = False

            bdfacturacab = New bdFacturaCab()
            txtFactura.Text = bdfacturacab.consultarCabMAXID()

            txtCedula.Text = ""
            txtFechaRecepcion.Text = Date.Now.ToString("yyyy-MM-dd")
            txtNombre.Text = ""
            txtApellido.Text = ""
            txtDireccion.Text = ""
            txtCiudad.Text = ""
            txtTelefono.Text = ""
            txtCorreo.Text = ""
            txtDescripcionServicio.Text = ""

            clsFacturaDet = New clsFacturaDet()
            clsFacturaDet.ID = 1

            vslistclsFacturaDet = New List(Of clsFacturaDet)
            vslistclsFacturaDet.Add(clsFacturaDet)

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            Dim lblId As Label = CType(dgDetalles.Rows(0).Cells(0).FindControl("lblId"), Label)
            Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(0).Cells(1).FindControl("txtDescripcion"), TextBox)
            Dim ddlBase As DropDownList = CType(dgDetalles.Rows(0).Cells(2).FindControl("ddlBase"), DropDownList)
            Dim txtCantidad As TextBox = CType(dgDetalles.Rows(0).Cells(3).FindControl("txtCantidad"), TextBox)
            Dim txtValor As TextBox = CType(dgDetalles.Rows(0).Cells(4).FindControl("txtValor"), TextBox)
            Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(0).Cells(5).FindControl("lnkBtnAgregar"), Button)
            Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(0).Cells(6).FindControl("lnkBtnQuitar"), Button)

        Catch ex As Exception
            lblError.Text = "Error desde nuevo" & ex.Message()
            lblError.Visible = True
        End Try
    End Sub
    Public Function validar() As Boolean
        Dim encuentra As Boolean = True
        Dim mensaje As String = ""
        Dim Retornar As Boolean = False

        Try

            If txtCedula.Text = "" Then
                mensaje = "Cedula en blanco"
                encuentra = False
            End If

            If txtNombre.Text = "" And encuentra Then
                mensaje = "Nombre en blanco"
                encuentra = False
            End If

            If txtApellido.Text = "" And encuentra Then
                mensaje = "Apellido en blanco"
                encuentra = False
            End If

            If txtDireccion.Text = "" And encuentra Then
                mensaje = "Dirección en blanco"
                encuentra = False
            End If

            If txtCiudad.Text = "" And encuentra Then
                mensaje = "Ciudad en blanco"
                encuentra = False
            End If

            If txtTelefono.Text = "" And encuentra Then
                mensaje = "Telefono en blanco"
                encuentra = False
            End If

            If txtCorreo.Text = "" And encuentra Then
                mensaje = "Correo en blanco"
                encuentra = False
            End If

            If txtDescripcionServicio.Text = "" And encuentra Then
                mensaje = "Servicio en blanco"
                encuentra = False
            End If

            If vslistclsFacturaDet.Count = 0 And encuentra Then
                mensaje = "Detalle en blanco"
                encuentra = False

            Else
                For Each item As clsFacturaDet In vslistclsFacturaDet
                    If item.DESCRIPCION = "" And encuentra Then
                        mensaje = "Descripción en blanco"
                        encuentra = False
                        Exit For
                    End If

                    If item.BASES = "" And encuentra Then
                        mensaje = "Base en blanco"
                        encuentra = False
                        Exit For
                    End If

                    If item.CANTIDAD = 0 And encuentra Then
                        mensaje = "Cantidad en blanco"
                        encuentra = False
                        Exit For
                    End If

                    If item.VALOR = 0 And encuentra Then
                        mensaje = "Valor en blanco"
                        encuentra = False
                        Exit For
                    End If
                Next
            End If

            If encuentra And mensaje = "" Then
                Retornar = True
            Else
                lblError.Text = mensaje
                lblError.Visible = True
            End If

        Catch ex As Exception
            lblError.Text = "Error desde validar." & ex.Message
            lblError.Visible = True
        End Try

        Return Retornar
    End Function

    Public Sub finalizar()
        Try
            If validar() Then

                clscliente = New clsCliente()
                clscliente.CEDULA = txtCedula.Text
                clscliente.NOMBRE = txtNombre.Text
                clscliente.APELLIDO = txtApellido.Text
                clscliente.DIRECCION = txtDireccion.Text
                clscliente.CIUDAD = txtCiudad.Text
                clscliente.TELEFONO = txtTelefono.Text
                clscliente.CORREO = txtCorreo.Text

                bdcliente = New bdCliente()

                Dim numero As Integer = bdcliente.guardarCliente(clscliente)

                If numero > 0 Then
                    clsFacturaCab = New clsFacturaCab()
                    clsFacturaCab.DESCRIPCION = txtDescripcionServicio.Text
                    clsFacturaCab.ID_CLIENTE = numero

                    Dim baseiva0 As Double = 0
                    Dim baseiva12 As Double = 0

                    Dim iva As Double = 0
                    Dim total As Double = 0

                    For Each item As clsFacturaDet In vslistclsFacturaDet
                        If item.BASES = "Si" Then
                            'baseiva12'
                            baseiva12 = baseiva12 + (item.CANTIDAD * item.VALOR)
                        Else
                            'baseiva0'
                            baseiva0 = baseiva0 + (item.CANTIDAD * item.VALOR)
                        End If
                    Next

                    iva = baseiva12 * 0.12
                    total = baseiva0 + baseiva12 + iva

                    clsFacturaCab.BASEIVA0 = baseiva0
                    clsFacturaCab.BASEIVA12 = baseiva12
                    clsFacturaCab.IVA = iva
                    clsFacturaCab.TOTAL = total

                    bdfacturacab = New bdFacturaCab()
                    numero = bdfacturacab.guardarCab(clsFacturaCab)

                    If numero > 0 Then

                        For Each item As clsFacturaDet In vslistclsFacturaDet
                            item.ID_CABECERA = numero
                        Next

                        bdfacturadet = New bdFacturaDet()
                        Dim resultado As Boolean = bdfacturadet.guardarDet(vslistclsFacturaDet)

                        If resultado Then
                            lblMensaje.Text = "Se grabó correctamente."
                            lblMensaje.Visible = True
                            btnFinalizar.Enabled = False
                            btnImprimir.Enabled = True
                        Else
                            lblError.Text = "No se grabo la información correctamente"
                            lblError.Visible = True
                        End If

                    Else
                        lblError.Text = "No se grabo la cabecera correctamente"
                        lblError.Visible = True
                    End If
                Else
                    lblError.Text = "No se grabo el cliente"
                    lblError.Visible = True
                End If

            End If
        Catch ex As Exception
            lblError.Text = "Error desde finalizar." & ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Public Sub imprimir()
        Try
            ClientScript.RegisterStartupScript(Me.GetType(), "funcion", "NewWindow( '" & txtFactura.Text & "' );", True)
        Catch engine As EngineException
            lblError.Text = "No existe información para lo solicitado."
            lblError.Visible = True
        End Try
    End Sub
    Public Sub Agregar(sender As Object)
        Try
            Dim btnAgregar As Button = CType(sender, Button)
            Dim posicion As GridViewRow = CType(btnAgregar.Parent.Parent, GridViewRow)
            Dim v1 As Integer = posicion.RowIndex

            clsFacturaDet = New clsFacturaDet()
            vslistclsFacturaDet.Add(clsFacturaDet)

            Dim num As Integer = 0
            For Each item As clsFacturaDet In vslistclsFacturaDet
                num = num + 1
                item.ID = num
            Next

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            v1 = 0

            'DETALLE'
            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                Dim ddlBase As DropDownList = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                Dim txtCantidad As TextBox = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                Dim txtValor As TextBox = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(v1).Cells(5).FindControl("lnkBtnAgregar"), Button)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

        Catch ex As Exception
            lblError.Text = "Error en la función de btnAgregarGrid_Click. Error:" + ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Public Sub Quitar(sender As Object)
        Try
            Dim btnQuitarGrid As Button = CType(sender, Button)
            Dim posicion As GridViewRow = CType(btnQuitarGrid.Parent.Parent, GridViewRow)
            Dim v1 As Integer = posicion.RowIndex
            Dim posi As Integer = 0

            If vslistclsFacturaDet.Count() > 0 Then
                vslistclsFacturaDet.RemoveAt(v1)
            End If

            If vslistclsFacturaDet.Count() = 0 Then
                clsFacturaDet = New clsFacturaDet()
                clsFacturaDet.ID = 1

                vslistclsFacturaDet = New List(Of clsFacturaDet)
                vslistclsFacturaDet.Add(clsFacturaDet)
            End If

            Dim num As Integer = 0
            For Each item As clsFacturaDet In vslistclsFacturaDet
                num = num + 1
                item.ID = num
            Next

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            v1 = 0

            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                Dim ddlBase As DropDownList = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                Dim txtCantidad As TextBox = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                Dim txtValor As TextBox = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(v1).Cells(5).FindControl("lnkBtnAgregar"), Button)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

        Catch ex As Exception
            lblError.Text = "Error en la función de quitar. Error:" + ex.Message
            lblError.Visible = True

        End Try
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                nuevo()
            End If
        Catch ex As Exception
            lblError.Text = "Error desde Load" & ex.Message()
            lblError.Visible = True
        End Try
    End Sub
    Protected Sub dgDetalles_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub
    Protected Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim txtDescripcion As TextBox = CType(sender, TextBox)
            Dim pos As GridViewRow = CType(txtDescripcion.Parent.Parent, GridViewRow)

            vslistclsFacturaDet(pos.RowIndex).DESCRIPCION = txtDescripcion.Text

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            Dim v1 As Integer = 0

            'DETALLE'
            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                txtDescripcion = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                Dim ddlBase As DropDownList = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                Dim txtCantidad As TextBox = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                Dim txtValor As TextBox = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(v1).Cells(5).FindControl("lnkBtnAgregar"), Button)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

        Catch ex As Exception
            lblError.Text = "txtDescripcion_TextChanged. Error:" & ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Protected Sub ddlBase_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            Dim ddlBase As DropDownList = CType(sender, DropDownList)
            Dim pos As GridViewRow = CType(ddlBase.Parent.Parent, GridViewRow)

            vslistclsFacturaDet(pos.RowIndex).BASES = ddlBase.SelectedItem.Text

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            Dim v1 As Integer = 0

            'DETALLE'
            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                ddlBase = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                Dim txtCantidad As TextBox = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                Dim txtValor As TextBox = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(v1).Cells(5).FindControl("lnkBtnAgregar"), Button)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

        Catch ex As Exception
            lblError.Text = "Error en la función de ddlBase_SelectedIndexChanged. Error:" + ex.Message
            lblError.Visible = True

        End Try
    End Sub
    Protected Sub txtCantidad_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim txtCantidad As TextBox = CType(sender, TextBox)
            Dim pos As GridViewRow = CType(txtCantidad.Parent.Parent, GridViewRow)

            vslistclsFacturaDet(pos.RowIndex).CANTIDAD = txtCantidad.Text

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            Dim v1 As Integer = 0

            'DETALLE'
            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                Dim ddlBase As DropDownList = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                txtCantidad = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                Dim txtValor As TextBox = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(v1).Cells(5).FindControl("lnkBtnAgregar"), Button)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

        Catch ex As Exception
            lblError.Text = "Error desde txtCantidad_TextChanged. Error: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Protected Sub txtValor_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim txtValor As TextBox = CType(sender, TextBox)
            Dim pos As GridViewRow = CType(txtValor.Parent.Parent, GridViewRow)

            vslistclsFacturaDet(pos.RowIndex).VALOR = txtValor.Text

            dgDetalles.DataSource = vslistclsFacturaDet
            dgDetalles.DataBind()

            Dim v1 As Integer = 0

            'DETALLE'
            For Each item As clsFacturaDet In vslistclsFacturaDet
                Dim lblId As Label = CType(dgDetalles.Rows(v1).Cells(0).FindControl("lblId"), Label)
                Dim txtDescripcion As TextBox = CType(dgDetalles.Rows(v1).Cells(1).FindControl("txtDescripcion"), TextBox)
                Dim ddlBase As DropDownList = CType(dgDetalles.Rows(v1).Cells(2).FindControl("ddlBase"), DropDownList)
                Dim txtCantidad As TextBox = CType(dgDetalles.Rows(v1).Cells(3).FindControl("txtCantidad"), TextBox)
                txtValor = CType(dgDetalles.Rows(v1).Cells(4).FindControl("txtValor"), TextBox)
                Dim lnkBtnQuitar As Button = CType(dgDetalles.Rows(v1).Cells(6).FindControl("lnkBtnQuitar"), Button)

                lblId.Text = item.ID

                If item.BASES = "Si" Then
                    ddlBase.SelectedIndex = 1
                Else
                    ddlBase.SelectedIndex = 2
                End If

                v1 = v1 + 1
            Next

            Dim lnkBtnAgregar As Button = CType(dgDetalles.Rows(pos.RowIndex).Cells(4).FindControl("lnkBtnAgregar"), Button)
            lnkBtnAgregar.Focus()

        Catch ex As Exception
            lblError.Text = "Error desde txtValor_TextChanged. Error: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Protected Sub lnkBtnAgregar_Click(sender As Object, e As EventArgs)
        Agregar(sender)
    End Sub
    Protected Sub lnkBtnQuitar_Click(sender As Object, e As EventArgs)
        Quitar(sender)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        nuevo()
    End Sub
    Protected Sub btnFinalizar_Click(sender As Object, e As EventArgs)
        finalizar()
    End Sub
    Protected Sub btnImprimir_Click(sender As Object, e As EventArgs)
        imprimir()
    End Sub

End Class