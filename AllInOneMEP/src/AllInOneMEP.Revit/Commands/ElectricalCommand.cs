using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AllInOneMEP.Core.Services.Electrical;

namespace AllInOneMEP.Revit.Commands
{
    /// <summary>
    /// Executes the electrical engine functionalities such as auto-routing cable trays.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class ElectricalCommand : IExternalCommand
    {
        /// <summary>
        /// The main execution block of the external command.
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var engine = new ElectricalEngine();
            engine.RouteCableTrays();
            return Result.Succeeded;
        }
    }
}
