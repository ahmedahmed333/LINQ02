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
                              select new { c.CustomerID, o.OrderDate };


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
            bool res010 = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitPrice > 0);

            Console.WriteLine($"All seafood in stock? {res010}");



            #endregion

            #region Q011
            int[] ids = { 3, 9, 13, 18 };


            Console.WriteLine($"Contains 9  {ids.Contains(9)}");


            #endregion

            #region Q012
            Console.WriteLine($"-=---=-=-=---=-=-");

            var resQ012 = ProductList.GroupBy(p => p.Category);

            foreach (var g in resQ012)
            {
                Console.WriteLine($"{g.Key} ({g.Count()})");
                foreach (var p in g) Console.WriteLine($"{p.ProductName}");
            }


            #endregion



            #region Q013

            var res013 = ProductList.GroupBy(p => p.Category)
                 .Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName) });


            foreach (var g in res013)
            {
                Console.WriteLine(g.Category);
                foreach (var n in g.Names) Console.WriteLine($"{n}");
            }

            #endregion

            #region Q014

            var res014 = ProductList.GroupBy(p => p.Category).Where(g => g.Count() > 3);



            foreach (var g in res014) Console.WriteLine($"{g.Key}: {g.Count()}");
            #endregion

            #region Q015

            var res015 = from c in customers
                         group c by c.Country into g
                         select new
                         {
                             Country = g.Key,
                             Count = g.Count(),
                             TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                         };

            foreach (var x in res015) Console.WriteLine($"{x.Country} | {x.Count} | {x.TotalOrderValue}");
            #endregion

            #region Q016

            Console.WriteLine($"Total unites: {ProductList.Sum(p => p.UnitsInStock)}");

            #endregion

            #region Q017
            Console.WriteLine($"Cheapest : ${ProductList.Min(p => p.UnitPrice)}C2");
            Console.WriteLine($"Most expensive : {ProductList.Max(p => p.UnitPrice):C2}");


            #endregion


            #region Q018

            var res018 = ProductList.Select(p => p.Category).Distinct();

            foreach (var c in res018) Console.WriteLine(c);


            #endregion


            #region Q019

            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            Console.WriteLine(string.Join(", ", setA.Except(setB)));

            #endregion


            #region Q020

            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            Console.WriteLine(string.Join(", ", list1.Except(list2, StringComparer.OrdinalIgnoreCase)));


            #endregion


            #region Q021

            var resQ021 = ProductList.ToDictionary(p => p.ProductID);

            Console.WriteLine(resQ021[18]);

            #endregion


            #region Q022

            var res022 = ProductList.First(p => p.UnitPrice > 50M);

            Console.WriteLine(res022);

            #endregion


            #region Q023

            var res023 = ProductList.FirstOrDefault(p => p.UnitPrice > 600M);

            Console.WriteLine(res023 is null ? "No product found" : res023.ToString());

            #endregion


            #region Q024

            var res024 = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {7 * i}");

            foreach (var row in res024) Console.WriteLine(row);

            #endregion


            #region Q025

            var res025 = Enumerable.Range(1, 30).Where(n => n % 2 == 0);

            Console.WriteLine(string.Join(",", res025));

            #endregion


            #region Q026

            var res026 = ProductList.Take(3).Select(p => p.ProductName).Concat(customers.Take(3).Select(c => c.CustomerName));


            foreach (var row in res026) Console.WriteLine(row);
            #endregion



            #region Q027

            var resQ027 = ProductList.Zip(customers, (p, c) => $"{p.ProductName} sold to {c.CustomerName}");


            foreach (var s in resQ027) Console.WriteLine(s);
            #endregion

        }
    }
}
