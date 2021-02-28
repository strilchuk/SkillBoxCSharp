using System;
using NUnit.Framework;
using Example_005;

namespace Lesson05Test
{
    [TestFixture]
    public class Lesson05StringUtilsTest
    {
        [TestCase(
            TestName = "TC-0012",
            Description = "Получить самое короткое слово в тексте"
        )]
        public void GetShortestWordsTest()
        {
            var text = "ББ ВВВ ГГГГ, А ДДДД  ДД. Е ЖЖ ЗЗЗ";
            var word = UtilsString.GetShortestWord(text);
            Assert.That(word, Is.EqualTo("А"));
            
            text = "";
            word = UtilsString.GetShortestWord(text);
            Assert.That(word, Is.EqualTo(""));
        }
        
        [TestCase(
            TestName = "TC-0013",
            Description = "Получить самые длинные слова в тексте"
        )]
        public void GetLongestWordsTest()
        {
            var text = "ББ ВВВ ГГГГ, А ДДДД  ДД. Е  ЛЛЛЛ ЖЖ ЗЗЗ";
            var expectedArr = new[] {"ГГГГ", "ДДДД", "ЛЛЛЛ"};
            var wordsArr = UtilsString.GetLongestWords(text);
            Assert.That(wordsArr, Is.EqualTo(expectedArr));
            
            text = "";
            wordsArr = UtilsString.GetLongestWords(text);
            Assert.That(wordsArr, Is.Empty);
        }        
        
        [TestCase(
            TestName = "TC-0013",
            Description = "Получить самые длинные слова в тексте"
        )]
        public void GroupTextByCharsTest()
        {
            var text = "ПППОООГГГООООДДДААА";
            var expectedText = "ПОГОДА";
            var actualText = UtilsString.GroupTextByChars(text);
            Assert.That(expectedText, Is.EqualTo(actualText));
            
            text = "Ххххоооорррооошшшиий деееннннь";
            expectedText = "хороший день";
            actualText = UtilsString.GroupTextByChars(text);
            Assert.That(expectedText, Is.EqualTo(actualText));
            
            text = "     ";
            expectedText = " ";
            actualText = UtilsString.GroupTextByChars(text);
            Assert.That(expectedText, Is.EqualTo(actualText));
            
            text = "";
            expectedText = "";
            actualText = UtilsString.GroupTextByChars(text);
            Assert.That(expectedText, Is.EqualTo(actualText));            
        }          
    }
}