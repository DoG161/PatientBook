using PatientBook.Models;
using System.Collections.ObjectModel;

namespace PatientBook.ViewModels
{
    public class PatientsViewModel : ViewModelBase
    {
        public PatientsViewModel(ObservableCollection<Patient> items)
        {
            ListItems = new ObservableCollection<Patient>(items);
        }

        public ObservableCollection<Patient> ListItems { get; }
    }
}
