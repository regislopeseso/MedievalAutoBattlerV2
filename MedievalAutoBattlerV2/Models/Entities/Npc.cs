namespace MedievalAutoBattlerV2.Models.Entities
{
    public class Npc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Card> Deck { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }
    }
}
