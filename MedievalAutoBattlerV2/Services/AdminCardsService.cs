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
            var newCard = new Card
            {
                Name = card.Name,
                Power = card.Power,
                UpperHand = card.UpperHand,
                Type = card.Type,
                Level = Helper.GetCardLevel(card.Power, card.UpperHand),
                IsDeleted = false
            };

            this._daoDbContext.Add(newCard);
            await this._daoDbContext.SaveChangesAsync();

            return "Create successful";
        }

        public async Task<(List<AdminCardsReadResponse>, string)> Read()
        {
            var cardsDB = await _daoDbContext.Cards.ToListAsync();

            var response = new List<AdminCardsReadResponse>();

            foreach (var card in cardsDB)
            {
                if (card.IsDeleted == false)
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

            return (response, "Read successful!");
        }

        public async Task<string> Update(AdminCardsUpdateRequest card)
        {
            var cardDB = await _daoDbContext.Cards
                .Where(a => a.Id == card.Id)
                .FirstOrDefaultAsync();

            cardDB.Name = card.Name;
            cardDB.Power = card.Power;
            cardDB.UpperHand = card.UpperHand;
            cardDB.Type = card.Type;
            cardDB.Level = Helper.GetCardLevel(card.Power, card.UpperHand);

            await _daoDbContext.SaveChangesAsync();

            return "Update successful";
        }

        public async Task<string> Delete(int id)
        {
            var cardDB = await _daoDbContext.Cards
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            cardDB.IsDeleted = true;

            await this._daoDbContext.SaveChangesAsync();

            return "Delete successful";
        }
    }
}
