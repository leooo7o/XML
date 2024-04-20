// File: "LinqObj80"
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
            Task("LinqObj80");
            var B = File.ReadLines(GetString(), Encoding.Default)
            .Select(e =>
            {
                string[] s = e.Split(' ');
                return new
                {
                    val = int.Parse(s[0]),
                    shop = s[1],
                    id=s[2]
                };
            });
            var C = File.ReadLines(GetString(), Encoding.Default)
             .Select(e =>
             {
                 string[] s = e.Split(' ');
                 return new
                 {
                     id = s[0],
                     shop = s[1]
                 };
             });
            var ans = B.GroupJoin(C, a => new { id = a.id, shop = a.shop }, b => new { id = b.id, shop = b.shop }, (aa, bb) => bb.DefaultIfEmpty().Select(e => new { shop = aa.shop, id = aa.id, val=e==null?0:aa.val})).SelectMany(e=>e).OrderBy(e=>e.shop).ThenBy(e=>e.id).GroupBy(e=>new { e.shop, e.id }).Select(e=>e.First().shop+" "+e.First().id+" "+e.Sum(a=>a.val)).Show();
            File.WriteAllLines(GetString(), ans.ToArray(), Encoding.Default);
        }
    }
}
