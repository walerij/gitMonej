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
              

        public Article[] art;


        /// <summary>
        /// выборка данных из таблицы историй
        /// </summary>
        /// <param name="query">текст запроса (обязательно SELECT)</param>
        /// <returns>в чем возвращать, я пока не определился, пока массив Article[], но думаю и о DataTable</returns>
        public Article[] SelStory(string query)
        {//"SELECT * FROM articles"
            DataTable table;
            do table = sql.Select(query);
            while (sql.SqlError());
            int N = table.Rows.Count;
            art = new Article[N]; int i = 0;
            foreach (DataRow row in table.Rows)
            {
                if (i == N) break;
                art[i]= new Article(row["title"].ToString(), row["post_date"].ToString(), row["story"].ToString(), row["likes"].ToString());
              
                i++;
            }
            return art;
         }
         



    }
}