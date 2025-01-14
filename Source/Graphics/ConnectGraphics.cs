using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class ConnectGraphics : GraphicsBase
    {
        public ConnectTargetGraphics Source { get; }
        public ConnectTargetGraphics Target { get; }

        public string Text { get; set; }

        public ConnectGraphics(ConnectTargetGraphics source, ConnectTargetGraphics target)
        {
            Source = source;
            Target = target;
        }

        public override List<XElement> GetXElement()
        {
            if (!GenerateSetting.Instance.IsGenerateArrow) return new List<XElement>();
            var result = new List<XElement>();
            var element = new XElement("mxCell",
                new XAttribute("id", Id),
                new XAttribute("style",
                    "endArrow=classicThin;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;"),
                new XAttribute("edge", "1"),
                new XAttribute("source", Source.Graphics.Id),
                new XAttribute("target", Target.Graphics.Id),
                new XElement("mxGeometry",
                    new XAttribute("relative", "1"),
                    new XAttribute("as", "geometry"),
                    new XElement("Array",
                        new XAttribute("as", "points"),
                        new XElement("mxPoint",
                            new XAttribute("x", Source.X),
                            new XAttribute("y", Source.Y)),
                        new XElement("mxPoint",
                            new XAttribute("x", Target.X),
                            new XAttribute("y", Target.Y)))));
            if (ParentId != null)
                element.Add(new XAttribute("parent", ParentId));
            result.Add(element);
            if (Text == null) return result;
            var textGraphics = new TextGraphics()
            {
                Content = Text,
                ParentId = Id,
            };
            result.AddRange(textGraphics.GetXElement());

            return result;
        }
    }
}