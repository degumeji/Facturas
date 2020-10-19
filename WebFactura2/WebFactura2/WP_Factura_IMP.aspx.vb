Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CONTROLADORES

Public Class WP_Factura_IMP
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim BD As String
    Dim usuario As String = "sa"
    Dim clave As String = "1234"
#End Region


#Region "Procedimientos y funciones"
    Protected Sub exportarPdf()
        Try
            Dim id As String = Request.QueryString("ID")
            Dim exopt As ExportOptions = Nothing
            Dim dfdopt As DiskFileDestinationOptions = New DiskFileDestinationOptions()
            Dim RptDoc As ReportDocument = New ReportDocument()

            RptDoc.Load(Server.MapPath("~/REPORTE/RP_Facturas.rpt"))
            RptDoc.SetParameterValue("@id", id)
            RptDoc.SetDatabaseLogon(usuario, clave)
            RptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "Informe_Factura")

        Catch ex As System.Threading.ThreadAbortException

        End Try
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        exportarPdf()
    End Sub

End Class