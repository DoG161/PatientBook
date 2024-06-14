using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace PatientBook.Models

{
    internal class PatientManager
    {
        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        private string _jsonFilePath = "C:/Practic/PatientBook/Assets/list_patients.json";
        public void LoadPatientData()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            string jsonData = File.ReadAllText(_jsonFilePath);
            _patients = new ObservableCollection<Patient>(JsonSerializer.Deserialize<List<Patient>>(jsonData, options));
        }
        public void SavePatientsToJson(ObservableCollection<Patient> patients)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            string json = JsonSerializer.Serialize(patients, options);
            File.WriteAllText(_jsonFilePath, json);
        }
        public ObservableCollection<Patient> GetPatients()
        {
            return _patients;
        }
    }
}
