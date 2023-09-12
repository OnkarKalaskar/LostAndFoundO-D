using LostAndFound.Models;
using LostAndFound.ViewModels;

namespace LostAndFound.IServices
{
    public interface IItemTableService
    {
        public IEnumerable<ItemTableVM> GetAllItems();

        public IEnumerable<ItemTableVM> SearchByItemName(string itemName);
    }
}
