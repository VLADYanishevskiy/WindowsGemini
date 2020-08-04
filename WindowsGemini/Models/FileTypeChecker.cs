using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGemini.Models
{
    class FileTypeChecker
    {
        public static  bool IsImage(string FileType)
        {
            switch (FileType)
            {
                case ".jpg":
                case ".jpeg":
                case ".jfif":
                case ".tif":
                case ".fiff":
                case ".gif":
                case ".bmp":
                case ".ppm":
                case ".pgm":
                case ".pnm":
                case ".wepb":
                case ".eps":
                case ".raw":
                case ".cr2":
                case ".nef":
                case ".orf":
                case ".sr2":
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        public static bool IsDocument(string FileType)
        {
            switch (FileType)
            {
                case ".doc":
                case ".docm":
                case ".docx":
                case ".dot":
                case ".dotm":
                case ".dotx":
                case ".htm":
                case ".html":
                case ".mht":
                case ".mhtml":
                case ".odt":
                case ".pdf":
                case ".rtf":
                case ".txt":
                case ".wpf":
                case ".xml":
                case ".xps":
                case ".csv":
                case ".dbf":
                case ".dif":
                case ".ods":
                case ".prn":
                case ".slk":
                case ".xla":
                case ".xlam":
                case ".xls":
                case ".xlsb":
                case ".xlsm":
                case ".xlt":
                case ".xlthm":
                case ".xltx":
                case ".xlw":
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        public static bool IsArchive(string FileType)
        {
            switch (FileType)
            {
                case ".a":
                case ".ar":
                case ".cpio":
                case ".shar":
                case ".LBR":
                case ".iso":
                case ".lbr":
                case ".mar":
                case ".sbx":
                case ".tar":
                case ".bz2":
                case ".F":
                case ".?XF":
                case ".gz":
                case ".lz":
                case ".lz4":
                case ".lzma":
                case ".lzo":
                case ".rz":
                case ".sfark":
                case ".sz":
                case ".?Q?":
                case ".?Z?":
                case ".xz":
                case ".z":
                case ".Z":
                case ".zst":
                case ".??_":
                case ".7z":
                case ".s7z":
                case ".ace":
                case ".afa":
                case ".alz":
                case ".apk":
                case ".arc":
                case ".ark":
                case ".cdx":
                case ".arj":
                case ".b1":
                case ".b6z":
                case ".ba":
                case ".bh":
                case ".cab":
                case ".car":
                case ".cfs":
                case ".cpt":
                case ".dar":
                case ".dd":
                case ".dgc":
                case ".dmg":
                case ".ear":
                case ".ha":
                case ".hki":
                case ".ice":
                case ".jar":
                case ".kgb":
                case ".lzh":
                case ".lzx":
                case ".pak":
                case ".partimg":
                case ".paq6":
                case ".pea":
                case ".pim":
                case ".pit":
                case ".qda":
                case ".rar":
                case ".rk":
                case ".sda":
                case ".sea":
                case ".sen":
                case ".sfx":
                case ".shk":
                case ".sit":
                case ".sitx":
                case ".sqx":
                case ".tar.gz":
                case ".uc":
                case ".uca":
                case ".war":
                case ".wim":
                case ".xar":
                case ".zoo":
                case ".zz":
                case ".ecc":
                case ".par":
                case ".rev":
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        public static bool IsVideo(string FileType)
        {
            switch (FileType)
            {
                case ".webm":
                case ".mkv":
                case ".flv":
                case ".vob":
                case ".ogv":
                case ".drc":
                case ".gifv":
                case ".mng":
                case ".avi":
                case ".MTS":
                case ".M2TS":
                case ".TS":
                case ".mov":
                case ".qt":
                case ".wmw":
                case ".yuv":
                case ".rm":
                case ".rmvb":
                case ".viv":
                case ".asf":
                case ".amv":
                case ".mp4":
                case ".m4p":
                case ".m4v":
                case ".mpg":
                case ".mp2":
                case ".mpeg":
                case ".mpe":
                case ".mpv":
                case ".svi":
                case ".3gp":
                case ".3g2":
                case ".mxf":
                case ".roq":
                case ".nsv":
                case ".flx":
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        public static bool IsAudio(string FileType)
        {
            switch (FileType)
            {
                case ".3gp":
                case ".aa":
                case ".aac":
                case ".aax":
                case ".act":
                case ".aiff":
                case ".alac":
                case ".amr":
                case ".ape":
                case ".au":
                case ".awb":
                case ".dct":
                case ".dss":
                case ".dvf":
                case ".gsm":
                case ".iklax":
                case ".ivs":
                case ".m4a":
                case ".m4b":
                case ".mmf":
                case ".mp3":
                case ".mpc":
                case ".msv":
                case ".nmf":
                case ".ogg":
                case ".oga":
                case ".mogg":
                case ".opus":
                case ".ra":
                case ".rm":
                case ".raw":
                case ".rf64":
                case ".sln":
                case ".tta":
                case ".voc":
                case ".wav":
                case ".wma":
                case ".wv":
                case ".cda":
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}
