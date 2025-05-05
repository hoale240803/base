using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VerticalSlice.API.Controllers;
using VerticalSlice.Domain;

namespace VerticalSlice.UnitTest
{
    public class UserTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly UserController _controller;

        public UserTest()
        {
            var userRepository = new UserRepository();
            var userService = new Mock<UserService>(userRepository);
            _controller = new UserController(userService.Object);
        }

        [Fact]
        public async Task GetUserProfileAsync_ReturnsOk_WhenQuerySucceeds()
        {
            // Arrange
            var userId = "123";
            var userRepoMock = new Mock<IUserRepository>();
            var sut = new UserService(userRepoMock.Object);


            // Act
            var result = await _controller.GetUserProfile(userId);

            // Assert
            //var okResult = Assert.IsAssignableFrom<IActionResult>(result);
            var okResult = result as OkObjectResult;
            var userProfile = okResult.Value as UserProfileModel;

            Assert.NotNull(okResult);
            userProfile.Name.Should().Be("name");

        }
    }
}

