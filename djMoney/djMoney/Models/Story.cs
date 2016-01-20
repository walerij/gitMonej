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
        public string error { get; private set; }
        public string query { get; private set; }

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
                art[i] = new Article(row["title"].ToString(), 
                                     row["post_date"].ToString(), 
                                     row["story"].ToString(), 
                                     row["likes"].ToString(),
                                     row["id"].ToString());

                i++;
            }
            return art;
        }


        /// <summary>
        /// Возращает выборку  LIMITED начиная с  id по count штук
        /// </summary>
        /// <param name="id">начиная с этого числа выборка</param>
        /// <param name="count">количество выбираемых записей</param>
        /// <returns></returns>
        public Article[] SelStoryLimitId(int id, int count)
        {
            string query = "SELECT * FROM story ";
            query = query + " LIMIT " + id + " , "+count+" ";

            try {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch {
                return art; //возвращается пустой art

            }

            return art;

        }


        /// <summary>
        /// Выбрать одну запись по id
        /// </summary>
        /// <param name="id">значение поля id таблицы story</param>
        /// <returns></returns>
         public Article[] SelStoryByID(int id)     
         {
            string query = "SELECT * FROM story WHERE id = "+id;
         
            try
            {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch
            {
                return art; //возвращается пустой art

            }

            return art;

        }

        /// <summary>
        /// Выборка историй, набравших максимальное количество лайков в количестве count
        /// </summary>
        /// <param name="count">количество выводимых историй</param>
        /// <returns></returns>
        public Article[] SelBestStory(int count)
        {
            string query = "SELECT * FROM story ORDER BY likes DESC LIMIT "+count ; //выборка историй упорядоченных по полю LIKES по убыванию

            try
            {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch
            {
                return art; //возвращается пустой art
            }

            return art;
        }

        /// <summary>
        /// Выборка последних опубликованных историй (по последней дате публикации)
        /// </summary>
        /// <param name="count">количество историй</param>
        /// <returns></returns>
        public Article[] SelNewStory(int count)
        {
            string query = "SELECT * FROM story ORDER BY post_date DESC LIMIT " + count; //выборка историй упорядоченных по полю post_date по убыванию

            try
            {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch
            {
                return art; //возвращается пустой art
            }

            return art;
        }
 


        public Article[] SelStoryByFind(string find)
        {
            string query = @"SELECT * FROM story 
                              WHERE story LIKE %'" + find + @"'%
                                 OR title LIKE %'" + find + @"'%
                                 OR    id  =  '" + find+@"' 
                             ORDER BY post_date DESC"; //выборка историй, где какое-либо значение равно find упорядоченных по полю post_date по убыванию

            try
            {
                art = SelStory(query);//правильное выполнение - art заполняется данными
            }
            catch
            {
                return art; //возвращается пустой art
            }

            return art;
        }



        /// <summary>
        /// добавление истории - long
        /// </summary>
        public long AddStory(Article art) {
             query = @"INSERT INTO story SET 
                                   title='" + sql.addslashes(art.Title) + @"', 
                                   status='list',
                                   likes='0',
                                   post_date='" + sql.addslashes(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm:ss"))+ @"',
                                   story='" + sql.addslashes(art.Context) + @"' ";
            long insert;
            try
            {
                insert = sql.Insert(query);
            }
            catch
            {
                error = sql.error;
                query = sql.query;
                insert = -1;
            }
            return insert;

        }



    }
}