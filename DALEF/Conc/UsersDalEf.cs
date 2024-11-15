using AutoMapper;
using DAL.Repository;
using DALEF.Ct;
using DALEF.Models;
using DTO.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DALEF.Conc
{
    public class UsersDalEf : IUsers
    {
        private readonly ImdbContext _context;
        private readonly IMapper _mapper;

        public UsersDalEf(ImdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Users Create(Users Users)
        {
            var tblUsers = _mapper.Map<TblUsers>(Users);
            _context.Users.Add(tblUsers);
            _context.SaveChanges();

            Users.id = tblUsers.id;
            return Users;
        }

        public List<Users> GetAll()
        {
            var tblUsers = _context.Users.ToList();
            return _mapper.Map<List<Users>>(tblUsers);
        }

        public Users GetById(int id)
        {
            var tblManager = _context.Users.FirstOrDefault(e => e.id == id);
            return _mapper.Map<Users>(tblManager);
        }

        public Users Update(int id, Users Users)
        {
            var tblManager = _context.Users.FirstOrDefault(e => e.id == id);
            if (tblManager != null)
            {
                _mapper.Map(Users, tblManager);
                _context.SaveChanges();
            }
            return Users;
        }

        public Users Delete(int id)
        {
            var tblManager = _context.Users.FirstOrDefault(e => e.id == id);
            if (tblManager != null)
            {
                _context.Users.Remove(tblManager);
                _context.SaveChanges();
            }
            return _mapper.Map<Users>(tblManager);
        }

        public Users login(string login, string password)
        {
            var manager = _context.Users.FirstOrDefault(m => m.login == login);

            if (manager == null)
            {
                return null;
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, manager.hashed_password);
            if (isPasswordValid)
            {
                return _mapper.Map<Users>(manager);
            }
            return null;
        }
    }
}
