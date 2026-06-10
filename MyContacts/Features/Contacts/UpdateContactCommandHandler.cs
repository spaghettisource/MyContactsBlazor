using MediatR;
using MyContacts.Data;

namespace MyContacts.Features.Contacts;

public class UpdateContactCommandHandler
    : IRequestHandler<UpdateContactCommand>
{
    private readonly ContactDbContext _db;

    public UpdateContactCommandHandler(ContactDbContext db)
    {
        _db = db;
    }

    public async Task Handle(
        UpdateContactCommand request,
        CancellationToken cancellationToken)
    {
        var contact = await _db.Contacts.FindAsync(
            [request.Id],
            cancellationToken);

        if (contact is null)
        {
            return;
        }

        contact.FirstName = request.FirstName;
        contact.LastName = request.LastName;
        contact.Email = request.Email;
        contact.Phone = request.Phone;

        await _db.SaveChangesAsync(cancellationToken);
    }
}