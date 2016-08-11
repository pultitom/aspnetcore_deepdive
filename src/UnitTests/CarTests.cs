using System;
using Moq;
using Xunit;

namespace UnitTests
{
   public class HyundaiCarTests
   {
       [Fact]
       public void WithNumberLengthTen_ShouldGetNumberOfProvidedLength() 
       {
            var mockRandomizer = new Mock<IMyRandomizer>();
            mockRandomizer.Setup(m => m.GetRandomId(It.IsAny<int>())).Returns((int length) => { return length.ToString(); });

            var hyundai = new ProductForTesting(mockRandomizer.Object);

            Assert.Equal("10", hyundai.GetNumber(10));
       }
   }


    class ProductForTesting 
    {
        private IMyRandomizer _randomizer;

        private string _productNumber;

        public ProductForTesting (IMyRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public string GetNumber(int length) 
        {
            if (_productNumber == null)
            {
                _productNumber = _randomizer.GetRandomId(length);
            }
            
            return _productNumber;
        }
    }


    public interface IMyRandomizer
    {
        string GetRandomId(int length);
    }

    class MyRandomizer : IMyRandomizer
    {
        private string _availableSymbols = "abcdefgh1234567890";
        public string GetRandomId(int length) {
            System.Random random = new System.Random(10);
            string result = String.Empty;

            for (int i = 0; i < length; i++)
            {
                result += random.Next(_availableSymbols.Length-1);
            }
            
            return result;
        }
    }
}