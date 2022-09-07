using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Tests.Unit
{
    public class ValueObject_EqualityTests
    {
        //TODO:Remove this test and implement correct tests

        //[Fact]
        //public void test1()
        //{
        //    var money1 = new Money(1000, "USD");
        //    var money2 = new Money(1000, "USD");

        //    money1.Equals(money2).Should().BeTrue();
        //    money1.GetHashCode().Should().Be(money2.GetHashCode());

        //    (money1 == money2).Should().Be(true);
        //    (money1 != money2).Should().Be(false);
        //}

        //private class Money : ValueObject
        //{
        //    public long Amount { get; private set; }
        //    public string Currency { get; private set; }
        //    public Money(long amount, string currency)
        //    {
        //        Amount = amount;
        //        Currency = currency;
        //    }
        //    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        //    {
        //        yield return Amount;
        //        yield return Currency;
        //    }
        //}
    }
}
