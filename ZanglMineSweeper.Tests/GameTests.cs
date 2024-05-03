using Moq;
using ZanglMineSweeper.Interfaces;

namespace ZanglMineSweeper.Tests
{
    public class GameTests
    {
        
        private Mock<IBoard> boardMock;

        [SetUp]
        public void Setup()
        {
            boardMock = new Mock<IBoard>();
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
            Assert.That(sut.StatusText, Is.EqualTo("Player position is (A0) Lives = 3 Moves Taken = 0"));
        }
    }
}