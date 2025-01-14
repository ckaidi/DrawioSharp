using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class RoundRectangleGraphics : GraphicsBase
    {
        private string _content = "Text";

        public string Content
        {
            get => _content;
            set
            {
                if (_content == value) return;
                _content = value;
                Width = Utils.MeasureTextWidth(value);
                Height = Utils.MeasureTextHeight(value);
            }
        }

        public RoundRectangleGraphics()
        {
            Height = 30;
        }

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var x = new XElement("mxCell");
            x.Add(new XAttribute("id", Id));
            x.Add(new XAttribute("value", Content));
            x.Add(new XAttribute("style", "rounded=1;whiteSpace=wrap;html=1;"));
            x.Add(new XAttribute("vertex", 1));
            if (ParentId != null)
                x.Add(new XAttribute("parent", ParentId));
            x.Add(new XElement("mxGeometry",
                new XAttribute("x", X),
                new XAttribute("y", Y),
                new XAttribute("width", Width),
                new XAttribute("height", Height),
                new XAttribute("as", "geometry")));
            result.Add(x);
            return result;
        }

        /// <summary>
        /// 计算目标连接点
        /// </summary>
        /// <param name="sourceX"></param>
        /// <param name="sourceY"></param>
        /// <param name="ifRight"></param>
        /// <returns></returns>
        public void CalculateTargetConnectPoint(int sourceX, int sourceY, bool ifRight)
        {
            X = ifRight
                ? sourceX + 100
                : sourceX - Width / 2;
            Y = ifRight
                ? sourceY - Height / 2
                : sourceY + 50;
        }
    }
}