using MediatR;

namespace MyContacts.Features.Contacts;

public record DeleteContactCommand(
    int Id) : IRequest;