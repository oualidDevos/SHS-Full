'Imports Microsoft.Office.Interop.Excel


'Module XLS

'    'Private oXL As Microsoft.Office.Interop.Excel.Application
'    'Private oWB As Microsoft.Office.Interop.Excel._Workbook
'    ' Private oSheet As Microsoft.Office.Interop.Excel._Worksheet
'    Private oRng As Microsoft.Office.Interop.Excel.Range
'    Private M As Object = System.Reflection.Missing.Value
'    Public dst As New DataSet


'    Public table As String
'    Private ind As Integer = -1

'    Public op As New ColorDialog
'    Public p As Color




'    Public Sub creer(ByVal tb As String, ByVal nom As String)
'        'Start Excel and get Application object.
'        oXL = New Microsoft.Office.Interop.Excel.Application()
'        'oXL.Visible = True

'        'Get a new workbook.
'        oWB = DirectCast((oXL.Workbooks.Add(System.Reflection.Missing.Value)), Microsoft.Office.Interop.Excel._Workbook)

'        table = tb


'        Try

'            Dim oSheet As Microsoft.Office.Interop.Excel._Worksheet

'            oSheet = DirectCast(oWB.ActiveSheet, Microsoft.Office.Interop.Excel._Worksheet)
'            oSheet.Name = nom

'            oWB.Sheets.Add(M, oSheet)
'            ind += 1
'            For i As Integer = 1 To dst.Tables(table).Columns.Count
'                oSheet.Cells(1, i) = dst.Tables(table).Columns(i - 1).ColumnName
'                oSheet.Cells(1, i).Font.Bold = True
'                oSheet.Cells(1, i).Font.size = 14

'                oSheet.Cells(1, i).Interior.ColorIndex = XlColorIndex.xlColorIndexAutomatic
'                oSheet.Cells(1, i).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                oSheet.Cells(1, i).EntireColumn.AutoFit()
'            Next
'            For i As Integer = 0 To dst.Tables(table).Rows.Count - 1
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1

'                    ' MsgBox(dst.Tables(table).Rows(i).Item(16))
'                    If dst.Tables(table).Rows(i).Item(16) = "" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1

'                    ' MsgBox(dst.Tables(table).Rows(i).Item(16))
'                    If dst.Tables(table).Rows(i).Item(16) = "D-Brut" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 5
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1

'                    ' MsgBox(dst.Tables(table).Rows(i).Item(16))
'                    If dst.Tables(table).Rows(i).Item(16) = "D-Ok" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 5
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    ' MsgBox(dst.Tables(table).Rows(i).Item(16))
'                    If dst.Tables(table).Rows(i).Item(16) = "Ok" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 6 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    If dst.Tables(table).Rows(i).Item(16) = "NRP" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    If dst.Tables(table).Rows(i).Item(16) = "REP" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    If dst.Tables(table).Rows(i).Item(16) = "Rappeler à" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 8 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    If dst.Tables(table).Rows(i).Item(16) = "Autres" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 1
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next
'                For j As Integer = 0 To dst.Tables(table).Columns.Count - 1
'                    If dst.Tables(table).Rows(i).Item(16) = "Annulé" Then
'                        oSheet.Cells(i + 2, j + 1) = dst.Tables(table).Rows(i).Item(j).ToString
'                        oSheet.Cells(i + 2, j + 1).font.colorIndex = 3
'                        oSheet.Cells(i + 2, j + 1).Interior.ColorIndex = 2 ' XlColorIndex.xlColorIndexAutomatic
'                        oSheet.Cells(i + 2, j + 1).BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, M)
'                        oSheet.Cells(i + 2, j + 1).EntireColumn.AutoFit()
'                    End If
'                Next


'            Next
'        Catch ex As Exception
'            'msgbox(sender.Name & "/" &e.ToString & vbcrlf & ex.Message)
'        End Try
'    End Sub





'    Public Sub SaveAs(ByVal sNameFichier As String)
'        Try

'            For Each s As Microsoft.Office.Interop.Excel._Worksheet In oWB.Sheets
'                If s.Index > ind Then
'                    s.Delete()
'                End If
'            Next
'            oWB.SaveAs(sNameFichier, M, M, M, M, M, _
'             Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, M, M, M, M, M)
'        Catch e As Exception
'            '  MessageBox.Show(e.Message)
'        End Try
'    End Sub


'End Module
