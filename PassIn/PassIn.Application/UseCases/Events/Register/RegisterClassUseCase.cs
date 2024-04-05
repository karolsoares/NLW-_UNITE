using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.Register
{
    public class RegisterClassUseCases 
    {
        public ResponseRegisteredEventJson Execute(RequestEventJson request)
        {
            Validate(request);

            var dbContext = new PassInDBContext();

            var entity = new Infrastructure.Entities.Event
            {
                Title = request.Title,
                Details = request.Details,
                Maximun_Attendees = request.MaximumAttendees,
                Slug = request.Title.ToLower().Replace("", "-"),

            };

            dbContext.Events.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredEventJson
            {
                Id = entity.Id
            };
        }

        private void Validate(RequestEventJson request)
        {
            if (request.MaximumAttendees <= 0)
            {
                throw new PassInExeption("The Maximum attendes is invalid");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new PassInExeption("The title is invalid");
            }

            if (string.IsNullOrWhiteSpace(request.Details))
            {
                throw new PassInExeption("The details is invalid");
            }
        }
    }
}
