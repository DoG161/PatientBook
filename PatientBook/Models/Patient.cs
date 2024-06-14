using System.Text.Json.Serialization;
namespace PatientBook.Models

{
    public class Patient
    {
        [JsonPropertyName("fullname")]
        public string FullName { get; set; } = string.Empty;
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; } = string.Empty;
        [JsonPropertyName("genderName")]
        public string GenderName { get; set; } = string.Empty;

        public bool IsDelete { get; set; } = false;
    }
}
