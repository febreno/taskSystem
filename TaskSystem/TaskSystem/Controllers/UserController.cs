using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers()
        {
            List<UserModel> users = await _userRepository.FindAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]//findById/{id}
        public async Task<ActionResult<UserModel>> FindById(int id)
        {
            UserModel model = await _userRepository.FindById(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel userModel)
        {
            UserModel model = await _userRepository.Add(userModel);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel model = await _userRepository.Update(userModel, id);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            bool model = await _userRepository.Delete(id);
            return Ok(model);
        }
    }
}
