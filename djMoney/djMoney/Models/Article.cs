using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using djMoney.Models;
using System.ComponentModel.DataAnnotations;

namespace djMoney.Models
{
    public class Article
    {

        [Required(ErrorMessage ="Введите заголовок статьи")]
        public string Title { get; set; } //заголовок статьи
                
        public string post_date { get; set; } //дата и время публикации

        [Required(ErrorMessage = "Введите текст статьи")]
        public string Context { get; set; }//текст статьи
               
        public string Author { get; set; }//автор статьи
               
        public string price { get; set; } //цена статьи, которая в конце
               
        public string id { get; set; } //ид статьи
        public Article()
        {
            

        }
        public Article(string Title, string postdate, string Context, string price, string id)
        {
            this.Title = Title;
            this.post_date = postdate;
            this.Context = Context;
            this.price = price;
            this.id = id;
        }


    }
}