using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class TextGraphics : GraphicsBase
    {
        public string Content { get; set; } = "Text";

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var x = new XElement("mxCell");
            x.Add(new XAttribute("id", Id));
            x.Add(new XAttribute("value", Content));
            x.Add(new XAttribute("style", "edgeLabel;html=1;align=center;verticalAlign=middle;resizable=0;points=[];"));
            x.Add(new XAttribute("vertex", 1));
            x.Add(new XAttribute("connectable", 0));
            if (ParentId != null)
                x.Add(new XAttribute("parent", ParentId));
            x.Add(new XElement("mxGeometry",
                new XAttribute("x", 0),
                new XAttribute("y", 0),
                new XAttribute("relative", 1),
                new XAttribute("as", "geometry"),
                new XElement("mxPoint",
                    new XAttribute("x", 0),
                    new XAttribute("y", 0),
                    new XAttribute("as", "offset"))));
            result.Add(x);
            return result;
        }
    }
}