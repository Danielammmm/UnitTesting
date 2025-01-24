<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoWebFormsApiDb.Default" Async="true"%>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Demo API y Base de Datos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Datos desde la API</h3>
<asp:TextBox ID="txtApiId" runat="server" Placeholder="Ingrese ID para API"></asp:TextBox>
<asp:Button ID="btnApiFetch" runat="server" Text="Obtener de API" OnClick="btnApiFetch_Click" />
<br />
<asp:Label ID="lblApiResult" runat="server" ForeColor="Blue" />
<br />
<asp:Panel ID="pnlApiData" runat="server" Visible="false">
    <h4>Datos obtenidos:</h4>
    <p><strong>ID:</strong> <asp:Label ID="lblApiId" runat="server" /></p>
    <p><strong>Nombre:</strong> <asp:Label ID="lblApiName" runat="server" /></p>
    <p><strong>Email:</strong> <asp:Label ID="lblApiEmail" runat="server" /></p>
</asp:Panel>


            <h3>Datos desde la Base de Datos</h3>
            <asp:GridView ID="gvDatabaseData" runat="server" AutoGenerateColumns="true"></asp:GridView>

        </div>
    </form>
</body>
</html>
