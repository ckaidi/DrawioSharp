using System;
using System.Drawing;
using System.Text;

namespace DrawioSharp
{
    public static class Utils
    {
        private static readonly char[] CharSet =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-".ToCharArray();

        private static readonly Random Random = new Random();

        /// <summary>
        /// 生成随机id
        /// </summary>
        /// <returns></returns>
        public static string GenerateId()
        {
            return GenerateRandomString(20);
        }

        /// <summary>
        /// 计算文字宽度
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int MeasureTextWidth(string text)
        {
            return MeasureTextWidth(text, new Font("Helvetica", 12));
        }

        /// <summary>
        /// 计算文字宽度
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static int MeasureTextWidth(string text, Font font)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string maxLine = "";
            foreach (var item in lines)
            {
                if (maxLine.Length < item.Length)
                {
                    maxLine = item;
                }
            }
            switch (font.Name)
            {
                case "Helvetica":
                    return maxLine.Length * 6 + 20;
                default:
                    return maxLine.Length * 6 + 20;
            }
        }

        /// <summary>
        /// 计算文字宽度
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int MeasureTextHeight(string text)
        {
            return MeasureTextHeight(text, new Font("Helvetica", 12));
        }

        /// <summary>
        /// 计算文字宽度
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static int MeasureTextHeight(string text, Font font)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            switch (font.Name)
            {
                case "Helvetica":
                    return Math.Max(30, lines.Length * 20);
                default:
                    return Math.Max(30, lines.Length * 20);
            }
        }

        private static string GenerateRandomString(int length)
        {
            var stringBuilder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                var randomIndex = Random.Next(CharSet.Length);
                stringBuilder.Append(CharSet[randomIndex]);
            }

            return stringBuilder.ToString();
        }
    }
}