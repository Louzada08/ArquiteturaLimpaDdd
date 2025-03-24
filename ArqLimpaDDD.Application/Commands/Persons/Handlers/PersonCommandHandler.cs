using AutoMapper;
using MediatR;
using ArqLimpaDDD.Application.Commands.Persons.Requests;
using ArqLimpaDDD.Application.Commands.Persons.Responses;
using ArqLimpaDDD.Application.Services.Persons;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.Domain.Messages;
using ArqLimpaDDD.Domain.Validation;

namespace ArqLimpaDDD.Application.Commands.Persons.Handlers;

public class PersonCommandHandler : CommandHandler,
    IRequestHandler<CreatePersonRequest, ValidationResultBag>
{
    private readonly IPersonService _personService;
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonCommandHandler(IPersonService personService, IPersonRepository personRepository, IMapper mapper)
    {
        _personService = personService;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ValidationResultBag> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var personMap = _mapper.Map<Person>(request);

        var ret = await _personService.Create(personMap);

        ValidationResult.Data = _mapper.Map<CreatePersonResponse>(ret);

        return ValidationResult;
    }
}
