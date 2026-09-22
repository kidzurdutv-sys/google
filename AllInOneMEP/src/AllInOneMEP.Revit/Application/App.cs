using System;
using System.Reflection;
using Autodesk.Revit.UI;

namespace AllInOneMEP.Revit.Application
{
    /// <summary>
    /// The main entry point for the Revit Add-in, responsible for building the custom Ribbon UI.
    /// </summary>
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "All-in-One MEP";
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                // Tab might already exist
            }

            RibbonPanel mechanicalPanel = application.CreateRibbonPanel(tabName, "Mechanical");
            RibbonPanel electricalPanel = application.CreateRibbonPanel(tabName, "Electrical");
            RibbonPanel documentationPanel = application.CreateRibbonPanel(tabName, "Documentation");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            // Mechanical Buttons
            mechanicalPanel.AddItem(new PushButtonData("cmdMech", "Run Mechanical", assemblyPath, "AllInOneMEP.Revit.Commands.MechanicalCommand"));

            // Electrical Buttons
            electricalPanel.AddItem(new PushButtonData("cmdElec", "Run Electrical", assemblyPath, "AllInOneMEP.Revit.Commands.ElectricalCommand"));

            // Documentation Buttons
            documentationPanel.AddItem(new PushButtonData("cmdDoc", "Run Documentation", assemblyPath, "AllInOneMEP.Revit.Commands.DocumentationCommand"));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
