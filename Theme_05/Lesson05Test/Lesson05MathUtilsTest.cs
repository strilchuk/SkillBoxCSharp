using System;
using NUnit.Framework;
using Example_005;

namespace Lesson05Test
{
    [TestFixture]
    public class Lesson05MathUtilsTest
    {
        [TestCase(
            TestName = "TC-0014",
            Description = "Проверка последовательности на прогрессию"
        )]
        public void GetShortestWordsTest()
        {
            var aProgressionTrue  = new[] {2, 4, 6, 8};
            var aProgressionFalse = new[] {2, 5, 6, 8};
            var gProgressionTrue  = new[] {2, 4, 8, 16, 32, 64, 128, 256};
            var gProgressionFalse = new[] {2, 4, 16, 32};
            
            Assert.That((true, false), Is.EqualTo(UtilsMath.IsProgression(aProgressionTrue)));
            Assert.That((false, false), Is.EqualTo(UtilsMath.IsProgression(aProgressionFalse)));
            Assert.That((false, true), Is.EqualTo(UtilsMath.IsProgression(gProgressionTrue)));
            Assert.That((false, false), Is.EqualTo(UtilsMath.IsProgression(gProgressionFalse)));
        }
        
        [TestCase(
            TestName = "TC-0015",
            Description = "Проверка функции Аккермана"
        )]
        public void AccermanFunctionTest()
        {
            Assert.That(4, Is.EqualTo(UtilsMath.AccermanFunction(1, 2)));
            Assert.That(2, Is.EqualTo(UtilsMath.AccermanFunction(0, 1)));
            Assert.That(1, Is.EqualTo(UtilsMath.AccermanFunction(0, 0)));
            Assert.That(7, Is.EqualTo(UtilsMath.AccermanFunction(2, 2)));
        }        
    }
}