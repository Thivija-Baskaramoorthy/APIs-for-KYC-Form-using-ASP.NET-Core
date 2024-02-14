using System.ComponentModel.DataAnnotations;

namespace InternKYCApplication.DTOs.Requests
{
    public class OtpVerifyRequest
    {
        [Required]
        public string phone_number { get; set; }

        [Required]
        public string otp { get; set; }
    }
}
