using System;

namespace ec.edu.monster.modelo
{
    public class AuthService
    {
        public bool Login(string user, string pass)
        {
            return user == "monster" && pass == "monster9";
        }
    }
}