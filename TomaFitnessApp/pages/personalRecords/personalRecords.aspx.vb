Imports Newtonsoft.Json
Imports System.IO

Public Class personalRecords
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      Dim json As String = File.ReadAllText(Server.MapPath("../../pages/muscleGroups/data/muscleGroupsData.json"))
      Dim muscleGroups As List(Of MuscleGroup) = JsonConvert.DeserializeObject(Of RootObject)(json).muscleGroups

      muscleGroupsRepeater.DataSource = muscleGroups
      muscleGroupsRepeater.DataBind()
    End If
    RegisterStartupScript()
  End Sub

  Private Sub RegisterStartupScript()
    Dim script As String = "
        let activeExerciseContainer = null;

        function toggleExercises(card) {
            const exerciseContainer = card.querySelector('.exerciseContainer');
            const target = event.target;

            // Check if the target is an input field or the save progress button
            const isInputField = target.tagName.toLowerCase() === 'input';
            const isSaveProgressButton = target.classList.contains('saveProgress');

            if (!isInputField && !isSaveProgressButton) {
                if (activeExerciseContainer !== exerciseContainer) {
                    // Open the clicked card
                    if (activeExerciseContainer) {
                        activeExerciseContainer.style.display = 'none';
                    }

                    exerciseContainer.style.display = 'block';
                    activeExerciseContainer = exerciseContainer;
                } else {
                    // Close the clicked card
                    exerciseContainer.style.display = 'none';
                    activeExerciseContainer = null;
                }
            }
        }
    "

    Dim scriptTag As New LiteralControl("<script>" & script & "</script>")
    Page.Header.Controls.Add(scriptTag)
  End Sub
  Public Class RootObject
    Public Property muscleGroups As List(Of MuscleGroup)
  End Class

  Public Class MuscleGroup
    Public Property name As String
    Public Property description As String
    Public Property img As String
    Public Property exercises As List(Of Exercise)
  End Class

  Public Class Exercise
    Public Property name As String
    Public Property description As String
    Public Property exerciseImg As String
  End Class

End Class
