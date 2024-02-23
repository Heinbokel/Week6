using Microsoft.AspNetCore.Mvc;
using Week6.models;
using Week6.repositories;

namespace Week6.Controllers {

    [ApiController]
    public class UsersController: ControllerBase {

        private IUsersRepository _usersRepository;
        private ITagsRepository _tagsRepository;

        public UsersController(IUsersRepository usersRepository, 
            ITagsRepository tagsRepository) {
            this._usersRepository = usersRepository;
            this._tagsRepository = tagsRepository;
        }

        [HttpGet("users", Name = "GetUsers")]
        public List<User> GetUsers() {
            List<User> users = this._usersRepository.GetUsers();
            foreach(User user in users) {
                user.UserTags = this._tagsRepository.GetTagsByUserId(user.UserId);
            }
            return users;
        }

        [HttpGet("users/{userId}", Name = "GetUserByUserId")]
        public User GetUserByUserId(int userId, [FromQuery] string email) {
            // Call for user by user id
            return new User {
                UserId = userId,
                Email = email
             };
        }

    }

}