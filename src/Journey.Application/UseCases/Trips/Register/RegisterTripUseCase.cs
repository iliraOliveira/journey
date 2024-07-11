using FluentValidation.Internal;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson tripJson)
        {
            validate(tripJson);
            var dbContext = new JourneyDbContext();
            var entity = new Trip
            {
                Name = tripJson.Name,
                StartDate = tripJson.StartDate,
                EndDate = tripJson.EndDate,
            };
            dbContext.Trips.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
            };
        }

        private void validate(RequestRegisterTripJson tripJson)
        {
            var validator = new RegisterTripValidate();
            var result = validator.Validate(tripJson);
            if(!result.IsValid)
            {
               var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            }
        }
    }
}
