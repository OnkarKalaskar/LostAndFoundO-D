using LostAndFound.Models;

namespace LostAndFound.ViewModels
{
    public class ItemTableVM
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string FoundSeatLocation { get; set; } = null!;

        public string FloorNumber { get; set; } = null!;

        public bool? IsDeleted { get; set; }

        public bool? IsFound { get; set; }

        public int? UserId { get; set; }

       
    }
}
