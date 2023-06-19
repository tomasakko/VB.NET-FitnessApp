Imports System.IO
Imports Newtonsoft.Json

Public Class muscleGroups
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      BindMuscleGroups()
    End If
    RegisterStartupScript()
  End Sub

  Private Sub BindMuscleGroups()
    ' Read the JSON file containing muscle group data
    Dim jsonPath As String = Server.MapPath("data/muscleGroupsData.json")
    Dim jsonString As String = File.ReadAllText(jsonPath)
    Dim muscleGroupsData As MuscleGroupsData = JsonConvert.DeserializeObject(Of MuscleGroupsData)(jsonString)

    Dim updatedMuscleGroups As New List(Of MuscleGroup)()

    For Each muscleGroup As MuscleGroup In muscleGroupsData.muscleGroups
      ' Generate HTML for exercises in the muscle group
      Dim exercisesHtml As String = GenerateExercisesHtml(muscleGroup.exercises)
      muscleGroup.exercisesHtml = exercisesHtml

      updatedMuscleGroups.Add(muscleGroup)
    Next

    ' Bind the updated muscle groups to the repeater control
    muscleGroupsRepeater.DataSource = updatedMuscleGroups
    muscleGroupsRepeater.DataBind()
  End Sub

  Private Sub RegisterStartupScript()
    ' function to display exercises HTML when called
    Dim script As String = "
            function displayExercises(exercisesHtml) {
                var exercisesContainer = document.getElementById('exercisesContainer');
                exercisesContainer.innerHTML = exercisesHtml;
            }
        "

    ' Register the script in the page's header
    Dim scriptTag As New LiteralControl("<script>" & script & "</script>")
    Page.Header.Controls.Add(scriptTag)
  End Sub

  Protected Sub muscleGroupsRepeater_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
      Dim muscleGroup As MuscleGroup = TryCast(e.Item.DataItem, MuscleGroup)

      ' Find the exercises container and populate it with the generated exercises HTML
      Dim exercisesContainer As Literal = TryCast(e.Item.FindControl("exercisesContainer"), Literal)
      If exercisesContainer IsNot Nothing Then
        exercisesContainer.Text = muscleGroup.exercisesHtml
      End If

      ' Bind the exercises repeater within the muscle group item
      Dim exercisesRepeater As Repeater = TryCast(e.Item.FindControl("exercisesRepeater"), Repeater)
      If exercisesRepeater IsNot Nothing Then
        exercisesRepeater.DataSource = muscleGroup.exercises
        exercisesRepeater.DataBind()
      End If
    End If
  End Sub

  Private Function GenerateExercisesHtml(ByVal exercises As List(Of Exercise)) As String
    Dim exercisesHtml As String = ""
    For Each exercise As Exercise In exercises
      ' Generate HTML markup for each exercise
      exercisesHtml += "<div>"
      exercisesHtml += "<h4>" + exercise.name + "</h4>"
      exercisesHtml += "<p>" + exercise.description + "</p>"
      exercisesHtml += "<img src=" + exercise.exerciseImg + ">"
      exercisesHtml += "</div>"
    Next

    Return exercisesHtml
  End Function

  Public Class MuscleGroupsData
    Public Property muscleGroups As List(Of MuscleGroup)
  End Class

  Public Class MuscleGroup
    Public Property name As String
    Public Property description As String
    Public Property img As String
    Public Property exercises As List(Of Exercise)
    Public Property exercisesHtml As String
  End Class

  Public Class Exercise
    Public Property name As String
    Public Property description As String
    Public Property exerciseImg As String
  End Class
End Class
