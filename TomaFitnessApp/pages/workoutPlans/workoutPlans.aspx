<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="workoutPlans.aspx.vb" Inherits="TomaFitnessApp.workoutPlans" %>
<%@ Register Src="~/components/navbar/navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Workout Plans</title>
    <link rel="stylesheet" href="../../components/navbar/navbarStyle.css" />
    <link rel="stylesheet" href="workoutPlansStyle.css" />
</head>

<body>
    <uc:Navbar runat="server" />

    <div class="cardGroup">
        <asp:Repeater runat="server" ID="workoutPlansRepeater">
            <ItemTemplate>
                <div class="workoutCard" onclick='displayWorkoutPlans("<%# Eval("workoutPlansHtml") %>", "<%# Eval("name") %>")'>
                    <div class="container">
                        <img class="imgIcon" src="<%# Eval("img") %>" />
                        <h3 class="cardTitle"><%# Eval("name") %></h3>
                        <h3 class="difficulty"><%# Eval("difficulty") %></h3>
                        <p class="cardSubtext"><%# Eval("description") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="workoutContainer">
        <div id="workoutsContainer"></div>
    </div>
</body>
</html>
