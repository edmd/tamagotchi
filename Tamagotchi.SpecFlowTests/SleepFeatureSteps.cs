using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Tamagotchi.SpecFlowTests
{
    [Binding]
    public class SleepFeatureSteps
    {
        Tamagotchi tamagotchi;

        [Given(@"A tired Tamagotchi needs to sleep")]
        public void GivenATiredTamagotchiNeedsToSleep()
        {
            tamagotchi = new Tamagotchi();
        }
        
        [When(@"I make the Tamagotchi go to sleep")]
        public void WhenIMakeTheTamagotchiGoToSleep()
        {
            tamagotchi.Sleep(DefaultValues.MaxValue);
        }
        
        [Then(@"the result should be a rested Tamagotchi")]
        public void ThenTheResultShouldBeARestedTamagotchi()
        {
            Assert.AreEqual(tamagotchi.Tiredness, DefaultValues.MinValue);
        }
    }
}
