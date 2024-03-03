
using System.Net;
using System.IO;
using System.Threading;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using fastJSON;
using ConsoleApp3;
using System.Net.Http.Headers;

namespace SecretPrj
{
    class Program
    {
        private const string RedactedExcel = "redacted_database.csv";
        private const string RedactedTxt = "redacted_database.txt";
        private const string RawExcel = "raw_database.csv";

        private const string RawTxt = "raw_database.txt";
        static string parseAdress;
        static string token = "m10n=Fe26.2**ee8fda577f11e2ae9e1100ff4df07ce4d027d3c5f7742b516065d1b717ed77e3*2qbZIYUAAwYyxR9wFvc_Gw*xqwerYrL3E_iidclQu14ow**eea876481c1ad1fd33c961ace2c2fe0e64a837447ffa90f3fb5ddf33be9a55a1*9fQN6I-YEIpgjT2umLm_eEKbOr3yRSreA-FMMIUo4TE";
        static int delay;
        static int countPages;

        static void GetAppSettings()
        {
            string path = @"link.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                parseAdress = sr.ReadLine();
            }
            path = @"delay.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                delay = Convert.ToInt32(sr.ReadLine());
            }
            path = @"pages.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                countPages = Convert.ToInt32(sr.ReadLine());
            }
        }
        static async Task<string> GetRequestAsync(int pageNumber)
        {
            //WebClient client = new WebClient();
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Cookie", token);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //client.Headers.Set(HttpRequestHeader.Cookie, token);
            //client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");
            //client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
            //client.Encoding = Encoding.UTF8;
            //client.Proxy = new System.Net.WebProxy();
            String path = String.Concat(parseAdress, "&page=", pageNumber);
            try
            {
                return await client.GetStringAsync(path);
            }
            catch (System.Net.WebException wex)
            {
                string? str = null;
                switch (wex.Status)
                {
                    case System.Net.WebExceptionStatus.ConnectFailure:
                    case System.Net.WebExceptionStatus.NameResolutionFailure:
                    case System.Net.WebExceptionStatus.Timeout:
                    case System.Net.WebExceptionStatus.ProtocolError:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(wex.Status.ToString());
                return str;
            }
        }

        static void ConvertToExel()
        {
            var str = File.ReadAllText("redacted_database.txt", Encoding.UTF8).Replace("\n", "").Replace("\r", "");
            List<ExcelData> new_res = JsonConvert.DeserializeObject<List<ExcelData>>(str);
            DataTable? dataTable = JsonConvert.DeserializeObject<DataTable>(str);
            dataTable.Columns.Remove("cells");
            List<string> lines = new List<string>();
            string[] columnNames = (from DataColumn column in dataTable!.Columns
                                    select column.ColumnName).ToArray();
            string header = string.Join(",", columnNames);
            lines.Add(header);
            EnumerableRowCollection<string> enumerableRowCollection = from row in dataTable.AsEnumerable()
                                                                      select string.Join(",", row.ItemArray);
            List<string> newLines = new List<string>();
            foreach (string line2 in enumerableRowCollection)
            {
                newLines.Add(line2.Replace("\n", "").Replace("\r", ""));
            }
            lines.AddRange(newLines);
            File.WriteAllLines("raw_database.csv", lines, Encoding.UTF8);

        }

        static async Task Main(string[] args)
        {
            GetAppSettings();

            //client.BaseAddress = parseAdress;
            string rawDataBasePath = @"raw_database.txt";
            string redactedDataBasePath = @"redacted_database.txt";
            File.Delete("raw_database.txt");
            File.Delete("redacted_database.txt");
            File.Delete("raw_database.csv");
            File.Delete("redacted_database.csv");

            try
            {
                using StreamWriter streamWriter2 = new StreamWriter("redacted_database.txt", append: true, Encoding.UTF8);
                streamWriter2.WriteLine("[");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var k = 1;
            Parallel.For(1, countPages + 1, i =>
            //for (int i = 1; i <= countPages; i++)
            {
                Console.WriteLine("Downloading page " + i);
                var response = await GetRequestAsync(i);
                if (response != null)
                {
                    response = response.Replace("\n", "").Replace("\r", "");
                    while (k<= countPages)
                    {
                        int DelayOnRetry = k*10;
                        if (i == k)
                        {
                            try
                            {
                                using StreamWriter sw = new StreamWriter("redacted_database.txt", append: true, Encoding.UTF8);
                                var res = JsonConvert.DeserializeObject<ExcelPage>(response)!.results;
                                foreach (var item2 in res)
                                {
                                    if (item2.cells != null)
                                    {
                                        foreach (var cell in item2.cells)
                                        {
                                            if (cell.id == 761776)
                                            {
                                                item2.cells_title += " " + cell.title;
                                            }
                                        }
                                        item2.cells = null;
                                    }
                                    item2.address = item2.address.Replace(",", "-");
                                    item2.loyalty = item2.loyalty.Replace(",", "-");
                                    item2.workposition = item2.workposition.Replace(",", "-");
                                    item2.workplace = item2.workplace.Replace(",", "-");
                                }
                                string resultString = JsonConvert.SerializeObject(res);
                                resultString = resultString.Replace("\n", "").Replace("\r", "");
                                resultString = resultString.Replace("[", "");
                                resultString = resultString.Replace("]", "");
                                sw.WriteLine(resultString);
                                if (i != countPages)
                                {
                                    sw.WriteLine(",");
                                }
                                Console.WriteLine(i);
                            }
                            catch (Exception ex2)
                            {
                                Console.WriteLine(ex2.Message);
                            }
                            k++;
                        }
                        else
                        {
                            Thread.Sleep(DelayOnRetry);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error when downloading page " + i);
                }
            }
            );


            try
            {
                using StreamWriter streamWriter5 = new StreamWriter("redacted_database.txt", append: true, Encoding.UTF8);
                streamWriter5.WriteLine("]");
            }
            catch (Exception ex3)
            {
                Console.WriteLine(ex3.Message);
            }
            ConvertToExel();

        }
    }
}
