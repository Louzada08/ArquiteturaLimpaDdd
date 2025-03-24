using AutoMapper;
using ArqLimpaDDD.Application.Commands.Persons.Requests;
using ArqLimpaDDD.Application.Commands.Persons.Responses;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.ValueObjects;

namespace ArqLimpaDDD.Mapping.AutoMapperProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, CreatePersonRequest>().ReverseMap();
        CreateMap<PersonVO, CreatePersonResponse>().ReverseMap();
    }
}
