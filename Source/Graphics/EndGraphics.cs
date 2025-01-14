using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    /// <summary>
    /// 函数结束标志
    /// </summary>
    public class EndGraphics : GraphicsBase
    {
        public EndGraphics()
        {
            Width = 60;
            Height = 20;
        }

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var x = new XElement("mxCell");
            x.Add(new XAttribute("id", Id));
            x.Add(new XAttribute("value", "End"));
            x.Add(new XAttribute("style", "rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;"));
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
    }
}
