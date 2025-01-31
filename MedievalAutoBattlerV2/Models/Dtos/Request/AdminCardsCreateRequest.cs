using MedievalAutoBattlerV2.Models.Enums;

namespace MedievalAutoBattlerV2.Models.Dtos.Request
{
    public class AdminCardsCreateRequest
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int UpperHand { get; set; }
        public CardType Type { get; set; }
    }
}
