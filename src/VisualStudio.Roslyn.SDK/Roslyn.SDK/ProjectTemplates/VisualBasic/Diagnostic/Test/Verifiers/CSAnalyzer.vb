﻿Imports System.Threading
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.CSharp.Testing
Imports Microsoft.CodeAnalysis.Diagnostics
Imports Microsoft.CodeAnalysis.Testing

Partial Public NotInheritable Class CSharpAnalyzerVerifier(Of TAnalyzer As {DiagnosticAnalyzer, New})

    Private Sub New()
        Throw New NotSupportedException()
    End Sub

    ''' <inheritdoc cref="AnalyzerVerifier(Of TAnalyzer, TTest, TVerifier).Diagnostic()"/>
    Public Shared Function Diagnostic() As DiagnosticResult
        Return CSharpAnalyzerVerifier(Of TAnalyzer, DefaultVerifier).Diagnostic()
    End Function

    ''' <inheritdoc cref="AnalyzerVerifier(Of TAnalyzer, TTest, TVerifier).Diagnostic(String)"/>
    Public Shared Function Diagnostic(diagnosticId As String) As DiagnosticResult
        Return CSharpAnalyzerVerifier(Of TAnalyzer, DefaultVerifier).Diagnostic(diagnosticId)
    End Function

    ''' <inheritdoc cref="AnalyzerVerifier(Of TAnalyzer, TTest, TVerifier).Diagnostic(DiagnosticDescriptor)"/>
    Public Shared Function Diagnostic(descriptor As DiagnosticDescriptor) As DiagnosticResult
        Return CSharpAnalyzerVerifier(Of TAnalyzer, DefaultVerifier).Diagnostic(descriptor)
    End Function

    ''' <inheritdoc cref="AnalyzerVerifier(Of TAnalyzer, TTest, TVerifier).VerifyAnalyzerAsync(String, DiagnosticResult())"/>
    Public Shared Async Function VerifyAnalyzerAsync(source As String, ParamArray expected As DiagnosticResult()) As Task
        Dim test As New Test With
        {
        .TestCode = source
        }

        test.ExpectedDiagnostics.AddRange(expected)
        Await test.RunAsync(CancellationToken.None)
    End Function

End Class
