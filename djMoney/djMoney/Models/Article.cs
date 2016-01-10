using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using djMoney.Models;
namespace djMoney.Models
{
    public class Article
    {
        public string Title { get; set; } //заголовок статьи
        public string post_date { get; set; } //дата и время публикации
        public string Context { get; set; }//текст статьи
        public string Author { get; set; }//автор статьи
        public string price { get; set; } //цена статьи, которая в конце

        public Article()
        {
            

        }
        public Article(string Title, string postdate, string Context, string price)
        {
            this.Title = Title;
            this.post_date = postdate;
            this.Context = Context;
            this.price = price+" $ ";

        }


    }
}