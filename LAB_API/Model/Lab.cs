using System.Diagnostics;

namespace LAB_API.Model
{
    public class Lab
    {
        public int Id { get; set; }
        public string LabCode { get; set; }
        public int Andar { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
