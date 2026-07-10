using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using MagicFilesLib;

namespace HandsOn.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _directoryExplorerMock;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";
        private ICollection<string> _files;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryExplorerMock = new Mock<IDirectoryExplorer>();
            _files = new List<string> { _file1, _file2 };
            _directoryExplorerMock.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(_files);
        }

        [TestCase]
        public void GetFiles_ShouldReturnTwoFilesAndContainFileNames()
        {
            var result = _directoryExplorerMock.Object.GetFiles("any-path");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Does.Contain(_file1));
            Assert.That(result, Does.Contain(_file2));
        }
    }
}
