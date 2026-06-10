using MediatR;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Features.Contacts.CreateContact;

public class CreateContactCommandHandler
    : IRequestHandler<CreateContactCommand, int>
{
    private readonly ContactDbContext _db;

    public CreateContactCommandHandler(ContactDbContext db)
    {
        _db = db;
    }

    public async Task<int> Handle(
        CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };

        _db.Contacts.Add(contact);

        await _db.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}