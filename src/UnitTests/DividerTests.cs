using System;
using Xunit;
/*
    Facts are tests which are always true. They test invariant conditions.
    Theories are tests which are only true for a particular set of data. That simply means it expects input in the method.
*/
namespace UnitTests
{
    public class DividerTests
    {
        [Fact]
        public void WithArgumentTwo_ShouldReturnTrue() 
        {
            Assert.True(NummberHelper.IsEven(2));
        }

        [Fact]
        public void WithArgumentThree_ShouldReturnFalse() 
        {
            Assert.False(NummberHelper.IsEven(3));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        public void WithArgumentsFourSixAndEight_ShouldReturnTrue(int number) 
        {
            Assert.True(NummberHelper.IsEven(number));
        }
    }

    static class NummberHelper {
        public static bool IsEven(int arg1)
        {
            return arg1 % 2 == 0;
        }
    }
}
