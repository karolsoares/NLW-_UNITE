using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Events.GetById
{
    public class GetByIdUseCase
    {
        public ResponseEventJson Execute(Guid id)
        {
            var dbContext = new PassInDBContext();
            var entity = dbContext.Events.Find(id);
            if (entity is null)
                throw new PassInExeption("Ah event with thus id dont exist.");

            return new ResponseEventJson
            {
                Id = entity.Id,
                Title = entity.Title,
                Details = entity.Details,
                MaximumAttendees = entity.Maximun_Attendees,
                AttendeesAmount = -1
            };
        }
    }
}
