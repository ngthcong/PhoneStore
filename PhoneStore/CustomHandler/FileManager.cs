
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneStore.CustomHandler
{
    public class FileManager
    {
        public static string GetUniqueName(string imageName)
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds() + "_" + imageName;
        }

        public static string[] StringSeparator(string input, string separator)
        {
            string[] output = input.Split(separator);
            return output;
        }
        public static string[] ExtractBase64Image(string input)
        {
            string pattern = "src=\"(data:image\\/[^;]+;base64[^\"]+)\"";
            string[] imageList = Regex.Split(input, pattern);
            return imageList;
        }
        public static bool IsBase64Image(string input)
        {
            string pattern = "data:image\\/([a-zA-Z]*);base64,";
            bool valid = Regex.IsMatch(input, pattern);
            return valid;
        }
        public static bool IsBase64(string input)
        {
            string pattern = "[^-A-Za-z0-9+/=]|=[^=]|={3,}$";
            bool valid = Regex.IsMatch(input, pattern);
            return valid;
        }

        public static string ExtractBase64(string input)
        {
            string pattern = "data:image\\/([a-zA-Z]*);base64,";
            string[] imageList = Regex.Split(input, pattern);
            return imageList[2];
        }
        public static string GetImageName(string input)
        {
            string pattern = "data-filename=\"([^\"]*)";
            string[] imageList = Regex.Split(input, pattern);
            return imageList[1];
        }
        public static string GetImageAttr(string input)
        {
            string pattern = "(data-filename=\".*?\">)";
            string[] imageList = Regex.Split(input, pattern);
            return imageList[1];
        }
        
        public static string ReplaceImageSrc(string text, string oldsrc, string newsrc)
        {
            string returntext = text.Replace(oldsrc, newsrc);
            return returntext;
        }

        

        //public Image Base64ToImage(string base64String)
        //{
        //    // Convert base 64 string to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    // Convert byte[] to Image
        //    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //    {
        //        Image image = Image.FromStream(ms, true);
        //        return image;
        //    }
        //}

        
    }

}

