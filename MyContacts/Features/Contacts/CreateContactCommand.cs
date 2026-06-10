using MediatR;

namespace MyContacts.Features.Contacts.CreateContact;

public record CreateContactCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone) : IRequest<int>;