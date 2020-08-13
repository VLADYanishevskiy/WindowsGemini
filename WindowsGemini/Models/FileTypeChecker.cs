using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.Models
{
    class FileTypeChecker
    {
        private static List<string> imageExtensions = new List<string>() {  ".jpg" , ".jpeg" , ".jfif" , ".tif" , ".fiff" , ".gif" , ".bmp" , ".ppm" , ".pgm" , ".pnm" , ".wepb" , ".eps" , ".raw" , ".cr2" , ".nef" , ".orf" , ".sr2"};
        private static List<string> documentExtensions = new List<string>() { ".doc",".docm",".docx",".dot",".dotm",".dotx",".htm",".html",".mht",".mhtml",".odt",".pdf",".rtf",".txt",".wpf",".xml",".xps",".csv",".dbf",".dif",".ods",".prn",".slk",".xla",".xlam",".xls",".xlsb",".xlsm",".xlt",".xlthm" ,".xltx" ,".xlw" };
        private static List<string> arciveExtensions = new List<string>() { ".a",".ar",".cpio",".shar",".LBR",".iso",".lbr",".mar",".sbx",".tar",".bz2",".F",".?XF",".gz",".lz",".lz4",".lzma",".lzo",".rz",".sfark",".sz",".?Q?",".?Z?",".xz" , "zip",".z",".Z",".zst",".??_",".7z",".s7z",".ace",".afa",".alz",".apk",".arc",".ark",".cdx",".arj",".b1",".b6z",".ba",".bh",".cab",".car",".cfs",".cpt",".dar",".dd",".dgc",".dmg",".ear",".ha",".hki",".ice",".jar",".kgb",".lzh",".lzx",".pak",".partimg",".paq6",".pea",".pim",".pit",".qda",".rar",".rk",".sda",".sea",".sen",".sfx",".shk",".sit",".sitx",".sqx",".tar.gz",".uc",".uca",".war",".wim",".xar",".zoo",".zz",".ecc",".par",".rev"};
        private static List<string> videoExtensions = new List<string>() {".webm",".mkv",".flv",".vob",".ogv",".drc",".gifv",".mng",".avi",".MTS",".M2TS",".TS",".mov",".qt",".wmw",".yuv",".rm",".rmvb",".viv",".asf",".amv",".mp4",".m4p",".m4v",".mpg",".mp2",".mpeg",".mpe",".mpv",".svi",".3gp",".3g2",".mxf",".roq",".nsv",".flx"};
        private static List<string> audioExtensions = new List<string>() {".3gp",".aa",".aac",".aax",".act",".aiff",".alac",".amr",".ape",".au",".awb",".dct",".dss",".dvf",".gsm",".iklax",".ivs",".m4a",".m4b",".mmf",".mp3",".mpc",".msv",".nmf",".ogg",".oga",".mogg",".opus",".ra",".rm",".raw",".rf64",".sln",".tta",".voc",".wav",".wma",".wv",".cda" };
        public static  bool IsImage(string FileType)
        {
            return imageExtensions.Contains(FileType);
        }
        public static bool IsDocument(string FileType)
        {
            return documentExtensions.Contains(FileType);
        }
        public static bool IsArchive(string FileType)
        {
            return arciveExtensions.Contains(FileType);
        }
        public static bool IsVideo(string FileType)
        {
            return videoExtensions.Contains(FileType);
        }
        public static bool IsAudio(string FileType)
        {
            return audioExtensions.Contains(FileType);
        }
    }
}
