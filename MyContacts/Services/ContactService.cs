using MyContacts.Models;

namespace MyContacts.Services;

public class ContactService
{
    private readonly List<Contact> _contacts =
    [
        new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123456789"
        },
        new()
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane@example.com",
            Phone = "987654321"
        }
    ];

    public List<Contact> GetAll()
    {
        return _contacts;
    }
}