using PatientBook.Models;

namespace PatientBook.ViewModels
{
    public class EditPatientViewModel : ViewModelBase
    {
        EditPatientViewModel(Patient patient) { 
            _patient = patient;
        }
        private Patient _patient;
        private string _fullName = string.Empty;
        private string _birthday = string.Empty;
        private string _genderName = string.Empty;
    }
}
