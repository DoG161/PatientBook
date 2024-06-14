using PatientBook.Models;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using Avalonia.Controls;
using System.Runtime.CompilerServices;

namespace PatientBook.ViewModels
{
    public class AddPatientViewModel : ViewModelBase
    {
        private string _fullName = string.Empty;
        private string _birthday = string.Empty;
        private string _genderName = string.Empty;
        public ReactiveCommand<Unit, Patient> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddPatientViewModel()
        {
            var isValidObservable = this.WhenAnyValue(
                x => x.FullName,
                x => x.Birthday,
                x => x.GenderName,
                (fullName, birthday, genderName) =>
                    !string.IsNullOrWhiteSpace(fullName) &&
                    !string.IsNullOrWhiteSpace(birthday) &&
                    !string.IsNullOrWhiteSpace(genderName));

            OkCommand = ReactiveCommand.Create(
                () => new Patient { FullName = FullName, Birthday = Birthday, GenderName = GenderName }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }
        public string FullName
        {
            get => _fullName;
            set => this.RaiseAndSetIfChanged(ref _fullName, value);
        }
        public string Birthday
        {
            get => _birthday;
            set => this.RaiseAndSetIfChanged(ref _birthday, value);
        }
        public string GenderName
        {
            get => _genderName;
            set => this.RaiseAndSetIfChanged(ref _genderName, value);
        }
    }
}
