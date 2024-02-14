using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using static InternKYCApplication.Helpers.MyCustomValidation;


namespace InternKYCApplication.DTOs.Requests
{
    public class CreateCustomerDataRequest
    {
        [Required]
        public string title { get; set; }

        [Required]
        public string fullname {  get; set; }

        [Required]
        public string phone_number {  get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string nic { get; set; }

        [Required]
        public string nationality { get; set; }

        [Required]
        [ImageValidation(nameof(selfie))]
        public string selfie { get; set; }

        [Required]
        [ImageValidation(nameof(nic_front))]
        public string nic_front { get; set; }

        [Required]
        [ImageValidation(nameof(nic_rear))]
        public string nic_rear { get; set; }
    }
}
