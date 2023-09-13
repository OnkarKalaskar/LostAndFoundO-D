using AutoMapper;
using LostAndFound.IServices;
using LostAndFound.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LostAndFound.Controllers
{
    public class ItemTableController : Controller
    {
        private readonly IItemTableService _ItemTableService;

        public ItemTableController(IItemTableService service)
        {
            _ItemTableService = service; 
            
        }

        public IActionResult Index()
        {
            var ItemDetails = _ItemTableService.GetAllItems();
            return View(ItemDetails);
        }

        // GET: ItemTable/SearchPage/{searchString}
        public IActionResult SearchPage(string searchString)
        {
            var itemDetails = _ItemTableService.SearchByItemName(searchString);
            foreach(var item in itemDetails)
            {
                Console.WriteLine(item.ItemName);
            }
            return View(itemDetails);
        }
    }
}
