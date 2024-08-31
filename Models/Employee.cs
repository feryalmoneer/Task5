using System.ComponentModel.DataAnnotations;

namespace Task5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string password { get; set; } = null!;
    }
}
