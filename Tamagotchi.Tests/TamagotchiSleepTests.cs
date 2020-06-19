using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tamagotchi.Tests
{
    public class TamagotchiSleepTests
    {
        private Mock<ITamagotchi> _tamagotchiMock;
        private ITamagotchi _tamagotchiObject;

        [SetUp]
        public void TestSetup()
        {
            _tamagotchiMock = new Mock<ITamagotchi>();
            _tamagotchiMock.Setup(x => x.Sleep(It.IsAny<int>())).Returns(true);
            _tamagotchiMock.Setup(x => x.Sleep(DefaultValues.MaxValue)).Returns(false);
            _tamagotchiMock.Setup(x => x.Tiredness == 50);
            _tamagotchiObject = _tamagotchiMock.Object;
        }

        [Test]
        public void TestTamagotchiSleepUnsuccessful()
        {
            _tamagotchiObject.Tiredness.Should().Be(50);
            _tamagotchiObject.Sleep(DefaultValues.MaxValue).Should().BeFalse();
        }

        [Test]
        public void TestTamagotchiSleepSuccessful()
        {
            _tamagotchiObject.Tiredness.Should().Be(50);
            _tamagotchiObject.Sleep(DefaultValues.Sleep).Should().BeTrue();
        }
    }
}
