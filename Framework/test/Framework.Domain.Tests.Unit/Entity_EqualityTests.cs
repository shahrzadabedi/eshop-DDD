using System;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Tests.Unit
{
    public class Entity_EqualityTests
    {
        //TODO: complete & refine tests

        [Fact]
        public void entities_with_same_ids_are_equal()
        {
            var jack1 = new Customer(1);
            var jack2 = new Customer(1);

            jack1.Equals(jack2).Should().BeTrue();
        }

        [Fact]
        public void entities_with_same_ids_but_different_types_are_not_equal()
        {
            var jack = new Customer(1);
            var order = new Order(1);

            jack.Equals(order).Should().BeFalse();
        }

        [Fact]
        public void entities_are_not_equal_to_null()
        {
            var jack = new Customer(1);

            jack.Equals(null).Should().BeFalse();
        }

        private class Customer : Entity<long>
        {
            public Customer(long id)
            {
                this.Id = id;
            }
        }
        private class Order : Entity<long>
        {
            public Order(long id)
            {
                this.Id = id;
            }
        }
    }
}
