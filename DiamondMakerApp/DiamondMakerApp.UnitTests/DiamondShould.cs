using DiamondMakerApp.Extensions;
using DiamondMakerApp.Model;
using System.Linq;
using Xunit;

namespace DiamondMakerApp.UnitTests
{
    public class DiamondShould
    {
        private readonly Diamond diamond;
        public DiamondShould()
        {
            diamond = new Diamond();
        }

        [Fact]
        public void Output_A_Given_A_Is_Passed()
        {
            // Act
            diamond.Create("A");

            // Assert
            Assert.Equal("A", diamond.Rows().First());
        }

        [Fact]
        public void Output_A_On_First_Line_Given_B_Is_Passed()
        {
            // Act
            diamond.Create("B");

            // Assert
            Assert.Contains("A", diamond.Rows().First());
        }

        [Fact]
        public void Output_3_Lines_Given_B_Is_Passed()
        {
            // Act
            diamond.Create("B");

            // Assert
            Assert.Equal(3, diamond.Rows().Count);
        }

        [Theory]
        [InlineData("B", "B B")]
        [InlineData("C", "C   C")]
        public void Ouput_Correct_Spacing_Between_Input_Character(string inputCharacter, string expectedOutput)
        {
            // Arrange
            var numberOfElementsToSkip = DiamondExtension.Alphabets.IndexOf(inputCharacter);

            // Act
            diamond.Create(inputCharacter);

            // Assert
            Assert.Equal(expectedOutput, diamond.Rows().Skip(numberOfElementsToSkip).First());
            Assert.Equal(expectedOutput, diamond.Rows().SkipLast(numberOfElementsToSkip).Last());
        }

        [Fact]
        public void Add_Correct_Padding_Around_Characters_When_C_Is_Passed()
        {
            // Act
            diamond.Create("C");

            // Assert
            Assert.Equal("  A  ", diamond.Rows().First());
            Assert.Equal(" B B ", diamond.Rows().Skip(1).First());
        }

        [Fact]
        public void Output_A_On_Last_Line_Given_C_Is_Passed()
        {
            // Act
            diamond.Create("C");

            // Assert
            Assert.Contains("A", diamond.Rows().Last());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("$")]
        public void Return_Empty_Diamond_Given_Invalid_Character_Is_Passed(string invalidCharacter)
        {
            // Act
            diamond.Create(invalidCharacter);

            // Assert
            Assert.Empty(diamond.Rows());
        }
    }
}
