﻿using FluentValidation.Results;

namespace Core.Utilities.Extensions;

public class ValidationErrorDetails : ErrorDetails
{
    public IEnumerable<ValidationFailure> Errors { get; set; }
}