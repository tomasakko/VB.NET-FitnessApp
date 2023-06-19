<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sources.aspx.vb" Inherits="TomaFitnessApp.Sources" %>
<%@ Register Src="~/components/navbar/navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../components/navbar/navbarStyle.css" />
    <link rel="stylesheet" href="sourcesStyles.css" />
</head>
<body>
    <uc:Navbar runat="server" />

    <div class="cardGroup">
         <asp:Repeater runat="server" ID="sourcesRepeater">
            <ItemTemplate>
                <div class="container">
                    <div class="sourceCard">
                    <div class="sourceLogo">
                        <img src='<%# Eval("logo") %>' alt='<%# Eval("name") %> logo' />
                    </div>
                </div>
                <div class="sourceDetails">
                        <h3 class="cardTitle">
                            <a class="sourceLink" href='<%# Eval("link") %>' target="_blank">
                                <%# Eval("name") %>
                            </a>
                        </h3>
                        <p><%# Eval("description") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</body>
</html>
