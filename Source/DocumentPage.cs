using DrawioSharp.Graphics;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Linq;

namespace DrawioSharp
{
    /// <summary>
    /// 文档页面
    /// </summary>
    public class DocumentPage
    {
        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName { get; set; } = "Default";

        private readonly string _canvasId = Utils.GenerateId();
        public List<GraphicsBase> Items { get; } = new List<GraphicsBase>();

        public DocumentPage() { }

        public DocumentPage(string pageName)
        {
            PageName = pageName;
        }

        public void Add(GraphicsBase node)
        {
            // TODO 下次打开的时候记得注释，为什么要这么设置parantid
            node.ParentId = _canvasId + "-1";
            Items.Add(node);
        }

        public XElement GetXElement()
        {
            var canvas = new XElement("mxCell", new XAttribute("id", _canvasId + "-0"));
            var gridNode = new XElement("mxCell", new XAttribute("id", _canvasId + "-1"),
                new XAttribute("parent", _canvasId + "-0"));
            var contentNode = new XElement("root", canvas, gridNode, Items.SelectMany(item => item.GetXElement()));

            return new XElement("diagram",
                new XAttribute("id", Guid.NewGuid().ToString()),
                new XAttribute("name", PageName),
                new XElement("mxGraphModel",
                new XAttribute("dx", "1373"),
                new XAttribute("dy", "854"),
                new XAttribute("grid", "1"),
                new XAttribute("gridSize", "10"),
                new XAttribute("guides", "1"),
                new XAttribute("tooltips", "1"),
                new XAttribute("connect", "1"),
                new XAttribute("arrows", "1"),
                new XAttribute("fold", "1"),
                new XAttribute("page", "0"),
                new XAttribute("pageScale", "1"),
                new XAttribute("pageWidth", "827"),
                new XAttribute("pageHeight", "1169"),
                new XAttribute("math", "0"),
                new XAttribute("shadow", "0"),
                contentNode
                )
            );
        }
    }
}
