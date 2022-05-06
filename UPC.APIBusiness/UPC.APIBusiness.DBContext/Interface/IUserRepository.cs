using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using UPC.APIBusiness.DBEntity.Model;

namespace DBContext
{
    public interface IUserRepository
    {
        List<EntityUser> GetUsers();
        EntityBaseResponse Login(EntityLogin login);
    }
}
