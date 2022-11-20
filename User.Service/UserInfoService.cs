using User.Core.Model;
using User.Repository;

namespace User.Service
{
    public class UserInfoService
    {
        private readonly UserInfoRepository _userInfoRepository;
        public UserInfoService(UserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public List<UserInfo> getUserInfos()
        {
            return _userInfoRepository.Get();
        }

        public void addUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Add(userInfo);
        }

        public void updateUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Update(userInfo);
        }

        public void removeUserInfo(UserInfo userInfo)
        {
            _userInfoRepository.Remove(userInfo);
        }
    }
}
