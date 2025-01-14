using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class ListItemGraphics : GraphicsBase
    {
        public string Content { get; set; } = "item";
        public int ContentWidth => Utils.MeasureTextWidth(Content, new Font("Helvetica", 12));

        public ListItemGraphics()
        {
            Height = 20;
        }

        public ListItemGraphics(string content) : this()
        {
            Content = content;
        }

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var x = new XElement("mxCell");
            x.Add(new XAttribute("id", Id));
            x.Add(new XAttribute("value", Content));
            x.Add(new XAttribute("type", "class-function"));
            x.Add(new XElement("mxGeometry",
                new XAttribute("x", X),
                new XAttribute("y", Y),
                new XAttribute("width", Math.Max(ContentWidth, Width)),
                new XAttribute("height", Height),
                new XAttribute("as", "geometry")));
            x.Add(new XAttribute("style", "text;strokeColor=none;" +
                                          "fillColor=none;align=center;" +
                                          "verticalAlign=middle;spacingLeft=4;" +
                                          "spacingRight=4;overflow=hidden;" +
                                          "points=[[0,0.5],[1,0.5]];" +
                                          "portConstraint=eastwest;" +
                                          "rotatable=0;whiteSpace=wrap;html=1;"));
            if (ParentId != null)
                x.Add(new XAttribute("parent", ParentId));
            x.Add(new XAttribute("vertex", "1"));
            result.Add(x);
            return result;
        }
    }
}