using AutoMapper;
using DAL.Repository;
using DALEF.Ct;
using DALEF.Models;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Conc
{
    public class UsersDalEf : IUsers
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public UsersDalEf(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public Users Create(Users Users)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                Console.WriteLine(Users.name.ToString());
                var tblUsers = _mapper.Map<TblUsers>(Users);
                context.Users.Add(tblUsers);
                context.SaveChanges();

                Users.id = tblUsers.id;
                return Users;
            }
        }

        public List<Users> GetAll()
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblUsers = context.Users.ToList();
                return _mapper.Map<List<Users>>(tblUsers);
            }
        }



        public Users GetById(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Users.FirstOrDefault(e => e.id == id);
                return _mapper.Map<Users>(tblManager);
            }
        }

        public Users Update(int id, Users Users)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Users.FirstOrDefault(e => e.id == id);
                if (tblManager != null)
                {
                    _mapper.Map(Users, tblManager);
                    context.SaveChanges();
                }
                return Users;
            }
        }

        public Users Delete(int id)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var tblManager = context.Users.FirstOrDefault(e => e.id == id);
                if (tblManager != null)
                {
                    context.Users.Remove(tblManager);
                    context.SaveChanges();
                }
                return _mapper.Map<Users>(tblManager);
            }
        }

        public Users login(string login, string password)
        {
            using (var context = new ImdbContext(_connectionString))
            {
                var manager = context.Users.FirstOrDefault(m => m.login == login);

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
}
