using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XYWE
{
    public class StartTip
    {
        private static List<string> tips = new List<string>(new[] {
            "Tip1:在WE内按Alt+F再按1~N可以快速打开最近打开过的第1~N张地图",
            "Tip2:除了多人地图，也有很多人喜欢故事为主的单人地图",
            "Tip3:选中地形装饰物，按 Ctrl+Page Up/Down 以 提升/降低 装饰物",
        });

        private static string pathXyweInfo = @"core\ydwe\share\mpq\xywe\ui\WorldEditStrings.txt";
        private static string tipFormat = @"" +
            "[WorldEditStrings]\r\n" +
            "WESTRING_WELCOME_SMALLTEXT1=\"{0}\"\r\n" +
            "WESTRING_WELCOME_SMALLTEXT2=\"{1}\"\r\n" +
            "WESTRING_WELCOME_LEGALTEXT=\"{2}\"";
        private static Random randomMaker = new Random();

        public static void Refresh()
        {
            var tipId = randomMaker.Next(tips.Count);
            var tip1 = "";
            var tip2 = "";
            var tip3 = "";
            tip1 = tips[tipId];
            File.WriteAllText(pathXyweInfo, string.Format(tipFormat, tip1, tip2, tip3), Encoding.UTF8);
        }
    }
}
