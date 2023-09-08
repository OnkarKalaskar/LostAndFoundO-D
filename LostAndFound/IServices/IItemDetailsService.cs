using LostAndFound.Models;
using LostAndFound.ViewModels;

namespace LostAndFound.IServices
{
    public interface IItemDetailsService
    {
        public IEnumerable<ItemTable> GetAllItems();
    }
}
