using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create CategoryWwith Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Valid Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With Valid Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. To short, minimum 3 characteres.");
        }

        [Fact(DisplayName = "Create Category With Valid Name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create Category With Valid Name")]
        public void CreateCategory_WithNullNameValue_DomainExceptioInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    }
}
