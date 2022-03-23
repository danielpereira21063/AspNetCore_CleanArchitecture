using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidaParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product name", "Product description", 9.99m, 99, "product image");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "Product description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }
    }
}
