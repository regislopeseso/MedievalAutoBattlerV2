using MedievalAutoBattlerV2.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedievalAutoBattlerV2.Models.Entities
{
    [Table("cards")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int UpperHand {  get; set; }
        public CardType Type { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }
    }
}