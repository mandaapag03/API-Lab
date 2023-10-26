using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_API.Model
{
    public class User
    {
        [Obsolete]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CpfCnpj  { get; set; }
        public string Phone { get; set; }

        // Navigation Properties
        [Obsolete]
        public UserType? UserType { get; set; }
    }
}
