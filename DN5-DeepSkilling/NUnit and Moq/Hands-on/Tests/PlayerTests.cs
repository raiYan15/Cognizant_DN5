using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace HandsOn.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _playerMapperMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _playerMapperMock = new Mock<IPlayerMapper>();
            _playerMapperMock.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
            _playerMapperMock.Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));
        }

        [TestCase("Sachin")]
        public void RegisterNewPlayer_ShouldReturnPlayerWithExpectedProperties(string name)
        {
            var player = Player.RegisterNewPlayer(name, _playerMapperMock.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(name));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
            _playerMapperMock.Verify(x => x.IsPlayerNameExistsInDb(name), Times.Once);
            _playerMapperMock.Verify(x => x.AddNewPlayerIntoDb(name), Times.Once);
        }

        [TestCase("")]
        [TestCase("   ")]
        public void RegisterNewPlayer_WithEmptyName_ShouldThrowArgumentException(string name)
        {
            Assert.That(() => Player.RegisterNewPlayer(name, _playerMapperMock.Object), Throws.ArgumentException.With.Message.Contain("Player name can’t be empty."));
        }
    }
}
