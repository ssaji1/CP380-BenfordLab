using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BenfordLab
{
    public class BenfordData
    {
        public int Digit { get; set; }
        public int Count { get; set; }

        public BenfordData() { }
    }

    public class Benford
    {
       
        public static BenfordData[] calculateBenford(string csvFilePath)
        {
            // load the data
            var data = File.ReadAllLines(csvFilePath)
                .Skip(1) // For header
                .Select(s => Regex.Match(s, @"^(.*?),(.*?)$"))
                .Select(data => new
                {
                    Country = data.Groups[1].Value,
                    Population = int.Parse(data.Groups[2].Value)
                });

            // manipulate the data!
            //
            // Select() with:
            //   - Country
            //   - Digit (using: FirstDigit.getFirstDigit() )
            // 
            // Then:
            //   - you need to count how many of *each digit* there are
            //
            // Lastly:
            //   - transform (select) the data so that you have a list of
            //     BenfordData objects
            //
            /* int i = 0;
                foreach (var row in data)
            {
               i++;
                   }
            var arr[] = var int[i];
            int j = 0;
            foreach (var row in data)
            {
                 arr[j] = FirstDigit.getFirstDigit(row.Population);
                 j++;

            if (FirstDigitNum is null)
                {
                    throw new ArgumentNullException(nameof(FirstDigitNum));
                }
            }*/

            var m = data
                .GroupBy(FirstDigitNum =>
                {
                    if (FirstDigitNum is null)
                    {
                        throw new ArgumentNullException(nameof(FirstDigitNum));
                    }

                    return FirstDigit.getFirstDigit(FirstDigitNum.Population);
                })
                .Select(
                arr =>
                {
                    return new BenfordData
                    {
                        Digit = arr.Key,
                        Count = arr.Count()
                    };
                });
            return m.OrderByDescending(m => m.Digit).ToArray();
        }
    }
}
