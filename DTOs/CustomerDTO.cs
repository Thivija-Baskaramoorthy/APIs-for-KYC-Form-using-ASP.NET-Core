using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternKYCApplication.DTOs
{
    public class CustomerDTO
    {
        
        public long id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string full_name { get; set; }

        [Required]
        public string phone_number { get; set; }

        [Required]
        public string email { get; set; }

        [Required]

        public string nic { get; set; }

        [Required]
        public string nationality { get; set; }

        [Required]
        public string selfie_image_path { get; set; }

        [Required]
        public string nic_front_image_path { get; set; }

        [Required]
        public string nic_rear_image_path { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
