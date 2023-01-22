using System.ComponentModel.DataAnnotations;

namespace DockerProject.Models
{
    public class Phone
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, Назва: {Title}, Компанія:{Company.Name}, Ціна: {Price} грн.";
        }

    }
}
