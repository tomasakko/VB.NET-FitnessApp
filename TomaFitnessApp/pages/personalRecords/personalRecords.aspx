<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="personalRecords.aspx.vb" Inherits="TomaFitnessApp.personalRecords" %>
<%@ Register Src="~/components/navbar/navbar.ascx" TagPrefix="uc" TagName="Navbar" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../components/navbar/navbarStyle.css" />
    <link rel="stylesheet" href="personalRecordsStyles.css" />
</head>

<body>
    <uc:Navbar runat="server" />
    <div class="cardGroup">
        <asp:Repeater runat="server" ID="muscleGroupsRepeater">
            <ItemTemplate>
                <div class="muscleCard" onclick="toggleExercises(this)">
                    <div class="container">
                        <img class="imgIcon" src="<%# Eval("img") %>"/>
                        <h3 class="cardTitle"><%# Eval("name") %> records</h3>
                        <div class="exerciseContainer">
                            <asp:Repeater ID="exercisesRepeater" runat="server" DataSource='<%# Eval("exercises") %>'>
                                <ItemTemplate>
                                    <p><%# Eval("name") %></p>
                                    <input type='text' />
                                </ItemTemplate>
                            </asp:Repeater>
                            <br /><br />
                            <button class="saveProgress">Save progress</button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    
</body>
</html>
