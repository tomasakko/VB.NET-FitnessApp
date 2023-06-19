<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="muscleGroups.aspx.vb" Inherits="TomaFitnessApp.muscleGroups" %>
<%@ Register Src="~/components/navbar/navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<html>

<head runat="server">
    <title>Muscle Groups</title>
    <link rel="stylesheet" href="../../components/navbar/navbarStyle.css" />
    <link rel="stylesheet" href="muscleGroupsStyle.css" />
</head>

<body>
  <uc:Navbar runat="server" />

  <div class="cardGroup">
    <asp:Repeater runat="server" ID="muscleGroupsRepeater">
      <ItemTemplate>
        <div class="muscleCard" onclick='displayExercises("<%# Eval("exercisesHtml") %>")'>
          <div class="container">
            <img class="imgIcon" src="<%# Eval("img") %>"/>
            <h3 class="cardTitle"><%# Eval("name") %></h3>
            <p class="cardSubtext"><%# Eval("description") %></p>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>

  <div class="exerciseContainer">
    <div id="exercisesContainer"></div>
  </div>
</body>
</html>
