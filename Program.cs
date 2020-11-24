using System;
using System.IO;

namespace LargeFileSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("请输入要查询的文件全路径");
        start:
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("文件不存在,请重新输入要查询的文件全路径");
                goto start;
            }
            while (true)
            {
                Console.WriteLine("请输入要查询的关键字");
            start2:
                string search = Console.ReadLine();

                if (string.IsNullOrEmpty(search))
                {
                    Console.WriteLine("关键字不能为空，请重新输入关键字");
                    goto start2;
                }

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader r = new StreamReader(fs))
                    {
                        Console.WriteLine("开始时间:" + DateTime.Now.ToString("HH:mm:ss"));
                        string s = null;
                        do
                        {
                            try
                            {
                                s = r.ReadLine();

                                if (s != null && s.Contains(search))
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            catch (Exception)
                            {


                            }

                        } while (s != null);
                        Console.WriteLine("全部查询完成");
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    }
                }

            }


        }
    }
}
