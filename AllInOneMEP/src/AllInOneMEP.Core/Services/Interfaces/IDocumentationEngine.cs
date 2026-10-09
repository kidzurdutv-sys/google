namespace AllInOneMEP.Core.Services.Interfaces
{
    /// <summary>
    /// The core engine for generating documentation like views and sheets.
    /// </summary>
    public interface IDocumentationEngine
    {
        /// <summary>
        /// Automatically creates necessary floor plans, 3D views, and sections.
        /// </summary>
        void AutoCreateViews();

        /// <summary>
        /// Automatically places smart, collision-free tags on elements in the view.
        /// </summary>
        void AutoTagViews();

        /// <summary>
        /// Generates sheets with a standard title block and places views on them.
        /// </summary>
        void GenerateSheets();
    }
}
