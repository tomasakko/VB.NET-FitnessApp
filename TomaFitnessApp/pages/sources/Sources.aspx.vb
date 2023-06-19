Imports System.IO
Imports Newtonsoft.Json

Public Class Sources
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LoadSourcesData()
  End Sub

  Private Sub LoadSourcesData()
    Dim jsonString As String = File.ReadAllText(Server.MapPath("sourcesData.json"))

    Dim rootObject As RootObject = JsonConvert.DeserializeObject(Of RootObject)(jsonString)
    Dim sourcesData As List(Of Source) = rootObject.sources

    sourcesRepeater.DataSource = sourcesData
    sourcesRepeater.DataBind()
  End Sub

  Public Class RootObject
    Public Property sources As List(Of Source)
  End Class

  Public Class Source
    Public Property name As String
    Public Property logo As String
    Public Property description As String
    Public Property link As String
  End Class
End Class
