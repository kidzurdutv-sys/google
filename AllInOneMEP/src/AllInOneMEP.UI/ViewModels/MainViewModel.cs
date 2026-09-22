using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AllInOneMEP.Core.Services.Interfaces;
using AllInOneMEP.Core.Services.Mechanical;
using AllInOneMEP.Core.Services.Electrical;
using AllInOneMEP.Core.Services.Documentation;

namespace AllInOneMEP.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IMechanicalEngine _mechanicalEngine = new MechanicalEngine();
        private readonly IElectricalEngine _electricalEngine = new ElectricalEngine();
        private readonly IDocumentationEngine _documentationEngine = new DocumentationEngine();

        public event PropertyChangedEventHandler? PropertyChanged;
        public string StatusMessage { get; set; } = "Ready";

        public ICommand RunMechanicalCommand => new RelayCommand(_ => { StatusMessage = "Mechanical"; OnPropertyChanged(nameof(StatusMessage)); _mechanicalEngine.RouteDuctwork(); });
        public ICommand RunElectricalCommand => new RelayCommand(_ => { StatusMessage = "Electrical"; OnPropertyChanged(nameof(StatusMessage)); _electricalEngine.RouteCableTrays(); });
        public ICommand RunDocumentationCommand => new RelayCommand(_ => { StatusMessage = "Documentation"; OnPropertyChanged(nameof(StatusMessage)); _documentationEngine.GenerateSheets(); });

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        public event EventHandler? CanExecuteChanged;
        public RelayCommand(Action<object?> execute) => _execute = execute;
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _execute(parameter);
    }
}
