using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using djMoney.Models;

namespace djMoney.Models
{
    public class BaseConnect
    {
        public MySQL sql { get; private set; }

        public BaseConnect()
        {
            this.sql = new MySQL("localhost", "djmoney", "root", "");//инициализируем sql, заодно коннектимся к MySQL

        }



    }
}