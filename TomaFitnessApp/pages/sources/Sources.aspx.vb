Imports System.IO
Imports Newtonsoft.Json

Public Class Sources
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' Call the method to load the sources data
    LoadSourcesData()
  End Sub

  Private Sub LoadSourcesData()
    ' Read the content of the sourcesData.json file
    Dim jsonString As String = File.ReadAllText(Server.MapPath("sourcesData.json"))

    ' Deserialize the JSON into a RootObject
    Dim rootObject As RootObject = JsonConvert.DeserializeObject(Of RootObject)(jsonString)

    ' Get the list of Source objects from the RootObject
    Dim sourcesData As List(Of Source) = rootObject.sources

    ' Set the data source of the sourcesRepeater control to the list of Source objects
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
