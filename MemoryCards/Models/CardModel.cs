using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MemoryCards.Models

{
    public class CardModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public bool IsKnown { get; set; }
        public int level { get; set; }

    }
}
