' Name:         Discount Project
' Purpose:      Display the discount amount and rates from 10% to 40%
' Programmer:   Andrew Kuykendall on 10/11/2017

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' fill list box with rates and select first rate

        For dblRates As Double = 10 To 40 Step 5
            lstRates.Items.Add(dblRates.ToString("N1"))
        Next

        lstRates.SelectedItem = "10.00"

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        ' display the monthly mortgage payment
        Dim dblOriginalPrice As Double
        Dim dblRate As Double
        Dim dblDiscountPrice As Double
        Dim dblDiscountTotal As Double

        Double.TryParse(txtPrice.Text, dblOriginalPrice)
        Double.TryParse(lstRates.SelectedItem.ToString, dblRate)

        dblRate /= 100

        lblDiscountPrice.Text = String.Empty

        'Calculate discount
        dblDiscountTotal = dblOriginalPrice * dblRate
        dblDiscountPrice = dblOriginalPrice - dblDiscountTotal

        'Display the Discount Information
        lblDiscountPrice.Text = lblDiscountPrice.Text & " You saved : " & dblDiscountTotal.ToString("c2") & ControlChars.NewLine &
            " Your Total is: " & dblDiscountPrice.ToString("C2")

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtPrincipal_Enter(sender As Object, e As EventArgs) Handles txtPrice.Enter
        txtPrice.SelectAll()
    End Sub

    Private Sub ClearPayment(sender As Object, e As EventArgs) Handles txtPrice.TextChanged, lstRates.SelectedValueChanged
        lblDiscountPrice.Text = String.Empty
    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        ' accept only numbers and the Backspace key

        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
                e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub


End Class
