using MediatR;
using MyContacts.Data;

namespace MyContacts.Features.Contacts;

public class DeleteContactCommandHandler
    : IRequestHandler<DeleteContactCommand>
{
    private readonly ContactDbContext _db;

    public DeleteContactCommandHandler(ContactDbContext db)
    {
        _db = db;
    }

    public async Task Handle(
        DeleteContactCommand request,
        CancellationToken cancellationToken)
    {
        var contact = await _db.Contacts.FindAsync(
            [request.Id],
            cancellationToken);

        if (contact is null)
        {
            return;
        }

        _db.Contacts.Remove(contact);

        await _db.SaveChangesAsync(cancellationToken);
    }
}