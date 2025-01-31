using MedievalAutoBattlerV2.Models.Enums;

namespace MedievalAutoBattlerV2.Models.Dtos.Response
{
    public class AdminCardsCreateResponse
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int UpperHand { get; set; }
        public CardType Type { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }
    }
}
