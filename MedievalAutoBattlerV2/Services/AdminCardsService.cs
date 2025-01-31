using MedievalAutoBattlerV2.Models.Entities;
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
    }
}
