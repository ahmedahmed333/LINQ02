using static LINQ.DataSources.Source;
using LINQ.DataSources;
using LINQ.Models;
namespace LINQ02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = Source.CustomerList;

            #region Q01

            var products = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Category} {item.ProductName} | {item.UnitPrice}");
            }

            #endregion

            #region Q02

            var productsQ02 = products.
                Where(p => p.Category == "Beverages").
                OrderByDescending(p => p.UnitsInStock);

            foreach (var item in productsQ02) Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");


            #endregion

            #region Q03

            var querySyntax = from c in customers
                              from o in c.Orders
                              where o.OrderDate.Year >= 1997
                              select new {c.CustomerID, o.OrderDate};


            foreach (var item in querySyntax) Console.WriteLine($"{item.CustomerID} - {item.OrderDate}");

            #endregion

            #region Q04

            var nums = products.Select((p, i) => $"{i + 1}. {p.ProductName}");


            foreach (var line in nums) Console.WriteLine(line);
            #endregion

            #region Q05

            string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BIUeBeRrY", "CIOvEr", "cHeRry" };

            var result = arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var line in result) Console.WriteLine(line);

            #endregion

            #region Q06
            var res = arr.Where(w => w.Length > 1 && char.ToLower(w[1]) == 'i').Reverse();
            foreach (var line in res) Console.WriteLine(line);

            #endregion

            #region Q07

            var res07 = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach (var item in res07) Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");

            #endregion

            #region Q08

            int page = 2, pageSize = 5;

            var res08 = ProductList.Skip((page - 1) * pageSize).Take(pageSize);

            foreach (var item in res08) Console.WriteLine(item);

            #endregion


            #region Q09

            var res09 = ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25M);

            foreach (var item in res09) Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");

            #endregion


            #region Q010
            bool res010 = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitPrice > 0)
  
                Console.WriteLine($"All seafood in stock? {res010}");



            #endregion


        }
    }
}
