using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper.Tests
{
    public class PlayerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitialLiveCountTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);

            //Act
            sut.Initialise(8, 8, 10);

            //Assert
            Assert.That(3, Is.EqualTo(sut.Player.Lives));
        }

        [Test]
        public void CurrentTileAssignedTest()
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
            Assert.That(sut.Player.CurrentTile, Is.SameAs(sut.Tiles[0, 0]));
        }

        [Test]
        public void IsDeadTest()
        {
            //Arrange
            var player = new Player();
            var sut = new Board(player);
            sut.Initialise(8, 8, 10);
            sut.Tiles[1, 0].HasMine = true;
            sut.Tiles[2, 0].HasMine = true;
            sut.Tiles[3, 0].HasMine = true;

            //Act
            sut.PlayerX = 0;
            sut.PlayerY = 0;
            sut.MovePlayer(Direction.Right);
            sut.MovePlayer(Direction.Right);
            sut.MovePlayer(Direction.Right);

            //Assert
            Assert.IsTrue(sut.Player.IsDead);
        }

        [Test]
        public void StatusStringFormatTest()
        {
            //Arrange
            Player player = new Player();
            Board board = new Board(player);
            var sut = new Game(board);

            //Act
            sut.Initialise();
            player.CurrentTile = board.Tiles[0, 0];

            //Assert
            Assert.That(player.StatusText, Is.EqualTo("Lives = 3"));
        }
    }
}
