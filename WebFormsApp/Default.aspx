<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Formulario de Validación</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtName">Nombre:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <label for="txtAge">Edad:</label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Validar" OnClick="btnSubmit_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
