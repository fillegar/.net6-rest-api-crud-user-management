using Microsoft.EntityFrameworkCore;
using User.Core.Model;

namespace User.Repository
{
    public class UserInfoRepository
    {
        private readonly UserInfoDbContext _context;
        public UserInfoRepository(UserInfoDbContext context)
        {
            _context = context;
        }
        

        public List<UserInfo> Get()
        {
            try
            {
                return _context.UserInfos.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Add(UserInfo userInfo)
        {
            try
            {
                _context.UserInfos.Add(userInfo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Remove(UserInfo userInfo)
        {
            try
            {
                _context.UserInfos.Remove(userInfo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Update(UserInfo userInfo)
        {
            try
            {
                _context.Entry(userInfo).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
