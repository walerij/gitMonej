using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using djMoney.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace djMoney.Models
{
    public class BaseConnect
    {
        public MySQL sql { get; private set; }

        public BaseConnect()
        {
            this.sql = new MySQL("localhost", "fformula_djmonej", "root", "");//инициализируем sql, заодно коннектимся к MySQL
        }
              

      


        
         



    }
}