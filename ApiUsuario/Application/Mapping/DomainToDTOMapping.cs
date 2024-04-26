using AutoMapper;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.DTOs;
using ApiUsuario.Application.ViewModel;


namespace ApiUsuario.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping() 
    {
        CreateMap<User, UserDTO>().ForMember(User => User.Name, opt => opt.MapFrom(UserDTO => UserDTO.Name)).
            ForMember(User => User.Cpf, opt => opt.MapFrom(UserDTO => UserDTO.Cpf)).
            ForMember(User => User.UserName, opt => opt.MapFrom(UserDTO => UserDTO.UserName)).
            ForMember(User => User.Email, opt => opt.MapFrom(UserDTO => UserDTO.Email)).
            ForMember(User => User.NumberHome, opt => opt.MapFrom(UserDTO => UserDTO.NumberHome)).
            ForMember(User => User.Address, opt => opt.MapFrom(UserDTO => UserDTO.Address)).
            ForMember(User => User.NumberPhone, opt => opt.MapFrom(UserDTO => UserDTO.NumberPhone)).
            ForMember(User => User.UsuarioId, opt => opt.MapFrom(UserDTO => UserDTO.UsuarioId)).
            ForMember(User => User.BirthdayData, opt => opt.MapFrom(UserDTO => UserDTO.BirthdayData)).
            ForMember(User => User.CreatedDate, opt => opt.MapFrom(UserDTO => UserDTO.CreatedDate)).
            ForMember(User => User.Status, opt => opt.MapFrom(UserDTO => UserDTO.Status)).
            ForMember(User => User.Profile, opt => opt.MapFrom(UserDTO => UserDTO.Profile));




        CreateMap<User, UserViewModel>().ReverseMap();
    }
}
