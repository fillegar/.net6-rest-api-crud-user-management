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

        public async Task<UserInfo> getUserInfoByEmail(string email)
        {
            try
            {
                return await _context.UserInfos.Where(item => item.Email.Equals(email)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public void saveChanges()
        {
            try
            {
                _context.SaveChanges();
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

        public async Task Update(UserInfo userInfo)
        {
            try
            {
                _context.Entry(userInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
