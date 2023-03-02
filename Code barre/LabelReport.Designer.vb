<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LabelReport
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataMatrixGS1Generator1 As DevExpress.XtraPrinting.BarCode.DataMatrixGS1Generator = New DevExpress.XtraPrinting.BarCode.DataMatrixGS1Generator()
        Dim QrCodeGenerator1 As DevExpress.XtraPrinting.BarCode.QRCodeGenerator = New DevExpress.XtraPrinting.BarCode.QRCodeGenerator()
        Dim Code128Generator1 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrDataMatrix = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrQrCode = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrBarCode = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrLabelNumSerie = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrPictureBoxOnsa = New DevExpress.XtraReports.UI.XRPictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.XrLabelDate, Me.XrDataMatrix, Me.XrLine3, Me.XrQrCode, Me.XrBarCode, Me.XrLabelNumSerie, Me.XrPictureBox1, Me.XrPictureBoxOnsa})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 350.0!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.Name = "Detail"
        '
        'XrPanel1
        '
        Me.XrPanel1.Dpi = 254.0!
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(59.521!, 253.9176!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(238.1044!, 67.74887!)
        '
        'XrLabelDate
        '
        Me.XrLabelDate.Angle = 90.0!
        Me.XrLabelDate.AutoWidth = True
        Me.XrLabelDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelDate.CanGrow = False
        Me.XrLabelDate.Dpi = 254.0!
        Me.XrLabelDate.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.XrLabelDate.LocationFloat = New DevExpress.Utils.PointFloat(14.54191!, 62.60511!)
        Me.XrLabelDate.Name = "XrLabelDate"
        Me.XrLabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelDate.SizeF = New System.Drawing.SizeF(44.97909!, 230.7071!)
        Me.XrLabelDate.StylePriority.UseBorders = False
        Me.XrLabelDate.StylePriority.UseFont = False
        Me.XrLabelDate.StylePriority.UseTextAlignment = False
        Me.XrLabelDate.Text = "15/06/2021 "
        Me.XrLabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabelDate.WordWrap = False
        '
        'XrDataMatrix
        '
        Me.XrDataMatrix.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrDataMatrix.AutoModule = True
        Me.XrDataMatrix.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrDataMatrix.Dpi = 254.0!
        Me.XrDataMatrix.LocationFloat = New DevExpress.Utils.PointFloat(14.54191!, 14.41667!)
        Me.XrDataMatrix.Module = 5.0!
        Me.XrDataMatrix.Name = "XrDataMatrix"
        Me.XrDataMatrix.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
        Me.XrDataMatrix.ShowText = False
        Me.XrDataMatrix.SizeF = New System.Drawing.SizeF(44.97908!, 58.77177!)
        Me.XrDataMatrix.StylePriority.UseBorders = False
        Me.XrDataMatrix.StylePriority.UsePadding = False
        Me.XrDataMatrix.Symbology = DataMatrixGS1Generator1
        Me.XrDataMatrix.Text = "12/12/2020"
        '
        'XrLine3
        '
        Me.XrLine3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine3.BorderWidth = 1.0!
        Me.XrLine3.Dpi = 254.0!
        Me.XrLine3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(297.6254!, 25.00001!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(58.20834!, 306.9167!)
        Me.XrLine3.StylePriority.UseBorderDashStyle = False
        Me.XrLine3.StylePriority.UseBorders = False
        Me.XrLine3.StylePriority.UseBorderWidth = False
        '
        'XrQrCode
        '
        Me.XrQrCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrQrCode.AutoModule = True
        Me.XrQrCode.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrQrCode.Dpi = 254.0!
        Me.XrQrCode.LocationFloat = New DevExpress.Utils.PointFloat(318.6668!, 25.00001!)
        Me.XrQrCode.Module = 5.0!
        Me.XrQrCode.Name = "XrQrCode"
        Me.XrQrCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrQrCode.ShowText = False
        Me.XrQrCode.SizeF = New System.Drawing.SizeF(228.7289!, 289.4789!)
        Me.XrQrCode.StylePriority.UseBorders = False
        Me.XrQrCode.Symbology = QrCodeGenerator1
        '
        'XrBarCode
        '
        Me.XrBarCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode.AutoModule = True
        Me.XrBarCode.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrBarCode.Dpi = 254.0!
        Me.XrBarCode.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrBarCode.LocationFloat = New DevExpress.Utils.PointFloat(510.6456!, 129.1656!)
        Me.XrBarCode.Module = 4.0!
        Me.XrBarCode.Name = "XrBarCode"
        Me.XrBarCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode.ShowText = False
        Me.XrBarCode.SizeF = New System.Drawing.SizeF(363.5003!, 109.8551!)
        Me.XrBarCode.StylePriority.UseBorders = False
        Me.XrBarCode.StylePriority.UseFont = False
        Me.XrBarCode.StylePriority.UseTextAlignment = False
        Me.XrBarCode.Symbology = Code128Generator1
        Me.XrBarCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelNumSerie
        '
        Me.XrLabelNumSerie.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelNumSerie.Dpi = 254.0!
        Me.XrLabelNumSerie.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabelNumSerie.LocationFloat = New DevExpress.Utils.PointFloat(510.6456!, 239.0207!)
        Me.XrLabelNumSerie.Multiline = True
        Me.XrLabelNumSerie.Name = "XrLabelNumSerie"
        Me.XrLabelNumSerie.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelNumSerie.SizeF = New System.Drawing.SizeF(363.5003!, 58.91565!)
        Me.XrLabelNumSerie.StylePriority.UseBorders = False
        Me.XrLabelNumSerie.StylePriority.UseFont = False
        Me.XrLabelNumSerie.StylePriority.UseTextAlignment = False
        Me.XrLabelNumSerie.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPictureBox1.Dpi = 254.0!
        Me.XrPictureBox1.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(Global.Code_barre.My.Resources.Resources.LogoAbatNB, True)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(59.521!, 56.75005!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(238.1044!, 197.1676!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox1.StylePriority.UseBorders = False
        '
        'XrPictureBoxOnsa
        '
        Me.XrPictureBoxOnsa.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPictureBoxOnsa.Dpi = 254.0!
        Me.XrPictureBoxOnsa.ImageUrl = "C:\Users\hp\Desktop\agra.png"
        Me.XrPictureBoxOnsa.LocationFloat = New DevExpress.Utils.PointFloat(633.9784!, 0!)
        Me.XrPictureBoxOnsa.Name = "XrPictureBoxOnsa"
        Me.XrPictureBoxOnsa.SizeF = New System.Drawing.SizeF(158.1467!, 129.1656!)
        Me.XrPictureBoxOnsa.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBoxOnsa.StylePriority.UseBorders = False
        '
        'LabelReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Dpi = 254.0!
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        Me.PageHeight = 350
        Me.PageWidth = 960
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.SnapGridSize = 25.0!
        Me.Version = "20.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrDataMatrix As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrQrCode As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrLabelNumSerie As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrPictureBoxOnsa As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrBarCode As DevExpress.XtraReports.UI.XRBarCode
End Class
