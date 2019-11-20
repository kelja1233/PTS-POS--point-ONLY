Imports System.Xml
Imports System.Data
Public Class Pricechange
    Dim cmd As New commands
    Private Sub Pricechange_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString





    rec()

    End Sub
    Public Sub rec()



        cmd.SelectRecord("SELECT [ItemLookupCode],[Description]  ,[Price] as 'Current Price',0.0 as'New Price'  FROM [Item] where [CategoryID]=1 order by code ", "item", Me.DataGridView1)
        Try
            Dim column0 As DataGridViewColumn = DataGridView1.Columns(0)
            Dim column1 As DataGridViewColumn = DataGridView1.Columns(1)
            Dim column2 As DataGridViewColumn = DataGridView1.Columns(2)
            Dim column3 As DataGridViewColumn = DataGridView1.Columns(3)

            column0.ReadOnly = True
            column1.ReadOnly = True
            column2.ReadOnly = True
            column3.ReadOnly = False


            DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
            DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
        Catch ex As Exception

        End Try



    End Sub
    Public Sub INSERTXML()
        Dim P1N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=1  "))
        Dim P1N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=2  "))
        Dim P1N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=3  "))
        Dim P1N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=4  "))
        Dim P1N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=5  "))
        Dim P1N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=1 and [nozzle]=6  "))



        Dim P2N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=1  "))
        Dim P2N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=2  "))
        Dim P2N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=3  "))
        Dim P2N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=4  "))
        Dim P2N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=5  "))
        Dim P2N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=2 and [nozzle]=6  "))



        Dim P3N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=1  "))
        Dim P3N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=2  "))
        Dim P3N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=3  "))
        Dim P3N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=4  "))
        Dim P3N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=5  "))
        Dim P3N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=3 and [nozzle]=6  "))



        Dim P4N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=1  "))
        Dim P4N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=2  "))
        Dim P4N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=3  "))
        Dim P4N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=4  "))
        Dim P4N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=5  "))
        Dim P4N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=4 and [nozzle]=6  "))



        Dim P5N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=1  "))
        Dim P5N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=2  "))
        Dim P5N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=3  "))
        Dim P5N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=4  "))
        Dim P5N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=5  "))
        Dim P5N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=5 and [nozzle]=6  "))



        Dim P6N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=1  "))
        Dim P6N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=2  "))
        Dim P6N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=3  "))
        Dim P6N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=4  "))
        Dim P6N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=5  "))
        Dim P6N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=6 and [nozzle]=6  "))



        Dim P7N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=1  "))
        Dim P7N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=2  "))
        Dim P7N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=3  "))
        Dim P7N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=4  "))
        Dim P7N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=5  "))
        Dim P7N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=7 and [nozzle]=6  "))



        Dim P8N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=1  "))
        Dim P8N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=2  "))
        Dim P8N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=3  "))
        Dim P8N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=4  "))
        Dim P8N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=5  "))
        Dim P8N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=8 and [nozzle]=6  "))



        Dim P9N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=1  "))
        Dim P9N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=2  "))
        Dim P9N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=3  "))
        Dim P9N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=4  "))
        Dim P9N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=5  "))
        Dim P9N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=9 and [nozzle]=6  "))



        Dim P10N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=1  "))
        Dim P10N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=2  "))
        Dim P10N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=3  "))
        Dim P10N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=4  "))
        Dim P10N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=5  "))
        Dim P10N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=10 and [nozzle]=6  "))



        Dim P11N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=1  "))
        Dim P11N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=2  "))
        Dim P11N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=3  "))
        Dim P11N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=4  "))
        Dim P11N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=5  "))
        Dim P11N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=11 and [nozzle]=6  "))



        Dim P12N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=1  "))
        Dim P12N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=2  "))
        Dim P12N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=3  "))
        Dim P12N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=4  "))
        Dim P12N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=5  "))
        Dim P12N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=12 and [nozzle]=6  "))



        Dim P13N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=1  "))
        Dim P13N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=2  "))
        Dim P13N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=3  "))
        Dim P13N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=4  "))
        Dim P13N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=5  "))
        Dim P13N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=13 and [nozzle]=6  "))



        Dim P14N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=1  "))
        Dim P14N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=2  "))
        Dim P14N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=3  "))
        Dim P14N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=4  "))
        Dim P14N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=5  "))
        Dim P14N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=14 and [nozzle]=6  "))



        Dim P15N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=1  "))
        Dim P15N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=2  "))
        Dim P15N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=3  "))
        Dim P15N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=4  "))
        Dim P15N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=5  "))
        Dim P15N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=15 and [nozzle]=6  "))



        Dim P16N1 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=1  "))
        Dim P16N2 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=2  "))
        Dim P16N3 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=3  "))
        Dim P16N4 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=4  "))
        Dim P16N5 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=5  "))
        Dim P16N6 As Double = Convert.ToInt32(cmd.getSpecificRecord("SELECT 0+COALESCE(Max([PumpIDEdit]),0)* 100 FROM [OP_PumpSettings] where [pump]=16 and [nozzle]=6  "))





        Dim NEWLINER As String = "<Configuration>" _
                    & vbNewLine & "    <FuelPointConfiguration>" _
                    & vbNewLine & "      <_fuelPointControl1 FuelPointID=" & Chr(34) & "1" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P1N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P1N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P1N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P1N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P1N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P1N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl2 FuelPointID=" & Chr(34) & "2" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P2N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P2N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P2N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P2N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P2N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P2N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl3 FuelPointID=" & Chr(34) & "3" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P3N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P3N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P3N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P3N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P3N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P3N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl4 FuelPointID=" & Chr(34) & "4" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P4N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P4N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P4N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P4N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P4N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P4N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl5 FuelPointID=" & Chr(34) & "5" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P5N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P5N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P5N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P5N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P5N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P5N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl6 FuelPointID=" & Chr(34) & "6" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P6N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P6N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P6N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P6N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P6N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P6N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl7 FuelPointID=" & Chr(34) & "7" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P7N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P7N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P7N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P7N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P7N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P7N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl8 FuelPointID=" & Chr(34) & "8" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P8N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P8N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P8N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P8N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P8N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P8N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl9 FuelPointID=" & Chr(34) & "9" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P9N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P9N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P9N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P9N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P9N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P9N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl10 FuelPointID=" & Chr(34) & "10" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P10N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P10N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P10N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P10N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P10N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P10N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl11 FuelPointID=" & Chr(34) & "11" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P11N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P11N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P11N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P11N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P11N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P11N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl12 FuelPointID=" & Chr(34) & "12" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P12N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P12N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P12N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P12N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P12N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P12N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl13 FuelPointID=" & Chr(34) & "13" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P13N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P13N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P13N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P13N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P13N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P13N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl14 FuelPointID=" & Chr(34) & "14" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P14N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P14N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P14N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P14N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P14N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P14N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl15 FuelPointID=" & Chr(34) & "15" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P15N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P15N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P15N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P15N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P15N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P15N6 & Chr(34) & "/> " _
                    & vbNewLine & "      <_fuelPointControl16 FuelPointID=" & Chr(34) & "16" & Chr(34) & " FuelPointNozzlesCounts=" & Chr(34) & "6" & Chr(34) & " nozzle_price_1=" & Chr(34) & P16N1 & Chr(34) & " nozzle_price_2=" & Chr(34) & P16N2 & Chr(34) & " nozzle_price_3=" & Chr(34) & P16N3 & Chr(34) & " nozzle_price_4=" & Chr(34) & P16N4 & Chr(34) & " nozzle_price_5=" & Chr(34) & P16N5 & Chr(34) & " nozzle_price_6=" & Chr(34) & P16N6 & Chr(34) & "/> " _
                    & vbNewLine & "   </FuelPointConfiguration>" _
                    & vbNewLine & "  <AtgConfiguration>" _
                    & vbNewLine & "       <atgControl3 AtgID=" & Chr(34) & "1" & Chr(34) & " MaxHeight=" & Chr(34) & "1000" & Chr(34) & "/>" _
                    & vbNewLine & "        <atgControl2 AtgID=" & Chr(34) & "1" & Chr(34) & " MaxHeight=" & Chr(34) & "1000" & Chr(34) & "/>" _
                    & vbNewLine & "        <atgControl1 AtgID=" & Chr(34) & "1" & Chr(34) & " MaxHeight=" & Chr(34) & "1000" & Chr(34) & "/>" _
                    & vbNewLine & "   </AtgConfiguration>" _
                    & vbNewLine & "</Configuration>"

    Dim FILE_NAME As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Path_XML", "Value", Nothing).ToString

    If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(NEWLINER)
            objWriter.Close()

        Else

            MessageBox.Show("File Does Not Exist")

        End If
    End Sub


    Private Sub btsave_Click(sender As Object, e As EventArgs) Handles btsave.Click
        Dim count = DataGridView1.RowCount
        Dim a = 0


        'do loop execution 


        Do

            Dim a1 = DataGridView1.Item(0, a).Value
            Dim a2 = DataGridView1.Item(1, a).Value
            Dim a3 As Double = DataGridView1.Item(2, a).Value
            Dim a4 As Double = DataGridView1.Item(3, a).Value






            cmd.SelectRecord("SELECT [Pump] ,[Nozzle]   FROM [OP_PumpSettings] where [ItemLookupCode]='" & a1 & "' ", "OP_PumpSettings", Me.DataGridView2)

            If a4 = 0 Then

            Else
                Dim batch As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")
                Dim c1 As Double = cmd.getSpecificRecord("SELECT [ID] FROM [Item] where [ItemLookupCode]='" & a1 & "' ")
                cmd.AddRecord("INSERT INTO [PriceChangeHistory] ([ITEMID],[PPRICE],[NPRICE],[BATCHNUMBER]) VALUES ('" & c1 & "','" & a3 & "','" & a4 & "','" & batch & "')")

            End If



            Dim count1 = DataGridView2.RowCount
            Dim b = 0


            'do loop execution 


            If count1 = 0 Then
            Else




                Do






                    Dim b1 As String = DataGridView2.Item(0, b).Value
                    Dim b2 As String = DataGridView2.Item(1, b).Value


                    '  cmd.AddRecord("INSERT INTO [OP_ShiftReading] (batch,[DayNumber],[ShiftNumber],[Pump],[Nozzle],[StartReading],[StartAReading]) VALUES ('" & batch + 1 & "','" & Day & "','" & Shiftno & "','" & a1 & "','" & a2 & "','" & a6 & "','" & a7 & "')")
                    Dim counter As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(PriceAdjustment),0)  FROM OP_PumpSettings where [Pump]='" & b1 & "' and [Nozzle]='" & b2 & "'  ")
                    a4 = a4 + counter

                    If a4 = 0 Then

                    ElseIf a4 = 0.0 Then


                    Else


                        cmd.Update("UPDATE [OP_PumpSettings] SET    [PumpIDEdit]='" & a4 & "'       where  [Pump]='" & b1 & "' and [Nozzle]='" & b2 & "'")

                        a4 = a4 - counter
                    End If



                    b = b + 1


                Loop While (b < count1)
            End If


            If a4 = 0 Then

            ElseIf a4 = 0.0 Then


            Else




                cmd.Update("UPDATE [Item] SET    [Price]='" & a4 & "'       where  [ItemLookupCode]='" & a1 & "'")

            End If



            a = a + 1


        Loop While (a < count)



    INSERTXML()



    cmd.Update("UPDATE OP_PumpSettings SET [Status]=2 ")

        PricechangeSet.Timer1.Interval = 1000
        PricechangeSet.Timer1.Start()
        PricechangeSet.ShowDialog()

    MessageBox.Show("Price Change Successful Updated. Pls Re-Open Program....")

    Me.Close()




  End Sub

    Private Sub btref_Click(sender As Object, e As EventArgs) Handles btref.Click
        rec()
        Timer1.Start()
    End Sub


    'Private Sub btdelete_Click(sender As Object, e As EventArgs) Handles btdelete.Click
    '    'BypassPC.Close()
    '    'BypassPC.Show()
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Adjustment.Close()
        Adjustment.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            DataGridView1.Columns(2).DefaultCellStyle.Format = "N2"
            DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
        Catch ex As Exception
            Timer1.Stop()

        End Try

    End Sub



End Class

