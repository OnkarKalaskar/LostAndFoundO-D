using AutoMapper;
using LostAndFound.Models;
using LostAndFound.ViewModels;

namespace LostAndFound.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ItemTable, ItemTableVM>().ReverseMap();
        }
    }
}
