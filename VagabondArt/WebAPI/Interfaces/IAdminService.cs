﻿namespace WebAPI.Interfaces
{
    public interface IAdminService
    {
        int Authenticate(string userName, string password);
    }
}
