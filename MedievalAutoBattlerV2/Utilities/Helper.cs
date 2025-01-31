using MedievalAutoBattlerV2.Models.Dtos.Request;

namespace MedievalAutoBattlerV2.Utilities
{
    public class Helper
    {
        public static int GetCardLevel(AdminCardsCreateRequest card)
        {
            return (newCard.Power + newCard.UpperHand)/2;
        }
    }
}
