using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace HelloWorld
{

    // Attributes
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class Class1 : IExternalCommand
    {
        // Main method
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                ExportA3DView(doc, uidoc);
            }

            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            TaskDialog.Show("Success", "3D view exported successfully!");
            return Result.Succeeded;
        }

        public void ExportA3DView(Document doc, UIDocument uidoc)
        {

            // abstract the name of the image
            string imageName = uidoc.ActiveView.Name;
            // instanitate the image exportoptions class
            ImageExportOptions export = new ImageExportOptions();
            export.ExportRange = ExportRange.VisibleRegionOfCurrentView;
            export.FilePath = @$"C:\\Users\\Symon Kipkemei\\Desktop\{imageName}.png";
            export.ShadowViewsFileType = ImageFileType.PNG;
            export.HLRandWFViewsFileType = ImageFileType.PNG;
            export.ImageResolution = ImageResolution.DPI_300;
            export.ZoomType = ZoomFitType.Zoom;
            export.Zoom = 100;


            doc.ExportImage(export);
           
        }
       


    }
}
