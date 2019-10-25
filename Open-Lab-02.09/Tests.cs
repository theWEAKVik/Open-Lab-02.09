using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_02._09
{
    [TestFixture]
    public class Tests
    {

        private Names names;

        private const int RandNameMinSize = 2;
        private const int RandNameMaxSize = 10;
        private const int RandSeed = 209209209;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init() => names = new Names();

        [TestCase("First", "Last", "Last, First")]
        [TestCase("John", "Doe", "Doe, John")]
        [TestCase("Mary", "Jane", "Jane, Mary")]
        [TestCaseSource(nameof(GetRandom))]
        public void ConcatNameTest(string firstName, string lastName, string expectedOutput) =>
            Assert.That(names.ConcatName(firstName, lastName), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arrs = new char[2][];

                for (var j = 0; j < 2; j++)
                {
                    arrs[j] = new char[random.Next(RandNameMinSize, RandNameMaxSize + 1)];

                    for (var k = 0; k < arrs[j].Length; k++)
                        arrs[j][k] = (char) random.Next(65, 91);
                }

                var fName = new string(arrs[0]);
                var lName = new string(arrs[1]);

                yield return new TestCaseData(fName, lName, $"{lName}, {fName}");
            }
        }

    }
}
