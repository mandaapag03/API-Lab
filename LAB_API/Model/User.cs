using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LAB_API.Model
{
    [Table("user", Schema = "dblab")]
    public class User
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("user_type_id")]
        public int UserTypeId { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("cpf_cnpj")]
        public string CpfCnpj  { get; set; }
        [Column("phone")]
        public string Phone { get; set; }

    }
}
