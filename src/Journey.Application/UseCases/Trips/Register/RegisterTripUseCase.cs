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
            if(string.IsNullOrWhiteSpace(tripJson.Name))
            {
                throw new JourneyException(ResourceErrorMessages.NAME_EMPTY);
            }

            if(tripJson.StartDate.Date < DateTime.UtcNow.Date)
            {
                throw new JourneyException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
            }

            if (tripJson.EndDate.Date < DateTime.UtcNow.Date)
            {
                throw new JourneyException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
            }
        }
    }
}
