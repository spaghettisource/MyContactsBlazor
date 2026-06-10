using MediatR;
using Microsoft.EntityFrameworkCore;
using MyContacts.Data;
using MyContacts.Models;

namespace MyContacts.Features.Contacts.GetContacts;

public class GetContactsQueryHandler
    : IRequestHandler<GetContactsQuery, List<Contact>>
{
    private readonly ContactDbContext _db;

    public GetContactsQueryHandler(ContactDbContext db)
    {
        _db = db;
    }

    public async Task<List<Contact>> Handle(
        GetContactsQuery request,
        CancellationToken cancellationToken)
    {
        return await _db.Contacts
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}