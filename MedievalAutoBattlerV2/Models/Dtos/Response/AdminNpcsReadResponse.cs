using MedievalAutoBattlerV2.Models.Entities;

namespace MedievalAutoBattlerV2.Models.Dtos.Response
{
    public class AdminNpcsReadResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DeckEntry> Deck { get; set; }
        public int Level { get; set; }
    }
}