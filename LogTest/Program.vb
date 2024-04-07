
Module Program
    Sub Main(args As String())
        ' Configuraci�n de Serilog
        dinaup.logs.Initialize("LogTest", "0.1", logFilePath:="log/log.txt", mmWebHook:="matte", elasticUrl:="http://localhost:9200", elasticPrefix:="")


        ' Generar logs de prueba
        dinaup.logs.Information("Iniciando pruebas de Serilog.")

        ' Llamadas a funciones de prueba
        GenerarLogsTexto()
        GenerarLogsNumeros()
        GenerarLogsExcepciones()


        Using dinaup.logs.IniContext("sync")
            dinaup.logs.Log.Information("Log de texto n�mero {NumeroLog}", 2)
        End Using


        dinaup.logs.Log.Information("Pruebas de Serilog finalizadas.")
        dinaup.logs.CloseAndFlush()
        Console.ReadKey()

    End Sub

    ' Funci�n para generar logs de texto
    Sub GenerarLogsTexto()
        For i As Integer = 1 To 1000
            dinaup.logs.Log.Information("Log de texto n�mero {NumeroLog}", i)
        Next
    End Sub

    ' Funci�n para generar logs con n�meros
    Sub GenerarLogsNumeros()
        Dim rand As New Random()
        For i As Integer = 1 To 1000
            dinaup.logs.Log.Debug("Log con n�mero aleatorio {NumeroAleatorio}", rand.Next())
        Next
    End Sub

    ' Funci�n para simular y registrar excepciones
    Sub GenerarLogsExcepciones()
        For i As Integer = 1 To 100
            Try
                Throw New InvalidOperationException("Excepci�n de prueba n�mero " & i.ToString())
            Catch ex As Exception
                dinaup.logs.Log.Error(ex, "Se captur� una excepci�n")
            End Try
        Next
    End Sub

End Module
    