using Journey.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public void Execute(RequestRegisterTripJson tripJson)
        {
            validate(tripJson);
        }

        private void validate(RequestRegisterTripJson tripJson)
        {
            if(string.IsNullOrWhiteSpace(tripJson.Name))
            {
                throw new ArgumentException("Nome não pode ser vazio.");
            }

            if(tripJson.StartDate < DateTime.UtcNow)
            {
                throw new ArgumentException("A viagem não pode ser registrada para uma data passada.");
            }

            if (tripJson.EndDate >= DateTime.UtcNow)
            {
                throw new ArgumentException("A viagem não pode ser registrada para uma data passada.");
            }
        }
    }
}
