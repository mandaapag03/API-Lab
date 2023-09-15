using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LAB_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CpfCnpj  { get; set; }
        public string Phone { get; set; }

        // Navigation Properties
        public UserType? UserType { get; set; }
    }
}
