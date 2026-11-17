using System.ComponentModel.DataAnnotations;

namespace BlazorScheduler.Shared.Models
{
    public class ResourceModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
