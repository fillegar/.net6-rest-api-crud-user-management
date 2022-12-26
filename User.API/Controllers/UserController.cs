using Microsoft.AspNetCore.Mvc;
using User.Core.Model;
using User.Service;

namespace User.API.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly UserInfoService _userInfoService;

        public UserController(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public List<UserInfo> getUserInfos()
        {
            return _userInfoService.getUserInfos();
        }

        [HttpPost]
        public String addUserInfo([FromBody] UserInfo userInfo)
        {
            _userInfoService.addUserInfo(userInfo);
            return "User created successfully!";
        }

        [HttpPut]
        public String updateUserInfo([FromBody] UserInfo userInfo)
        {
            _userInfoService.updateUserInfo(userInfo);
            return "User updated successfully!";
        }

        [HttpDelete]
        public String deleteUserInfo([FromBody] UserInfo userInfo)
        {
            _userInfoService.removeUserInfo(userInfo);
            return "User removed successfully!";
        }
    }
}
