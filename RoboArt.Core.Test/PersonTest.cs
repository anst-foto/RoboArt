using System;

using Xunit;

namespace RoboArt.Core.Test;

public class PersonTest
{
    #region Id

    [Fact]
    public void Constructor_SetsIdAsNonEmptyGuid()
    {
        var person = new Person
        {
            LastName = "Иванов",
            FirstName = "Иван"
        };

        Assert.NotEqual(Guid.Empty, person.Id);
    }

    #endregion

    #region LastName

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void LastName_SetNullWhiteSpace_ThrowsEmptyNameException(string lastName)
    {
        var ex = Assert.Throws<EmptyNameException>(() => new Person
        {
            LastName = lastName,
            FirstName = "Иван"
        });
        Assert.Contains("Фамилия", ex.Message);
    }

    [Fact]
    public void LastName_ValidCyrillicValue_SetsTrimmedValue()
    {
        var person = new Person
        {
            LastName = "  Петров  ",
            FirstName = "Алексей"
        };
        
        Assert.Equal("Петров", person.LastName);
    }

    [Theory]
    [InlineData("Иванов123")]
    [InlineData("Ivanov")]
    public void LastName_SetInvalidName_ThrowsInvalidNameException(string lastName)
    {
        var ex = Assert.Throws<InvalidNameException>(() => new Person
        {
            LastName = lastName,
            FirstName = "Иван"
        });
        Assert.Contains("Фамилия", ex.Message);
    }

    #endregion

    #region FirstName
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void FirstName_SetNullWhiteSpace_ThrowsArgumentException(string firstName)
    {
        var ex = Assert.Throws<EmptyNameException>(() => new Person
        {
            LastName = "Иванов",
            FirstName = firstName
        });
        Assert.Contains("Имя", ex.Message);
    }

    [Fact]
    public void FirstName_ValidCyrillicValue_SetsTrimmedValue()
    {
        var person = new Person
        {
            LastName = "Сидоров",
            FirstName = "  Олег  "
        };
        
        Assert.Equal("Олег", person.FirstName);
    }
    
    [Theory]
    [InlineData("Иван123")]
    [InlineData("Ivan")]
    public void FirstName_SetInvalidName_ThrowsInvalidNameException(string firstName)
    {
        var ex = Assert.Throws<InvalidNameException>(() => new Person
        {
            LastName = "Иванов",
            FirstName = firstName
        });
        Assert.Contains("Имя", ex.Message);
    }

    #endregion

    #region Patronymic
    
    [Fact]
    public void Patronymic_Null_DoesNotThrow()
    {
        var person = new Person
        {
            LastName = "Иванов",
            FirstName = "Иван"
            // Patronymic остается null
        };

        Assert.Null(person.Patronymic);
    }

    [Fact]
    public void Patronymic_ValidValue_SetsValue()
    {
        var person = new Person
        {
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = " Петрович "
        };
        
        Assert.Equal("Петрович", person.Patronymic);
    }

    [Theory]
    [InlineData("Иванович123")]
    [InlineData("Ivanovich")]
    public void Patronymic_SetInvalidName_ThrowsInvalidNameException(string patronimyc)
    {
        var ex = Assert.Throws<InvalidNameException>(() => new Person
        {
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = patronimyc
        });
        Assert.Contains("Отчество", ex.Message);
    }
    
    #endregion
}