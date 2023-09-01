using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_API.Model
{
    [Table("user", Schema = "dblab")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public string Password { get; set; }
        public bool IsActivate { get; set; }
        public string CnpjCpf  { get; set; }
        public string Phone { get; set; }

    }
}
