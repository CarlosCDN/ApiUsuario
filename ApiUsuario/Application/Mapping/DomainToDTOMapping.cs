﻿using AutoMapper;
using ApiUsuario.Domain.Model;
using ApiUsuario.Application.DTOs;


namespace ApiUsuario.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping() 
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}