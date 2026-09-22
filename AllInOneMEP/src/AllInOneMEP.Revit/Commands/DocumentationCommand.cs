using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AllInOneMEP.Core.Services.Documentation;

namespace AllInOneMEP.Revit.Commands
{
    /// <summary>
    /// Executes the documentation engine functionalities such as automated sheet generation.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class DocumentationCommand : IExternalCommand
    {
        /// <summary>
        /// The main execution block of the external command.
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var engine = new DocumentationEngine();
            engine.GenerateSheets();
            return Result.Succeeded;
        }
    }
}
