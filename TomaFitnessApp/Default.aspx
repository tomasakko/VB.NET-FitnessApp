<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="TomaFitnessApp._Default" %>
<%@ Register Src="~/components/navbar/navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<html>

<head runat="server">
    <title>Home Page</title>
    <link rel="stylesheet" href="components/navbar/navbarStyle.css" />
    <link rel="stylesheet" href="defaultStyles.css" />
</head>

<body>
    <uc:Navbar runat="server" />
        <div class="body">
            <div class="header">
                <div class="title">
                <h1>Toma's Fitness App</h1>
                <h2>Get Fitter. Faster.</h2>
            </div>

            <p class="subtitle">
                Welcome to my cutting-edge fitness app, 
                your ultimate companion on the journey to a stronger, healthier you! 
                Whether you're a seasoned gym enthusiast or just starting your fitness adventure, 
                I'm here to empower and guide you every step of the way.
            </p>
            </div>
            

       

<div class="cardGroup">

    <a class="cardSubtext" href="<%= ResolveUrl("~/pages/muscleGroups/muscleGroups.aspx") %>" >
        <div class="card1">
            <img class="iconImg" src="images/icons/exercises.png">
                <div class="container">
                <h4 class="cardTitle">Exercises</h4>
                    <p class="cardSubtext">
                        With my comprehensive exercise library, 
                        you'll discover a wide range of effective workouts tailored to target specific muscle groups. 
                    </p>
            </div>
        </a>
    </div>

    <a href="<%= ResolveUrl("~/pages/workoutPlans/workoutPlans.aspx") %>">
        <div class="card2">
            <img class="iconImg" src="images/icons/workoutPlans.png">
                <div class="container">
                <h4 class="cardTitle">Workout Plans</h4>
                    <p class="cardSubtext">
                        My app also offers expertly crafted workout plans designed to help you achieve your fitness goals, 
                        whether it's building muscle, improving endurance, or losing weight. 
                    </p>
            </div>
        </a>
    </div>

    <a href="<%= ResolveUrl("~/pages/personalRecords/personalRecords.aspx") %>">
        <div class="card3">
            <img class="iconImg" src="images/icons/notes.png">
                <div class="container">
                    <h4 class="cardTitle">Personal Records</h4>
                    <p class="cardSubtext">
                        I understand the importance of tracking your progress, so I've integrated a personal records feature. 
                </p>
            </div>
        </a>
    </div>
</div>
</div>
<form id="form1" runat="server">
</form>
</body>
</html>
