using AutoMapper;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.DTOs;
using ApiUsuario.Application.ViewModel;


namespace ApiUsuario.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping() 
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();
    }
}
