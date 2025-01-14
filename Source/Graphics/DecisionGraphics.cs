using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class DecisionGraphics : GraphicsBase
    {
        public string Content { get; set; } = "";

        public DecisionGraphics()
        {
            Height = 100;
            Width = 100;
        }

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var element = new XElement("mxCell",
                new XAttribute("id", Id),
                new XAttribute("value", Content),
                new XAttribute("style", "strokeWidth=2;html=1;shape=mxgraph.flowchart.decision;whiteSpace=wrap;"),
                new XAttribute("vertex", "1"),
                new XElement("mxGeometry",
                    new XAttribute("x", X),
                    new XAttribute("y", Y),
                    new XAttribute("width", Width),
                    new XAttribute("height", Height),
                    new XAttribute("as", "geometry")));
            if (ParentId != null)
                element.Add(new XAttribute("parent", ParentId));
            result.Add(element);
            return result;
        }
    }
}