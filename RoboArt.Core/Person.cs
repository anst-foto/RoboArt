using System;

namespace RoboArt.Core;

/// <summary>
/// Представляет информацию о человеке с уникальным идентификатором и проверенными персональными данными.
/// </summary>
/// <remarks>
/// Фамилия и имя обязательны и проходят валидацию (не пустые, допустимые символы).
/// Отчество необязательно; если указано, также проверяется.
/// </remarks>
public class Person
{
    /// <summary>
    /// Уникальный идентификатор человека.
    /// </summary>
    /// <value>GUID версии 7, создаётся автоматически при создании объекта.</value>
    public Guid Id { get; init; } = Guid.CreateVersion7();

    /// <summary>
    /// Фамилия человека.
    /// </summary>
    /// <value>Фамилия после обрезки пробелов и проверки.</value>
    /// <exception cref="EmptyNameException">Выбрасывается, если значение равно null, пусто или состоит только из пробелов.</exception>
    /// <exception cref="InvalidNameException">Выбрасывается, если имя содержит недопустимые символы (цифры, спецсимволы и т.п.).</exception>
    /// <remarks>
    /// Сеттер обрезает пробелы, проверяет на пустоту и валидирует допустимые символы.
    /// </remarks>
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

    /// <summary>
    /// Имя человека.
    /// </summary>
    /// <value>Имя после обрезки пробелов и проверки.</value>
    /// <exception cref="EmptyNameException">Выбрасывается, если значение равно null, пусто или состоит только из пробелов.</exception>
    /// <exception cref="InvalidNameException">Выбрасывается, если имя содержит недопустимые символы.</exception>
    /// <remarks>
    /// Сеттер обрезает пробелы, проверяет на пустоту и валидирует допустимые символы.
    /// </remarks>
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

    /// <summary>
    /// Отчество человека (при наличии).
    /// </summary>
    /// <value>Отчество после обрезки пробелов и проверки, либо <c>null</c>, если не указано или пустое.</value>
    /// <exception cref="InvalidNameException">Выбрасывается, если указанное (не пустое) значение содержит недопустимые символы.</exception>
    /// <remarks>
    /// Сеттер воспринимает <c>null</c> или строку из пробелов как отсутствие отчества.
    /// Если передано непустое значение, оно обрезается и валидируется.
    /// Исключение не выбрасывается при <c>null</c> или пустом значении.
    /// </remarks>
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