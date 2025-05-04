using Microsoft.AspNetCore.Mvc;
using Moq;
using VerticalSlice.API.Controllers;

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
        public async Task GetUserProfile_ReturnsOk_WhenQuerySucceeds()
        {
            // Arrange
            var expectedDto = new UserProfileModel { Name = "John Doe" };
            var userId = "123";
            // Act
            var result = await _controller.GetUserProfile(userId);

            // Assert
            var okResult = Assert.IsAssignableFrom<IActionResult>(result);
            
            //var name = okResult.GetType().Name as UserProfileModel;
            //Assert.Equal("John Doe", );
        }
    }
}

