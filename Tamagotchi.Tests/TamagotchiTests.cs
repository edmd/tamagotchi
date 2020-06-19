using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.Tests
{
    [TestFixture]
    public class TamagotchiTests
    {
        private ITamagotchi _tamagotchi;

        [Test]
        public void TestSetupOfDefaultTamagotchi()
        {
            _tamagotchi = new Tamagotchi();

            Assert.IsTrue(_tamagotchi.Happiness == DefaultValues.MaxValue);
            Assert.IsTrue(_tamagotchi.Tiredness == DefaultValues.MinValue);
            Assert.IsTrue(_tamagotchi.Hungriness == DefaultValues.MaxValue);
            Assert.IsTrue(_tamagotchi.Fullness == DefaultValues.MinValue);
        }

        [Test]
        public void TestSetupOfNewTamagotchi()
        {
            _tamagotchi = new Tamagotchi(20, 20, 20, 20);

            Assert.IsTrue(_tamagotchi.Happiness == 20);
            Assert.IsTrue(_tamagotchi.Tiredness == 20);
            Assert.IsTrue(_tamagotchi.Hungriness == 20);
            Assert.IsTrue(_tamagotchi.Fullness == 20);
        }

        [Test]
        public void TestHealthyTamagotchiInterval()
        {
            _tamagotchi = new Tamagotchi(DefaultValues.MaxValue, DefaultValues.MinValue, DefaultValues.MinValue, DefaultValues.MinValue);
            _tamagotchi.Interval();

            Assert.IsTrue(_tamagotchi.Happiness == DefaultValues.MaxValue - 1);
            Assert.IsTrue(_tamagotchi.Tiredness == DefaultValues.MinValue + 1);
            Assert.IsTrue(_tamagotchi.Hungriness == DefaultValues.MinValue + 1);
            Assert.IsTrue(_tamagotchi.Fullness == DefaultValues.MinValue);
        }

        [Test]
        public void TestDeadTamagotchiInterval()
        {
            _tamagotchi = new Tamagotchi(DefaultValues.MinValue, DefaultValues.MaxValue, DefaultValues.MaxValue, DefaultValues.MaxValue);
            _tamagotchi.Interval();

            Assert.IsTrue(_tamagotchi.Happiness == DefaultValues.MinValue);
            Assert.IsTrue(_tamagotchi.Tiredness == DefaultValues.MaxValue);
            Assert.IsTrue(_tamagotchi.Hungriness == DefaultValues.MaxValue);
            Assert.IsTrue(_tamagotchi.Fullness == DefaultValues.MaxValue - 1);
        }

        [Test]
        public void TestTamagotchiFeed()
        {
            _tamagotchi = new Tamagotchi();
            _tamagotchi.Feed(DefaultValues.Feed);
            Assert.IsTrue(_tamagotchi.Hungriness == DefaultValues.MaxValue - DefaultValues.Feed);
            Assert.IsTrue(_tamagotchi.Fullness == DefaultValues.MinValue + DefaultValues.Feed);
        }

        [Test]
        public void TestTamagotchiSleep()
        {
            _tamagotchi = new Tamagotchi(DefaultValues.MinValue, DefaultValues.MaxValue, DefaultValues.MinValue, DefaultValues.MinValue);
            _tamagotchi.Sleep(DefaultValues.Sleep);

            Assert.IsTrue(_tamagotchi.Tiredness == DefaultValues.MaxValue - DefaultValues.Sleep);
        }

        [Test]
        public void TestTamagotchiPlay()
        {
            _tamagotchi = new Tamagotchi();
            _tamagotchi.Play(DefaultValues.Play);
            Assert.IsTrue(_tamagotchi.Happiness == DefaultValues.MaxValue);
            Assert.IsTrue(_tamagotchi.Tiredness == DefaultValues.MinValue + DefaultValues.Play);
        }

        [Test]
        public void TestTamagotchiPoo()
        {
            _tamagotchi = new Tamagotchi();
            Assert.IsFalse(_tamagotchi.Poop(DefaultValues.Poo));
            Assert.IsTrue(_tamagotchi.Fullness == DefaultValues.MinValue);
        }
    }
}