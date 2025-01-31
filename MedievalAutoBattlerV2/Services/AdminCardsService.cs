using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Dtos.Response;
using MedievalAutoBattlerV2.Models.Entities;
using MedievalAutoBattlerV2.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MedievalAutoBattlerV2.Services
{
    public class AdminCardsService
    {
        private readonly ApplicationDbContext _daoDbContext;

        public AdminCardsService(ApplicationDbContext daoDbContext)
        {
            this._daoDbContext = daoDbContext;
        }

        public async Task<(AdminCardsCreateResponse, string)> Create(AdminCardsCreateRequest card)
        {
            if(card == null)
            {
                return (null, "Error: card is null");
            }

            var newCard = new AdminCardsCreateResponse
            {
                Name = card.Name,
                Power = card.Power,
                UpperHand = card.UpperHand,
                Level = Helper.GetCardLevel(card),
                Type = card.Type,
                IsDeleted = false
            };

            this._daoDbContext.Add(newCard);
            this._daoDbContext.SaveChangesAsync();

            return (newCard, "Create action successful");
        }
    }
}
    