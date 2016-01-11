using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace djMoney.Models
{
    /// <summary>
    /// класс работы с историями (выборки,  добавление, редактирования, изменения статусов)
    /// </summary>
    /// 



    public class Story
    {
        protected BaseConnect conn;
        protected MySQL sql;
        public Article[] art;
        public Story(BaseConnect conn)
        {
            this.conn = conn;
            this.sql = conn.sql;

        }


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
                art[i] = new Article(row["title"].ToString(), row["post_date"].ToString(), row["story"].ToString(), row["likes"].ToString());

                i++;
            }
            return art;
        }


        /// <summary>
        /// Возращает выборку по LIMITED начиная с  id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article[] SelStoryLimitId(int id)
        {
            string query = "SELECT * FROM story ";
            query = query + " LIMIT " + id + " , 10";

            try {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch {
                return art; //возвращается пустой art

            }

            return art;

        }




    }
}