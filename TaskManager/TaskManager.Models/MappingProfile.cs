using AutoMapper;
using TaskManager.Models.DTO;
using TaskManager.Models;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDoDto, ToDo>();
    }
}