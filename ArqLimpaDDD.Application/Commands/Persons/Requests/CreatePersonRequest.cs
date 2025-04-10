﻿using ArqLimpaDDD.Application.Commands.Persons.Validations;
using ArqLimpaDDD.Domain.Messages;

namespace ArqLimpaDDD.Application.Commands.Persons.Requests
{
    public class CreatePersonRequest : Command
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public Guid? CreatedById { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreatePersonRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
