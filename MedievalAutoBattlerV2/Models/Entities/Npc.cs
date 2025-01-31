using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedievalAutoBattlerV2.Models.Entities
{
    [Table("npcs")]
    public class Npc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DeckEntry> Deck { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }
    }
}
