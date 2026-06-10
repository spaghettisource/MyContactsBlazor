using MediatR;
using MyContacts.Models;

namespace MyContacts.Features.Contacts.GetContacts;

public record GetContactsQuery : IRequest<List<Contact>>;