using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AllInOneMEP.Core.Services.Mechanical;

namespace AllInOneMEP.Revit.Commands
{
    /// <summary>
    /// Executes the mechanical engine functionalities such as auto-routing ductwork.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class MechanicalCommand : IExternalCommand
    {
        /// <summary>
        /// The main execution block of the external command.
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var engine = new MechanicalEngine();
            engine.RouteDuctwork();
            return Result.Succeeded;
        }
    }
}
