﻿using DTO.Entity;

namespace DAL.Repository
{
    public interface IManagers
    {
        Managers login(string username, string password);
        List<Managers> GetAll();
        Managers GetById(int id);
        Managers Create(Managers managers);
        Managers Update(int id,Managers managers);
        Managers Delete(int id);
        

    }
}
