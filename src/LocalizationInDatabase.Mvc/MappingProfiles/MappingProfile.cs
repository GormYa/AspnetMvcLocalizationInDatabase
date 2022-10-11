using AutoMapper;
using LocalizationInDatabase.Mvc.Models.Entities;
using LocalizationInDatabase.Mvc.ViewModels;

namespace LocalizationInDatabase.Mvc.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        CreateMap<Employee, EmployeeEditModel>().ReverseMap();

        CreateMap<Language, LanguageViewModel>().ReverseMap();
        CreateMap<Language, LanguageEditModel>().ReverseMap();

        CreateMap<StringResource, StringResourceViewModel>().ReverseMap();
        CreateMap<StringResource, StringResourceEditModel>().ReverseMap();
    }
}
