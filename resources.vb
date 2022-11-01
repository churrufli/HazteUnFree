Imports Microsoft.VisualBasic

Public Class Class1
    Sub sacapalabra()
        Dim MyWords As String
        MyWords = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\" & vars.MyWordsFileName)
        Dim w = "https://www.palabrasaleatorias.com/?fs=10&fs2=0&Submit=Nueva+palabra"
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(ReadWeb(Trim(w)))
        Dim div = doc.DocumentNode.SelectNodes("//div[@style='font-size:3em; color:#6200C5;']")
        Dim counter = 0
        For Each word In div
            Dim MyWord = LCase(word.InnerText.ToString)
            If MyWords.Contains(MyWord & "") = False Then
                MyWords = MyWords & MyWord
                Dim FILE_NAME As String = vars.MyWordsFileName
                Dim objWriter As New System.IO.StreamWriter(IO.Directory.GetCurrentDirectory & "\" & vars.MyWordsFileName)
                objWriter.Write(MyWords)
                objWriter.Close()
                Fn.WriteLog(MyWord)
            End If
        Next word

    End Sub
End Class
