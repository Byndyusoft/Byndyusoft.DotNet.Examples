using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Moq;
using NUnit.Framework;
using StaticWrapperTestExample.Wrappers.Interfaces;

namespace StaticWrapperTestExample.Tests
{
    [TestFixture]
    public class EnumerationFieldSeparatorValidatorTests
    {
        [SetUp]
        public void SetUp()
        {
            _specialChars = new[] {'u', 'v', 'w', 'x', 'y', 'z'};

            _charMock = new Mock<IChar>(MockBehavior.Strict);
            _charMock
                .Setup(c => c.IsControl(It.Is<char>(ch => _specialChars.Any(x => x == ch))))
                .Returns(true);
            _charMock
                .Setup(c => c.IsControl(It.Is<char>(ch => _specialChars.Any(x => x == ch) == false)))
                .Returns(false);

            _separatorValidator = new EnumerationFieldSeparatorValidator(_charMock.Object);
        }

        [NotNull] private EnumerationFieldSeparatorValidator? _separatorValidator;
        [NotNull] private Mock<IChar>? _charMock;
        [NotNull] private char[]? _specialChars;

        [TestCase("qwe 77789asdf", "qe 77789asdf")]
        [TestCase("xcwygvf", "cgf")]
        public void ValidatorRemovesSpecialChars(string input, string expectedOutput)
        {
            var result = _separatorValidator.Validate(input);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ValidatorThrowsExceptionIfInputIsEmpty()
        {
            var exception = Assert.Throws<Exception>(() => _separatorValidator.Validate(""));

            Assert.That(exception!.Message, Is.EqualTo("EnumerationFieldSeparatorValidator.ResultIsEmpty"));
        }

        [Test]
        public void ValidatorThrowsExceptionIfInputContainsOnlySpecialChars()
        {
            var input = GenerateSpecialCharsString();

            var exception = Assert.Throws<Exception>(() => _separatorValidator.Validate(input));

            Assert.That(exception!.Message, Is.EqualTo("EnumerationFieldSeparatorValidator.ResultIsEmpty"));
        }

        private string GenerateSpecialCharsString()
        {
            var rng = new Random();
            var length = rng.Next(1, 128);
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = _specialChars[rng.Next(0, _specialChars.Length)];
            return new string(chars);
        }
    }
}