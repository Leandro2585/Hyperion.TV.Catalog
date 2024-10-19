using Hyperion.TV.Catalog.Domain.Exceptions;
using System.ComponentModel;

namespace Hyperion.TV.Catalog.Domain.Validation;
public static class DomainValidation
{
    public static void NotNull(object? target, string fieldName)
    {
        if (target is null)
        {
            throw new EntityValidationException($"{fieldName} should not be null");
        }
        return;
    }

    public static void NotNullOrEmpty(string? target, string fieldName)
    {
        if (String.IsNullOrWhiteSpace(target))
        {
            throw new EntityValidationException($"{fieldName} should not be null or empty");
        }
        return;
    }

    public static void MinLength(string target, int minLength, string fieldName)
    {
        if (target.Length < minLength)
            throw new EntityValidationException($"{fieldName} should not be less than {minLength} characters long");
    }

    public static void MaxLength(string target, int maxLength, string fieldName)
    {
        if (target.Length > maxLength)
            throw new EntityValidationException($"{fieldName} should not be greater than {maxLength} characters long");
    }

    
}
