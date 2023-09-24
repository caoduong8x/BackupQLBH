using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupQLBH
{
    public static class FileInfoExtensions
    {
        public static void CopyTo(this FileInfo file, FileInfo destination, Action<int> progressCallback)
        {
            byte[] array = new byte[1048576];
            byte[] array2 = new byte[1048576];
            bool flag = false;
            int num = 0;
            long length = file.Length;
            float num2 = (float)length;
            Task task = null;
            using (FileStream fileStream = file.OpenRead())
            {
                using (FileStream fileStream2 = destination.OpenWrite())
                {
                    fileStream2.SetLength(fileStream.Length);
                    int num5;
                    for (long num3 = 0L; num3 < length; num3 += (long)num5)
                    {
                        int num4;
                        bool flag2 = (num4 = (int)((float)num3 / num2 * 100f)) != num;
                        if (flag2)
                        {
                            progressCallback(num = num4);
                        }
                        num5 = fileStream.Read(flag ? array : array2, 0, 1048576);
                        if (task != null)
                        {
                            task.Wait();
                        }
                        task = fileStream2.WriteAsync(flag ? array : array2, 0, num5);
                        flag = !flag;
                    }
                    if (task != null)
                    {
                        task.Wait();
                    }
                }
            }
        }
    }

}
