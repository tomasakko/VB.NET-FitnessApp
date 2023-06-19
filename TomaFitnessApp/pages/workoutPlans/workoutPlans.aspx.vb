Imports System.IO
Imports Newtonsoft.Json

Public Class workoutPlans
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      ' Bind the workout plans data to the repeater control
      BindWorkoutPlans()
    End If

    ' Register the startup script
    RegisterStartupScript()
  End Sub

  Private Sub BindWorkoutPlans()
    ' Read the content of the workoutPlansData.json file
    Dim jsonPath As String = Server.MapPath("workoutPlansData.json")
    Dim jsonString As String = File.ReadAllText(jsonPath)

    ' Deserialize the JSON into a WorkoutPlansData object
    Dim workoutPlansData As WorkoutPlansData = JsonConvert.DeserializeObject(Of WorkoutPlansData)(jsonString)

    ' Generate HTML for each workout plan
    Dim updatedWorkoutPlans As New List(Of WorkoutPlan)()
    For Each workoutPlan As WorkoutPlan In workoutPlansData.workoutPlans
      Dim workoutPlansHtml As String = GenerateWorkoutPlansHtml(workoutPlan.workout)
      workoutPlan.workoutPlansHtml = workoutPlansHtml
      updatedWorkoutPlans.Add(workoutPlan)
    Next

    ' Set the data source of the workoutPlansRepeater control to the updated list of WorkoutPlan objects
    workoutPlansRepeater.DataSource = updatedWorkoutPlans
    workoutPlansRepeater.DataBind()
  End Sub

  Private Sub RegisterStartupScript()
    ' Register a JavaScript function to display workout plans dynamically
    Dim script As String = "
            function displayWorkoutPlans(workoutPlansHtml, groupName) {
                var workoutPlansContainer = document.getElementById('workoutsContainer');
                workoutPlansContainer.innerHTML = '<h2>' + groupName + '</h2>' + workoutPlansHtml;
            }
        "

    ' Add the script to the <head> section of the page
    Dim scriptTag As New LiteralControl("<script>" & script & "</script>")
    Page.Header.Controls.Add(scriptTag)
  End Sub

  Protected Sub workoutPlansRepeater_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
      ' Get the current WorkoutPlan object from the data item
      Dim workoutPlan As WorkoutPlan = TryCast(e.Item.DataItem, WorkoutPlan)

      ' Set the background image of the cardDiv
      Dim cardDiv As HtmlGenericControl = TryCast(e.Item.FindControl("cardDiv"), HtmlGenericControl)
      If cardDiv IsNot Nothing Then
        cardDiv.Style("background-image") = "url('" & ResolveUrl(workoutPlan.img) & "')"
      End If

      ' Set the workout plans HTML for the workoutContainer
      Dim workoutContainer As Literal = TryCast(e.Item.FindControl("workoutContainer"), Literal)
      If workoutContainer IsNot Nothing Then
        workoutContainer.Text = workoutPlan.workoutPlansHtml
      End If

      ' Set the data source of the workoutsRepeater control to the list of Workout objects
      Dim workoutsRepeater As Repeater = TryCast(e.Item.FindControl("workoutsRepeater"), Repeater)
      If workoutsRepeater IsNot Nothing Then
        workoutsRepeater.DataSource = workoutPlan.workout
        workoutsRepeater.DataBind()
      End If
    End If
  End Sub

  Private Function GenerateWorkoutPlansHtml(ByVal workouts As List(Of Workout)) As String
    ' Generate HTML for each workout
    Dim workoutPlansHtml As String = ""
    For Each workout As Workout In workouts
      workoutPlansHtml += "<div>"
      workoutPlansHtml += "<h4>" + workout.day + "</h4>"
      workoutPlansHtml += "<li>" + workout.exercises + "</li>"
      workoutPlansHtml += "<p>" + workout.extraInfo + "</p>"
      workoutPlansHtml += "<p>" + workout.why + "</p>"
      workoutPlansHtml += "</div>"
    Next

    Return workoutPlansHtml
  End Function

  Public Class WorkoutPlansData
    Public Property workoutPlans As List(Of WorkoutPlan)
  End Class

  Public Class WorkoutPlan
    Public Property name As String
    Public Property description As String
    Public Property difficulty As String
    Public Property img As String
    Public Property workout As List(Of Workout)
    Public Property workoutPlansHtml As String
  End Class

  Public Class Workout
    Public Property day As String
    Public Property exercises As String
    Public Property extraInfo As String
    Public Property why As String
  End Class
End Class
