using DockerizedCrud.Controllers;
using DockerizedCrud.Interfaces;
using DockerizedCrud.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DockerizedCrud.Tests
{
    public class GameControllerTests
    {
        private GameController _gameController;
        private IGameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = A.Fake<GameService>();
            _gameController = new GameController(_gameService);
        }

        [Test]
        public async Task ShouldReturnOk()
        {
            var result = (await _gameController.Get()) as OkObjectResult;
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task ShouldCallGameServiceGetAll()
        {
            var result = await _gameController.Get();
            A.CallTo(() => _gameService.GetAll()).MustHaveHappenedOnceExactly();
        }
    }
}