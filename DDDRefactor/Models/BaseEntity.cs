using System.ComponentModel.DataAnnotations.Schema;

namespace DDDRefactor.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool OnDelete { get; set; } = false;
    }
}
