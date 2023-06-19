<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="navbar.ascx.vb" Inherits="TomaFitnessApp.navbar" %>

<head>
    <title></title>
    <link rel="stylesheet" href="navbarStyle.css" />
</head>
<body class="navbar">
    <ul class="ul">
            <a href="<%= ResolveUrl("~/Default.aspx") %>"><img class="logo" src="../../images/logo.png" /></a>

        <li class="li"><a href="<%= ResolveUrl("~/pages/muscleGroups/muscleGroups.aspx") %>">Exercises</a></li>
        <li class="li"><a href="<%= ResolveUrl("~/pages/workoutPlans/workoutPlans.aspx") %>">Workout Plans</a></li>
        <li class="li"><a href="<%= ResolveUrl("~/pages/personalRecords/personalRecords.aspx") %>">Personal Records</a></li>
        <li class="li"><a href="<%= ResolveUrl("~/pages/sources/Sources.aspx") %>">Sources</a></li>
    </ul>
</body>
