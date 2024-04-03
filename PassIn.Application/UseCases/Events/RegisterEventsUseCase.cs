using PassIn.Communication.Requests;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events;
public class RegisterEventsUseCase
{
    public void Execute (RequestEventJson request)
    {
        Validate(request);
        var dbContext = new PassInDbContext();
        var entity = new Event

        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "-"),
        };

        dbContext.Events.Add(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestEventJson request)
    {
        if(request.MaximumAttendees <= 0)
        {
            throw new PassInException("Maximum attendes is invalid");
        }

        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new PassInException("Title can not be null");
        }
        
        
        if(string.IsNullOrWhiteSpace(request.Details))
        {
            throw new PassInException("Details can not be null");
        }
    }
}
