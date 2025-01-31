using MedievalAutoBattlerV2.Models.Entities;

namespace MedievalAutoBattlerV2.Models.Dtos.Request
{
    public class AdminNpcsCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DeckEntry> Decks { get; set; }
        public int Level { get; set; }
    }
}