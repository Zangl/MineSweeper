using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper.Tests
{
    public class BoardTests
    {
        private Mock<IPlayer> playerMock;

        [SetUp]
        public void Setup()
        {
            playerMock = new Mock<IPlayer>();

        }

        [Test]
        public void AfterInitHasPlayerTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);

            //Assert
            Assert.That(sut.Player, Is.Not.Null);
        }
        
        [Test]
        public void AfterInitHasTilesTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);

            //Assert
            Assert.That(sut.Tiles, Is.Not.Null);
        }

        [Test]
        public void AfterInitHasMinesTest()
        {
            //Arrange
            var sut = new Board(playerMock.Object);

            //Act
            sut.Initialise(8, 8, 10);
            var mineCount = 0;
            foreach (var item in sut.Tiles)
            {
                if (item.HasMine)
                {
                    mineCount++;
                }
            }

            //Assert
            Assert.That(10, Is.EqualTo(mineCount));
        }

        [Test]
        public void PlayerInitialisedRowTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);

            //Assert
            Assert.That(sut.PlayerY, Is.GreaterThanOrEqualTo(0));
            Assert.That(sut.PlayerY, Is.LessThanOrEqualTo(7));
        }

        [Test]
        public void PlayerInitialisedColumnTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);

            //Assert
            Assert.That(0, Is.EqualTo(sut.PlayerX));
        }

        [Test]
        public void EdgeDetectionTopTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 0;
            sut.PlayerY = 7;
            sut.MovePlayer(Direction.Up);

            //Assert
            Assert.That(7, Is.EqualTo(sut.PlayerY));
        }

        [Test]
        public void EdgeDetectionBottomTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 0;
            sut.PlayerY = 0;
            sut.MovePlayer(Direction.Down);

            //Assert
            Assert.That(0, Is.EqualTo(sut.PlayerY));
        }

        [Test]
        public void EdgeDetectionLeftTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 0;
            sut.PlayerY = 0;
            sut.MovePlayer(Direction.Left);

            //Assert
            Assert.That(0, Is.EqualTo(sut.PlayerY));
        }

        [Test]
        public void EdgeDetectionRightTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 7;
            sut.PlayerY = 0;
            sut.MovePlayer(Direction.Right);

            //Assert
            Assert.That(7, Is.EqualTo(sut.PlayerX));
        }

        [Test]
        public void StatusStringFormatTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 0;
            sut.PlayerY = 0;
            sut.MovePlayer(Direction.Left);

            //Assert
            Assert.That(sut.StatusText, Is.EqualTo("Player position is (A0) Lives = 3 Moves Taken = 1"));
        }

        [Test]
        public void MovedPlayerPositionTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);
            sut.PlayerX = 4;
            sut.PlayerY = 4;
            sut.MovePlayer(Direction.Right);

            //Assert
            Assert.That(5, Is.EqualTo(sut.PlayerX));
        }


    }
}
