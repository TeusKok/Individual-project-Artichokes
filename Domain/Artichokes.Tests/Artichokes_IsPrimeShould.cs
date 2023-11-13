using Xunit;
using Artichokes;

namespace Prime.UnitTests.Services
{
    public class Artichokes_IsPrimeShould
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new Artichokee();
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}