using System;

namespace RoboArt.Core;

public class Person
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public required string LastName
    {
        get;
        init
        {
            EmptyNameException.ThrowIfEmptyName(value, "Фамилия");
            
            var lastName = value.Trim();
            InvalidNameException.ThrowIfInvalidName(lastName, "Фамилия");
            
            field = lastName;
        }
    }
    public required string FirstName
    {
        get;
        init
        {
            EmptyNameException.ThrowIfEmptyName(value, "Имя");
            
            var firstName = value.Trim();
            InvalidNameException.ThrowIfInvalidName(firstName, "Имя");
            
            field = firstName;
        }
    }

    public string? Patronymic
    {
        get;
        init
        {
            if (value is null) return;

            var patronymic = value.Trim();
            if (string.IsNullOrEmpty(patronymic)) return;

            InvalidNameException.ThrowIfInvalidName(patronymic, "Отчество");
            field = patronymic;
        }
    } = null;
}