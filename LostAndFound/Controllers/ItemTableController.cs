using AutoMapper;
using LostAndFound.IServices;
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
    }
}
