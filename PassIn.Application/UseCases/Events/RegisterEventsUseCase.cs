using PassIn.Communication.Requests;
using PassIn.Infrastructure;
using System.Net.Http.Headers;

namespace PassIn.Application.UseCases.Events;
public class RegisterEventsUseCase
{
    public void Execute (RequestEventJson request)
    {
        Validate(request);
        var dbContext = new PassInDbContext();
        var entity = new Infrastructure.Entities.Event
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
            throw new ArgumentException("Maximum attendes is ivanlid");
        }

        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title can not be null");
        }
        
        
        if(string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ArgumentException("Details can not be null");
        }
    }
}
