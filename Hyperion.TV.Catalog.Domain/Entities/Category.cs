﻿using Hyperion.TV.Catalog.Domain.Exceptions;
using Hyperion.TV.Catalog.Domain.SeedWork;

namespace Hyperion.TV.Catalog.Domain.Entities;

public class Category: AggregateRoot
{
    #region Properties

    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    #endregion

    #region Constructor

    public Category(string name, string description, bool isActive = true) : base()
    {
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = DateTime.Now;

        Validate();
    }

    #endregion

    #region Methods

    public void Update(string name, string? description = null)
    {
        Name = name;
        Description = description ?? Description;
        Validate();
    }

    public void Activate()
    {
        IsActive = true;
        Validate();
    }

    public void Deactivate()
    {
        IsActive = false;
        Validate();
    }

    #endregion

    #region Validation

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new EntityValidationException($"{nameof(Name)} should not be empty or null");
        if (Name.Length < 3)
            throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters long");
        if (Name.Length > 255)
            throw new EntityValidationException($"{nameof(Name)} should be less or equal 255 characters long");
        if (Description == null)
            throw new EntityValidationException($"{nameof(Description)} should not be empty or null");
        if (Description.Length > 10_000)
            throw new EntityValidationException($"{nameof(Description)} should be less or equal 10.000 characters long");
    }

    #endregion

}
