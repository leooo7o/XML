// File: "LinqObj97"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj97");
            var B = File.ReadLines(GetString(), Encoding.Default)
 .Select(e =>
 {
     string[] s = e.Split(' ');
     return new

     {
         kind = s[0],
         prod_id = s[1],
         country=s[2]
     };
 });
            var C = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>

             {
                 string[] s = e.Split(' ');
                 return new

                 {
                     discount = int.Parse(s[0]),
                     shop = s[1],
                     cus_id = int.Parse(s[2])
                 };
             });
            var D = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>

             {
                 string[] s = e.Split(' ');
                 return new

                 {
                     val = int.Parse(s[0]),
                     shop = s[1],
                     prod_id= s[2]
                 };
             });
            var E = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>
             {
                 string[] s = e.Split(' ');
                 return new
                 {
                     shop = s[0],
                     cus_id = int.Parse(s[1]),
                     prod_id =s[2]
                 };
             });
           var ans= E.Join(D, a => a.shop+a.prod_id, b =>b.shop+ b.prod_id, (a, b) => new { prod_id = a.prod_id, shop = a.shop, cus_id = a.cus_id, val = b.val }).Show().GroupJoin(C, a =>a.shop+a.cus_id , b =>b.shop+b.cus_id, (aa, bb) => bb.DefaultIfEmpty().Select(e => new { shop = aa.shop, prod_id = aa.prod_id, val=aa.val,cus_id=aa.cus_id,discount=e== null ? 0 : bb.First().discount })).SelectMany(e=>e)
                .Join(B, a => a.prod_id, b =>b.prod_id, (a, b) => new { country = b.country, prod_id = a.prod_id, kind = b.kind, cus_id = a.cus_id, shop = a.shop, val = a.val, discount = a.discount })
                .GroupBy(e=>new { e.country, e.cus_id }).Select(e=>new { country = e.First().country, id = e.First().cus_id, sum = e.Sum(a => a.val-a.val*a.discount/ 100) }).OrderBy(e=>e.country).ThenBy(e=>e.id).Select(e=>e.country+" "+e.id+" "+e.sum).Show();
            File.WriteAllLines(GetString(), ans.ToArray(), Encoding.Default);
        }
    }
}
