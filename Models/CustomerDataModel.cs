using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static InternKYCApplication.Helpers.MyCustomValidation;

namespace InternKYCApplication.Models
{
    [Table("kyc_data")]
    public class CustomerDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [DisplayName("Selfie")]
        [ImageValidation(nameof(selfie_image_path))]
        public string selfie_image_path { get; set; }

        [Required]
        [DisplayName("NIC_Front")]
        [ImageValidation(nameof(nic_front_image_path))]
        public string nic_front_image_path { get; set; }

        [Required]
        [DisplayName("NIC_Rear")]
       [ImageValidation(nameof(nic_rear_image_path))]
        public string nic_rear_image_path { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }


}
