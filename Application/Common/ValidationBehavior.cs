﻿using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Reflection;

namespace Application.Common
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            return TryCreateResponseFromErrors(validationResult.Errors, out TResponse? response)
                ? response
                : throw new ValidationException(validationResult.Errors);
        }

        private bool TryCreateResponseFromErrors(List<ValidationFailure> validationFailures, out TResponse response)
        {
            List<Error> errors = validationFailures
                .ConvertAll(x => Error.Validation(
                 code: x.PropertyName,
                 description: x.ErrorMessage));

            response = (TResponse?)typeof(TResponse)
                .GetMethod(
                    name: nameof(ErrorOr<object>.From),
                    bindingAttr: BindingFlags.Static | BindingFlags.Public,
                    types: new[] { typeof(List<Error>) })?
                .Invoke(null, new[] { errors })!;

            return response is not null;
        }
    }
}
