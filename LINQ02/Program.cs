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

            #endregion


        }
    }
}
