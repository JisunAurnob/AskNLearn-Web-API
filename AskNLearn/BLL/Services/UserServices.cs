﻿using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static TokenModel Authenticate(string username, string password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            var uType = DataAccessFactory.AuthDataAccess().GetUserType(username,password);

            if (data != null)
            {
                TokenModel tokenModel = new TokenModel()
                {
                    tid = data.tid,
                    uid = data.uid,
                    Token = data.Token,
                    CreatedAt = data.CreatedAt,
                    ExpiredAt = data.ExpiredAt,
                    userType = uType
                };

                return tokenModel;
            }
            return null;
        }
       
        public static bool InstructorIsAuthenticated(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return authCheck;
        }
        public static bool AdminIsAuthenticated(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAdminAuthenticated(token);
            return authCheck;
        }
        public static bool Logout(int uid)
        {
            var logout = DataAccessFactory.AuthDataAccess().Logout(uid);
            return logout;
        }
    }
}
