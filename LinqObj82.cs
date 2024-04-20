// File: "LinqObj82"
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
            Task("LinqObj82");
            var B = File.ReadLines(GetString(), Encoding.Default)
 .Select(e =>
 {
     string[] s = e.Split(' ');
     return new

     {
         kind = s[0],
         country = s[1],
         id=s[2]
     };
 });
            var C = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>
             {
                 string[] s = e.Split(' ');
                 return new
                 {
                     val = int.Parse(s[0]),
                     id = s[1],
                     shop = s[2]
                 };
             });
            var D = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>

             {
                 string[] s = e.Split(' ');
                 return new

                 {
                     id = s[0],
                     id2 = s[1],
                     shop = s[2]
                 };
             });
            var ans=D.Join(C, a => new { a.shop, a.id }, b => new { b.shop, b.id }, (a, b) => new { idc = a.id2, shop = a.shop, id = a.id, val = b.val }).Join(B, a => a.id, b => b.id, (a, b) => new { idc = a.idc, shop = a.shop, id = a.id, val = a.val, kind = b.kind }).GroupBy(e=>e.idc).Select(e=>new {num=e.Select(a=>a.kind).Distinct().Count(),id=e.First().idc,sum=e.Max(a=>a.val)}).OrderByDescending(e=>e.num).ThenBy(e=>e.id).Select(e=>e.num+" "+e.id+" "+e.sum).Show();
            File.WriteAllLines(GetString(), ans.ToArray(), Encoding.Default);
        }
    }
}
