namespace System.IO
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// System.IO 的扩展方法集合。
    /// </summary>
    public static class IOExts
    {
        #region Methods

        /// <summary>
        /// 从当前流中读取所有字节并将其写入到目标流中。
        /// </summary>
        /// <param name="source">源流。</param>
        /// <param name="destination">将包含当前流的内容的流。</param>
        public static void CopyTo(this Stream source, Stream destination)
        {
            CopyTo(source, destination, 4096);
        }

        /// <summary>
        /// 从当前流中读取所有字节并将其写入到目标流中（使用指定的缓冲区大小）。
        /// </summary>
        /// <param name="stream">源流。</param>
        /// <param name="source">将包含当前流的内容的流。</param>
        /// <param name="bufferSize">缓冲区的大小。此值必须大于零。默认大小为 4096。</param>
        public static void CopyTo(this Stream stream, Stream source, int bufferSize)
        {
            long oldPosition = 0L;
            if(stream.CanSeek)
            {
                oldPosition = stream.Position;
                stream.Position = 0;
            }
            byte[] array = new byte[bufferSize];
            while(true)
            {
                int size;
                if((size = stream.Read(array, 0, array.Length)) == 0)
                {
                    break;
                }
                source.Write(array, 0, size);
            }
            if(stream.CanSeek)
                stream.Position = oldPosition;
        }

        /// <summary>
        /// 尝试创建本地不存在的文件夹。如果文件夹已经存在，将被不会做任何事情。
        /// </summary>
        /// <param name="path">文件夹路径。</param>
        public static void CreateDirectory(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
#if !SILVERLIGHT
        /// <summary>
        /// 创建并返回一个指定父文件夹的、本地不存在的随机文件夹。
        /// </summary>
        /// <param name="parentDirectory">随机目录的所在目录。</param>
        /// <returns>返回指定父文件夹的一个随机文件夹。</returns>
        public static string CreateRandomDirectory(string parentDirectory)
        {
            string tempDire;
            do
            {
                tempDire = Path.Combine(parentDirectory, Path.GetRandomFileName());
            } while(Directory.Exists(tempDire));

            Directory.CreateDirectory(tempDire);
            return tempDire;
        }
        
        /// <summary>
        /// 尝试获取当前根目录下的路径。如果文件名是一个绝对路径，将会返回该文件名。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <returns>返回一个绝对路径。</returns>
        public static string TryGetPath(string filename)
        {
            if(filename.Contains(':'))
                return filename;
            return Path.Combine(GA.AppDirectory, filename);
        }
        
        /// <summary>
        /// 复制指定目录的所有数据到新的目录。
        /// </summary>
        /// <param name="sourceDirName">源目录路径。</param>
        /// <param name="destDirName">目标路径。</param>
        /// <param name="deleteSource">指示删除源目录。</param>
        public static void CopyDirectory(string sourceDirName, string destDirName, bool deleteSource)
        {
            CopyDirectory(sourceDirName, destDirName);
            if(deleteSource)
            {
                Directory.Delete(sourceDirName, true);
            }
        }

        private static void CopyDirectory(string sourceDirName, string destDirName)
        {
            if(!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            FileSystemInfo[] sfiles = dir.GetFileSystemInfos();
            if(sfiles != null && sfiles.Length > 0)
            {
                for(int i = 0 ; i < sfiles.Length ; i++)
                {
                    if(sfiles[i].Attributes == FileAttributes.Directory)
                    {
                        CopyDirectory(sfiles[i].FullName, destDirName + "\\" + sfiles[i].Name);
                    }
                    else
                    {
                        FileInfo file = (FileInfo)sfiles[i];
                        file.CopyTo(destDirName + "\\" + file.Name, true);
                    }
                }
            }
        }
#endif
        /// <summary>
        /// 尝试删除本地已存在的文件夹。
        /// </summary>
        /// <param name="path">文件夹路径。</param>
        /// <param name="recursive">若要移除 path 中的文件夹、子文件夹和文件，则为 true；否则为 false。</param>
        /// <returns>如果文件夹不存在或者创建成功，则返回 System.Result.Successfully，否则返回异常信息。</returns>
        public static Result DeleteDirectory(string path, bool recursive = true)
        {
            if(Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, recursive);
                }
                catch(Exception ex)
                {
                    return ex;
                }
            }
            return Result.Successfully;
        }

        /// <summary>
        /// 尝试删除本地已存在的文件。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns>如果文件不存在或者创建成功，则返回 System.Result.Successfully，否则返回异常信息。</returns>
        public static Result DeleteFile(string path)
        {
            if(Directory.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch(Exception ex)
                {
                    return ex;
                }
            }
            return Result.Successfully;
        }

        /// <summary>
        /// 以共享方式读取文件的所有行，默认编码格式 UTF-8。
        /// </summary>
        /// <param name="filename">文件的路径。</param>
        /// <returns>返回文件的所有行。</returns>
        public static string[] ShareReadAllLines(string filename)
        {
            return IOExts.ShareReadAllLines(filename, Encoding.UTF8);
        }

        /// <summary>
        /// 指定编码格式，以共享方式读取文件的所有行。
        /// </summary>
        /// <param name="filename">文件的路径。</param>
        /// <param name="encoding">编码格式。</param>
        /// <returns>返回文件的所有行。</returns>
        public static string[] ShareReadAllLines(string filename, Encoding encoding)
        {
            List<string> list = new List<string>();
            using(FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                StreamReader reader = new StreamReader(stream, encoding);
                string str;
                while(!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                    list.Add(str);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 以共享方式读取文件，默认编码格式 UTF-8。
        /// </summary>
        /// <param name="filename">文件的路径。</param>
        /// <returns>返回文件的所有文本内容。</returns>
        public static string ShareReadAllText(string filename)
        {
            return IOExts.ShareReadAllText(filename, Encoding.UTF8);
        }

        /// <summary>
        /// 指定编码格式，以共享方式读取文件。
        /// </summary>
        /// <param name="filename">文件的路径。</param>
        /// <param name="encoding">编码格式。</param>
        /// <returns>返回文件的所有文本内容。</returns>
        public static string ShareReadAllText(string filename, Encoding encoding)
        {
            using(FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Delete))
            {
                return new StreamReader(stream, encoding).ReadToEnd();
            }
        }
        /// <summary>
        /// 向当前流写入字节序列。
        /// </summary>
        /// <param name="stream">当前流。</param>
        /// <param name="bytes">字节序列。</param>
        public static void WriteBytes(this Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }


        #endregion Methods
    }
}