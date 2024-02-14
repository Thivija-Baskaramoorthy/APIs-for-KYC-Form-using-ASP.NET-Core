using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternKYCApplication.Models
{
    [Table("otp_detail")]
    public class OtpDetailModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        public string phone_number { get; set; }

        [Required]
        public string otp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public DateTime created_at { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
