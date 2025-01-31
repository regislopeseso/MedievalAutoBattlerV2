using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Entities;
using MedievalAutoBattlerV2.Utilities;

namespace MedievalAutoBattlerV2.Services
{
    public class AdminCardsService
    {
        private readonly ApplicationDbContext _daoDbContext;

        public AdminCardsService(ApplicationDbContext daoDbContext)
        {
            this._daoDbContext = daoDbContext;
        }

        public async Task<string> Create(AdminCardsCreateRequest card)
        {
            if (card == null)
            {
                return "Error: card is null";
            }

            var newCard = new Card
            {
                Name = card.Name,
                Power = card.Power,
                UpperHand = card.UpperHand,
                Type = card.Type,
                Level = Helper.GetCardLevel(card),
                IsDeleted = false
            };

            this._daoDbContext.Add(newCard);
            await this._daoDbContext.SaveChangesAsync();        

            return "Create action successful";
        }
    }
}
