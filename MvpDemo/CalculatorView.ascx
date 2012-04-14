<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalculatorView.ascx.cs" Inherits="MvpDemo.CalculatorView" %>
<asp:TextBox runat="server" ID="tbInput"></asp:TextBox>
<asp:Button runat="server" ID="button" Text="Calculate"/>
<br/>
<h3>Result is: <asp:Label runat="server" ID="lResult" Text="<%# Model.Result %>"></asp:Label></h3>
