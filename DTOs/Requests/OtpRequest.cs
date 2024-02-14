using System.ComponentModel.DataAnnotations;

namespace InternKYCApplication.DTOs.Requests
{
    public class OtpRequest
    {
        [Required]
        public string phone_number { get; set; }
        
    }
}
