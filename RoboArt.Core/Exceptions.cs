using System;

namespace RoboArt.Core;

public class EmptyNameException(string namePart)
    : Exception($"{namePart} не должно(а) быть пустым(ой)")
{
    public static void ThrowIfEmptyName(string? name, string namePart = "Имя")
    {
        try
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
        }
        catch (Exception)
        {
            throw new EmptyNameException(namePart);
        }
    }
}

public class InvalidNameException(string namePart) 
    : Exception($"{namePart} должно(а) содержать только буквы кириллицы")
{
    public static void ThrowIfInvalidName(string name, string namePart = "Имя")
    {
        if (!name.IsOnlyCyrillic()) 
            throw new InvalidNameException(namePart);
    }
}