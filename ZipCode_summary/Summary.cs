using System;
using System.Collections.Generic;
using System.IO;

namespace ZipCode_summary
{
    public class Summary
    {
        Dictionary<string, int> zcSummary = new Dictionary<string, int>();
        string address;

        void CountZipCodes(string address)
        {
            var reader = new StreamReader(@address);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineEntry = line.Split(',');
                string zipCode = lineEntry[8].ToString();

                if (!zcSummary.ContainsKey(zipCode))
                {
                    zcSummary.Add(zipCode, 1);
                } else
                {
                    zcSummary[zipCode]++;
                }
            }
        }

        void ExportZCSummary()
        {
            var writer = new StreamWriter(@"path\zcSummary.csv");
            foreach (var pair in zcSummary)
            {
                writer.WriteLine("{0},{1}", pair.Key, String.Join(",", pair.Value.Select(x => x.ToString()).ToArray()));
            }
        }
    }
}
