Public Class Contable





    Public Function NroEnLetras(ByVal curNumero As Double, Optional ByVal iMnd As Integer = 1, Optional ByVal blnO_Final As Boolean = True) As String

        Dim dblCentavos As Double
        Dim lngContDec As Long
        Dim lngContCent As Long
        Dim lngContMil As Long
        Dim lngContMillon As Long
        Dim strNumLetras As String
        Dim strNumero() As String

        Dim strDecenas() As String
        Dim strCentenas() As String

        Dim blnNegativo As Boolean
        Dim blnPlural As Boolean
        Dim strMoneda As String




        If iMnd = 2 Then
            strMoneda = " DOLARES NORTEAMERICANOS"
        Else
            strMoneda = " NUEVOS SOLES"
        End If

        If Int(curNumero) = 0.0# Then
            strNumLetras = "CERO"
        End If



        strNumero = New String() {vbNullString, "UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", _
                       "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", _
                       "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE", "VEINTE"}

        strDecenas = New String() {vbNullString, vbNullString, "VEINTI", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", _
                        "SETENTA", "OCHENTA", "NOVENTA", "CIEN"}

        strCentenas = New String() {vbNullString, "CIENTO", "DOSCIENTOS", "TRESCIENTOS", _
                         "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", _
                         "OCHOCIENTOS", "NOVECIENTOS"}

        If curNumero < 0.0# Then
            blnNegativo = True
            curNumero = Math.Abs(curNumero)
        End If

        If Int(curNumero) <> curNumero Then
            dblCentavos = Math.Abs(curNumero - Int(curNumero))
            curNumero = Int(curNumero)
        End If

        Do While curNumero >= 1000000.0#
            lngContMillon = lngContMillon + 1
            curNumero = curNumero - 1000000.0#
        Loop

        Do While curNumero >= 1000.0#
            lngContMil = lngContMil + 1
            curNumero = curNumero - 1000.0#
        Loop

        Do While curNumero >= 100.0#
            lngContCent = lngContCent + 1
            curNumero = curNumero - 100.0#
        Loop

        If Not (curNumero > 10.0# And curNumero <= 20.0#) Then
            Do While curNumero >= 10.0#
                lngContDec = lngContDec + 1
                curNumero = curNumero - 10.0#
            Loop
        End If

        If lngContMillon > 0 Then
            If lngContMillon > 1 Then   'si el número es >1000000 usa recursividad
                strNumLetras = NroEnLetras(lngContMillon, iMnd, False)
                If Not blnPlural Then blnPlural = (lngContMillon > 1)
                lngContMillon = 0
            End If
            strNumLetras = Trim(strNumLetras) & strNumero(lngContMillon) & "MILLON " & IIf(blnPlural, "ES ", " ")
        End If

        If lngContMil > 0 Then 'PBF
            If lngContMil > 1 Then   'si el número es >100000 usa recursividad
                strNumLetras = strNumLetras & NroEnLetras(lngContMil, iMnd, False)
                lngContMil = 0
                strNumLetras = Trim(strNumLetras) & strNumero(lngContMil) & "MIL "
            Else
                strNumLetras = Trim(strNumLetras) & " MIL "
            End If
        End If

        If lngContCent > 0 Then
            If lngContCent = 1 And lngContDec = 0 And curNumero = 0.0# Then
                strNumLetras = strNumLetras & " CIEN "
            Else
                strNumLetras = strNumLetras & strCentenas(lngContCent) & "  "
            End If
        End If

        If lngContDec >= 1 Then
            If lngContDec = 1 Then
                strNumLetras = strNumLetras & strNumero(10)
            Else
                strNumLetras = strNumLetras & strDecenas(lngContDec)
            End If

            If lngContDec >= 3 And curNumero > 0.0# Then
                strNumLetras = strNumLetras & " Y "
            End If
        Else
            If curNumero >= 0.0# And curNumero <= 20.0# Then
                strNumLetras = strNumLetras & strNumero(curNumero)
                If curNumero = 1.0# And blnO_Final Then
                    strNumLetras = strNumLetras & "O"
                End If
                If dblCentavos > 0.0# Then
                    strNumLetras = Trim(strNumLetras) + " CON " & Format$(CInt(dblCentavos * 100.0#), "00") & "/100 " + strMoneda

                Else
                    If blnO_Final Then strNumLetras = Trim(strNumLetras) + " CON 00/100 " + strMoneda

                End If
                NroEnLetras = strNumLetras
                Exit Function
            End If
        End If

        If curNumero > 0.0# Then
            strNumLetras = strNumLetras & strNumero(curNumero)
            If curNumero = 1.0# And blnO_Final Then
                strNumLetras = strNumLetras & "O"
            End If
        End If

        If dblCentavos > 0.0# Then
            strNumLetras = strNumLetras & " CON " + Format$(CInt(dblCentavos * 100.0#), "00") & "/100 " + strMoneda
        Else
            If blnO_Final Then strNumLetras = Trim(strNumLetras) & " CON 00/100" + strMoneda

        End If

        NroEnLetras = IIf(blnNegativo, "(" & strNumLetras & ")", strNumLetras)

    End Function

End Class



