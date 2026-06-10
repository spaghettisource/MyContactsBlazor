using MediatR;

namespace MyContacts.Features.Contacts;

public record UpdateContactCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone) : IRequest;