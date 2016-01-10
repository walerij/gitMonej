using System.Data;

namespace djMoney.Models
{
  public  interface ISql
    {
        string Scalar(string query); //возвращает одно число / строку - одно значение
        DataTable Select(string query);
        long Insert(string query); //добавление одной строки - возвр ппорядковый номер строки (или -1);
        int Update(string query);//update or delete return afterred rows -скока строк изменено

        bool Modify(string query);//запросы на изменение структуру БД - create, drop, alter table

    }
}
