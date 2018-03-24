Imports Zds
Imports Zds.Fraction

Module Main

    Sub Main()
        Do
            Console.WriteLine("Enter Squence:")
            Dim RAW As String = Console.ReadLine
            Dim RAWs() As String = Split(RAW, ",")
            Dim Series(RAWs.Length - 1) As Fraction
            For i = 0 To RAWs.Length - 1
                Series(i) = Fraction.Parse(RAWs(i))
            Next
            Dim DegreeOfEquation As ULong = Series.Length - 1
            Dim Equation(DegreeOfEquation) As Fraction
            For i = Equation.Length To 1 Step -1
                Dim Value As Fraction = Difference(Series, 1, i - 1)
                For j = 1 To Equation.Length - i
                    Dim C = CCOfX(Equation.Length - j, 1, i - 1)
                    Value -= Equation(Equation.Length - j) * C
                Next
                Dim C2 = CCOfX(i - 1, 1, i - 1)
                Equation(i - 1) = Value / C2
            Next
            Dim p As String = "f(x) = "
            For i = Equation.Length - 1 To 0 Step -1
                If Equation(i).Numerator = 0 Then Continue For
                If Not Equation(i).IsNegative Then
                    If p.Length <> 7 Then p += "+"
                End If
                Dim IsUnit As Boolean = False
                If Equation(i).Denominator = 1 Then
                    If Equation(i).Numerator = 1 Then
                        IsUnit = True
                    Else
                        p += Equation(i).Numerator.ToString
                    End If
                Else
                    p += Equation(i).ToString
                End If
                If i <> 0 Then If IsUnit Then p += "x" Else p += "*x"
                If i <> 0 And i <> 1 Then p += "^" + i.ToString
            Next
            Console.WriteLine(p)
        Loop
    End Sub
    Public Function CCOfX(PowerOfX As Long, Term As Long, Level As ULong) As Long
        If Level = 0 Then
            Return Term ^ PowerOfX
        Else
            Return CCOfX(PowerOfX, Term + 1, Level - 1) - CCOfX(PowerOfX, Term, Level - 1)
        End If
    End Function
    Public Function Difference(Series() As Fraction, Term As Long, Level As ULong) As Fraction
        If Level = 0 Then
            Return Series(Term - 1)
        Else
            Return Difference(Series, Term + 1, Level - 1) - Difference(Series, Term, Level - 1)
        End If
    End Function
End Module
