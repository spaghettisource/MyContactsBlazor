using MediatR;
using Microsoft.AspNetCore.Components;
using MyContacts.Features.Contacts.CreateContact;
using MyContacts.Features.Contacts.GetContacts;
using MyContacts.Models;

namespace MyContacts.Components.Pages;

public partial class Contacts
{
    [Inject]
    public ISender Sender { get; set; } = null!;

    protected Contact newContact = new();

    protected List<Contact> ContactsList = [];

    protected override async Task OnInitializedAsync()
    {
        ContactsList = await Sender.Send(
            new GetContactsQuery());
    }
    
    protected async Task AddContact()
    {
        Console.WriteLine($"Adding contact");
        await Sender.Send(
            new CreateContactCommand(
                newContact.FirstName,
                newContact.LastName,
                newContact.Email,
                newContact.Phone));

        ContactsList = await Sender.Send(
            new GetContactsQuery());

        newContact = new Contact();
    }
}