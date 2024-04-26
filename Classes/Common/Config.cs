using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR29.Classes.Common
{
    public class Config
    {
        public static string ConnectionConfig = "server=localhost;uid=root;pwd=;database=pcClub;";
        public static MySqlServerVersion Version = new MySqlServerVersion(new System.Version(8, 0, 11));
    }
}
