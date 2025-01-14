using DrawioSharp.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawioSharp.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var doc = new DrawioDocument();
            var listGraphics = new ListGraphics();
            var item1 = new ListItemGraphics();
            var item2 = new ListItemGraphics();

            var connect = new ConnectGraphics(new ConnectTargetGraphics(item1, -40, 45),
                new ConnectTargetGraphics(item2, -40, 75));

            listGraphics.AddItem(connect);
            listGraphics.AddItem(item1);
            listGraphics.AddItem(item2);
            doc.Add(listGraphics);
            doc.Save("blank2.drawio");
        }
    }
}
