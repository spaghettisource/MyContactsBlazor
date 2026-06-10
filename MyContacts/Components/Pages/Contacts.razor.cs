using MediatR;
using Microsoft.AspNetCore.Components;
using MyContacts.Features.Contacts;
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

    protected bool IsEditMode;

    protected bool ShowDeleteConfirmation;

    protected int SelectedContactId;

    protected override async Task OnInitializedAsync()
    {
        ContactsList = await Sender.Send(
            new GetContactsQuery());
    }

    protected async Task SaveContact()
    {
        if (IsEditMode)
        {
            await Sender.Send(
                new UpdateContactCommand(
                    newContact.Id,
                    newContact.FirstName,
                    newContact.LastName,
                    newContact.Email,
                    newContact.Phone));

            IsEditMode = false;
        }
        else
        {
            await Sender.Send(
                new CreateContactCommand(
                    newContact.FirstName,
                    newContact.LastName,
                    newContact.Email,
                    newContact.Phone));
        }

        ContactsList = await Sender.Send(
            new GetContactsQuery());

        newContact = new Contact();
    }

    protected void EditContact(Contact contact)
    {
        IsEditMode = true;

        newContact = new Contact
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Phone = contact.Phone
        };
    }

    protected void CancelEdit()
    {
        IsEditMode = false;

        newContact = new Contact();
    }

    protected void ConfirmDelete(int id)
    {
        SelectedContactId = id;

        ShowDeleteConfirmation = true;
    }

    protected void CancelDelete()
    {
        ShowDeleteConfirmation = false;
    }

    protected async Task DeleteSelectedContact()
    {
        await Sender.Send(
            new DeleteContactCommand(
                SelectedContactId));

        ContactsList = await Sender.Send(
            new GetContactsQuery());

        ShowDeleteConfirmation = false;
    }
}