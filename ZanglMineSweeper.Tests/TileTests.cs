using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanglMineSweeper.Tests
{
    public class TileTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HasMineTest()
        {
            //Arrange
            var sut = new Tile(0,0,true);

            //Act

            //Assert
            Assert.IsTrue(sut.HasMine);
        }

        [Test]
        public void ToStringFormatTest()
        {
            //Arrange
            var sut = new Tile(0, 0, true);

            //Act
            sut.HasMine = true;

            //Assert
            Assert.That(sut.ToString(), Is.EqualTo("(A0)"));
        }
    }
}
