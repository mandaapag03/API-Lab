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
        public EUserType UserType { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CpfCnpj  { get; set; }
        public string Phone { get; set; }

    }
}
