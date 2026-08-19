using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
                .Skip(1)
                .Select(line => Language.FromTsv(line))
                .ToList();

            // foreach (var val in languages)
            // {
            // Console.WriteLine(val.Prettify());
            // }
      
            var res = from l in languages
                where l.Name.Contains("C#")
                select $"{l.Year} {l.Name} {l.ChiefDeveloper}";

            // foreach (var val in res)
            // {
            //   Console.WriteLine(val);
            // }

            var res1 = from l in languages
                where l.ChiefDeveloper.Contains("Microsoft")
                select $"{l.Year} {l.Name} {l.ChiefDeveloper}";

            // foreach (var val in res1)
            // {
            //   Console.WriteLine(val);
            // }

            var res2 = from l in languages
                where l.Predecessors.Contains("Lisp")
                select $"{l.Year} {l.Name} {l.ChiefDeveloper}";
      
            // foreach (var val in res2)
            // {
            //   Console.WriteLine(val);
            // }

            var res3 = from l in languages
                where l.Name.Contains("Script")
                select $"{l.Name}";

            // foreach (var val in res3)
            // {
            //   Console.WriteLine(val);
            // }
      
            // Console.WriteLine(languages.Count);

            var res4 = languages
                .Where(l => l.Year >= 1995 && l.Year <= 2005)
                .Select(l => $"{l.Name} was invented in {l.Year}");

            Console.WriteLine(res4.Count());

            foreach (var val in res4)
            {
                Console.WriteLine(val);
            }
        }
    }
}