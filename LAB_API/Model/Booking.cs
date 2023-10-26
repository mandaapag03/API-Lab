using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_API.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Booking
    {
        [Obsolete]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Lab")]
        public int LabId { get; set; }

        public DateTime Date { get; set; }

        // Navigation Properties
        [Obsolete]
        public User User { get; set; }
        [Obsolete]
        public Lab Lab { get; set; }
    }
}
