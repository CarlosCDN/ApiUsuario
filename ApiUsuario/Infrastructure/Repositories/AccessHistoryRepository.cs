﻿using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories;

public class AccessHistoryRepository : IAccessHistoryRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();

    //Adiciona Usuario no banco
    public bool AddAccess(int userId, string userName)
    {
        bool sucess = true;
        if (userId == 0) sucess = false;

        var accessHistory = new AccessHistory(userId, userName, sucess);
        _context.AccessHistories.Add(accessHistory);
        _context.SaveChanges();
        return sucess;
    }
}
