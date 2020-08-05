using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsGemini.Models
{
    public class FileEqualsChecker
    {
        public async Task<bool> IsSameFile(StorageFile fname1 , StorageFile fname2)
        {
            if (string.CompareOrdinal(fname1.Name, fname2.Name) == 0) return true;

            bool isSameSize = await IsSameSize(fname1, fname2);
            if (!isSameSize) return false;

            return await IsSameContent(fname1, fname2);
        }
        private async Task<bool> IsSameSize(StorageFile file1 , StorageFile file2)
        {
            Windows.Storage.FileProperties.BasicProperties file1Prop = await file1.GetBasicPropertiesAsync();
            Windows.Storage.FileProperties.BasicProperties file2Prop = await file2.GetBasicPropertiesAsync();

            return file1Prop.Size == file2Prop.Size;
        }

        private const int BLOCK_SIZE = 1 * 1024 * 1024;
        private async Task<bool> IsSameContent(StorageFile fname1 , StorageFile fname2)
        {
            var block1 = new byte[BLOCK_SIZE];
            var block2 = new byte[BLOCK_SIZE];

            using (var sr1 = await CreateStream(fname1))
            using (var sr2 = await CreateStream(fname2))
            {
                int l1 = 0, l2 = 0;
                do
                {
                    l1 = await sr1.ReadAsync(block1, 0, block1.Length);
                    l2 = await sr2.ReadAsync(block2, 0, block2.Length);

                    if (l1 != l2) return false;
                    for (int i = 0; i < l1; i++)
                    {
                        if (block1[i] != block2[i]) return false;
                    }
                } while (l1 > 0 && l2 > 0);
            }
            return true;
        }


        private const int BUFFER_SIZE = 10 * 1024 * 1024;
        private async Task<Stream> CreateStream(StorageFile fname)
        {
            var stream = await fname.OpenStreamForReadAsync();
            return new BufferedStream(stream , BUFFER_SIZE);
        }

        private async Task<ulong> GetFileSize(StorageFile File)
        {
            Windows.Storage.FileProperties.BasicProperties file1Prop = await File.GetBasicPropertiesAsync();
            return file1Prop.Size;
        }

        public static async Task<byte[]> GetFileContent(StorageFile file)
        {
            return await file.ReadBytesAsync();
        }

    }
}
