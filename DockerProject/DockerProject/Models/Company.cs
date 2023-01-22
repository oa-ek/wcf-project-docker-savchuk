using System.ComponentModel.DataAnnotations;

namespace DockerProject.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID:{Id}, Назва:{Name}";
        }
    }
}
