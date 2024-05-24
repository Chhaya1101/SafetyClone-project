using System.ComponentModel.DataAnnotations;
namespace SafetyClone_project.Models
{
    public class Certificate
    {
    
        public long UserID {  get; set; }
       
        [Required]
        public string StudentName { get; set; }
        [Required]
        public  string Description { get; set; }
     


    }
    public class GetCertificates
    {
        public long CertificateID { get; set; }
        public string StudentName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class GetCreatedCertificates
    {
        public long CertificateID { get; set; }
        public string StudentName { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

    }

}
