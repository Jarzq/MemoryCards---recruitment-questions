using System.ComponentModel.DataAnnotations;

namespace MemoryCards.Models

{
    public class CardModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public bool IsKnown { get; set; }
        public int level { get; set; }

        public bool FirstAttemp { get; set; }

    }
}
