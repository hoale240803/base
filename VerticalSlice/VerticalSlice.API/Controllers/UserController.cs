using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSlice.API.Controllers
{
    public class GetUserProfileValidator : AbstractValidator<UserProfileModel>
    {
        public GetUserProfileValidator(string id)
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUserName")]
        public async Task<IActionResult> GetUserProfile([FromQuery] string id)
        {
            var result = await _userService.GetUserProfileAsync(id);

            return Ok(result);
        }
    }

    public interface IUserService
    {
        Task<UserProfileModel> GetUserProfileAsync(string id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserProfileModel> GetUserProfileAsync(string id)
        {
            return _userRepository.GetProfileAsync(id);
        }
    }

    public class UserRepository : IUserRepository
    {
        public Task<UserProfileModel> GetProfileAsync(string id)
        {
            return Task.FromResult(new UserProfileModel { Name = "name" });
        }
    }

    public interface IUserRepository
    {
        Task<UserProfileModel> GetProfileAsync(string id);
    }

    public class UserProfileModel
    {
        public string Id {  get; set; }
        public string Name { get; set; }
    }

    public class UserEntity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }


    public static class ServiceCollectionRegister
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
