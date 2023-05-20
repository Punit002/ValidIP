namespace ValidIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine(Solution.ValidIPAddress("192.0.0.1"));

            Console.ReadKey();
        }
    }


    public static class Solution
    {
        private const string V = "Neither";
        private static List<string> cmpStr = new();

        public static string ValidIPAddress(string queryIP)
        {
            try
            {
                const string ipV4 = "IPv4";
                const string ipv6 = "IPv6";

                var ipList = queryIP.Split(".").ToList();

                if (ipList.Count == 4)
                {
                    foreach (var item in ipList)
                    {
                        var i = Convert.ToInt16(item);
                        if (i >= 0 && i <= 255)
                        {
                            List<int> ips = item.Select(i => int.Parse(i.ToString())).ToList();
                            for (int j = 0; j < ips.Count; j++)
                            {
                                if (ips.Count > 1 && ips[0] == 0)
                                {
                                    return V;
                                }
                            }
                        }
                        else
                        {
                            return V;
                        }
                    }
                    return ipV4;
                }
                else
                {
                    ipList = queryIP.Split(":").ToList();
                    if (ipList.Count == 8)
                    {
                        cmpStr=  new()
                        {
                            "a", "b", "c","d", "e", "f", "A", "B", "C", "D", "E", "F"
                        };
                        foreach (var item in ipList)
                        {
                            if (item.Length >= 1 && item.Length <= 4)
                            {
                                List<string> ips = item.Select(i => i.ToString()).ToList();
                                for (int j = 0; j < ips.Count; j++)
                                {
                                    int res;
                                    if (!int.TryParse(ips[j], out res))
                                    {
                                        if (ips[j] is not null
                                        && cmpStr.Contains(ips[j]))
                                        {
                                            continue;
                                        }
                                        return V;
                                    }

                                }
                            }
                            else
                            {
                                return V;
                            }
                        }
                        return ipv6;
                    }
                }
                return V;
            }
            catch (Exception)
            {

                return V;
            }
        }
    }
}