Public Class CashierReportUpdate
  Dim cmd As commands

  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub


  Public Sub cr(crbatch As Integer, crShiftno As Integer, CrCashierid As Integer)
    Dim Shiftno As Integer = crShiftno
    Dim Userid As Integer = CrCashierid
    Dim batch As Integer = crbatch
    Dim PO = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =2)")
    Dim Cash = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")

    Dim discount = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].Discount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "') ")

    Dim CashDrop = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=0 ")

    Dim colect = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=3 ")
    Dim Payout = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "' and type=1 ")

    Dim Total = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  ")


    Dim tax = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].SalesTax),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")



    cmd.Update("UPDATE [CashierReport] SET [Collection] ='" & 0 & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [PO]='" & PO & "' where [BatchNumber]='" & batch & "' ")
    cmd.Update("UPDATE [CashierReport] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
    Dim CREDITCARD = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =5)")










    cmd.Update("UPDATE [CashierReport] SET [Shift]='" & Shiftno & "' where [BatchNumber]='" & batch & "'")

    cmd.Update("UPDATE [CashierReport] SET [OpeningAmount]='" & CREDITCARD & "' where [BatchNumber]='" & batch & "'")


    cmd.Update("UPDATE [CashierReport] SET [Payout]='" & Payout & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [CashDrop]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [CashierID]='" & Userid & "' where [BatchNumber]='" & batch & "'")

    cmd.Update("UPDATE [CashierReport] SET [STATUS]=0 where [BatchNumber]='" & batch & "'")

    cmd.Update("UPDATE [Batch] SET [Dropped]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [PaidOut]='" & Payout & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
    'cmd.Update("UPDATE [Batch] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [PaidOnAccount]='" & PO & "' where [BatchNumber]='" & batch & "' ")
    cmd.Update("UPDATE [Batch] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [TAX]='" & tax & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [CashierID]='" & Userid & "' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [Batch] SET [Status]='0' where [BatchNumber]='" & batch & "'")
    cmd.Update("UPDATE [CashierReport] SET [Status]='0' where [BatchNumber]='" & batch & "'")




  End Sub

End Class
