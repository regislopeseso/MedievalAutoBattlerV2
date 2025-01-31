using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Dtos.Response;
using MedievalAutoBattlerV2.Models.Entities;
using MedievalAutoBattlerV2.Utilities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<(List<AdminCardsReadResponse>, string)> Read()
        {
            var cardDB = await _daoDbContext.Cards.ToListAsync();

            if (cardDB == null)
            {
                return (null, "Error: no cards available");
            }

            var response = new List<AdminCardsReadResponse>();

            foreach (var card in cardDB)
            {
                if(card.IsDeleted == false)
                {
                    var c = new AdminCardsReadResponse
                    {
                        Id = card.Id,
                        Name = card.Name,
                        Power = card.Power,
                        UpperHand = card.UpperHand,
                        Type = card.Type,
                        Level = card.Level
                    };

                    response.Add(c);
                }
            }            
           
            return (response, "Read Action successful!");
        }
    }
}
