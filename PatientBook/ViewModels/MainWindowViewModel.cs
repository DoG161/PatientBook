using PatientBook.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
namespace PatientBook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var manager = new PatientManager();
        manager.LoadPatientData();
        PatientsList = new PatientsViewModel(manager.GetPatients());
        ContentViewModel = PatientsList;
    }
    private ViewModelBase _contentViewModel;
    public PatientsViewModel PatientsList { get; }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void AddPatient()
    {
        AddPatientViewModel addPatientViewModel = new ();
        Observable.Merge(
                addPatientViewModel.OkCommand,
                addPatientViewModel.CancelCommand.Select(_ => (Patient?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        PatientsList.ListItems.Add(newItem);
                    }
                    ContentViewModel = PatientsList;
                });
        ContentViewModel = addPatientViewModel;
    }
    public void SavePatient()
    {
        var manager = new PatientManager();
        manager.SavePatientsToJson(PatientsList.ListItems);
    }
    public void DeletePatient()
    {
        var patientsToRemove = PatientsList.ListItems.ToList();
        foreach (var patient in patientsToRemove)
        {
            if(patient.IsDelete)
            {
                PatientsList.ListItems.Remove(patient);
            }
        }
    }
}
