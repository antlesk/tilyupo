using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_2_25
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(file, FileMode.Open);

                var buffer = new byte[fileStream.Length];
                fileStream.Seek(3, SeekOrigin.Begin);
                fileStream.Read(buffer, 0, buffer.Length);

                string code = Encoding.UTF8.GetString(buffer);

                bool isOneLineComment = false;
                bool isMultiLineComment = false;

                int commentLength = 0;
                for (int i = 1; i < code.Length; i++)
                {
                    if (isMultiLineComment || isOneLineComment) commentLength++;

                    if (isOneLineComment)
                    {
                        if (code[i] == '\n')
                        {
                            isOneLineComment = false;
                        }
                    }

                    if (isMultiLineComment)
                    {
                        if (code[i - 1] == '*' && code[i] == '/')
                        {
                            isMultiLineComment = false;
                        }
                    }
                    
                    if (!(isMultiLineComment && isOneLineComment))
                    {
                        if (code[i - 1] == '/' && code[i] == '/')
                        {
                            isOneLineComment = true;
                            commentLength += 2;
                        }

                        if (code[i - 1] == '/' && code[i] == '*')
                        {
                            isMultiLineComment = true;
                            commentLength += 2;
                        }
                    }
                }

                Console.WriteLine(code);
                Console.WriteLine($"Code length: {code.Length}, comment length: {commentLength}");
                Console.WriteLine($"(comment length)/(code length) * 100% = {(double)commentLength / code.Length * 100}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream?.Close();
            }

            Console.ReadKey();
        }
    }
}
