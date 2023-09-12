using AutoMapper;
using LostAndFound.IServices;
using LostAndFound.Models;
using LostAndFound.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LostAndFound.Services
{
    public class ItemTableService : IItemTableService
    {
        private readonly LostAndFoundContext _context;

        private readonly IMapper _mapper;

        public ItemTableService(LostAndFoundContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ItemTableVM> GetAllItems()
        {
            return this._mapper.Map<List<ItemTableVM>>(this._context.ItemTables.ToList());
        }

        public IEnumerable<ItemTableVM> SearchByItemName(string itemName)
        {
            return _mapper.Map<List<ItemTableVM>>(_context.UserTables.FromSqlRaw('EXEC GetDetailsByName {0}', itemName));
        }

  
    }
}
