using System.ComponentModel.DataAnnotations;

namespace Task5.Models
{
    public class Account
    {
        [Key]
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
