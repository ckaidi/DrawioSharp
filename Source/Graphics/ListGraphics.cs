using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    public class ListGraphics : GraphicsBase
    {
        private int _count;
        private string _content = "list";
        private readonly List<ListItemGraphics> _items = new List<ListItemGraphics>();
        private readonly List<ConnectGraphics> _connects = new List<ConnectGraphics>();
        public string Content
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _content = value;
                    Width = Utils.MeasureTextWidth(value);
                }
            }
        }
        public int ContentWidth => Utils.MeasureTextWidth(Content, new Font("Helvetica", 12));
        public string OriginId { get; set; }

        /// <summary>
        /// 填充颜色
        /// </summary>
        public string FillColor { get; set; }

        /// <summary>
        /// 线条颜色
        /// </summary>
        public string StrokeColor { get; set; }

        /// <summary>
        /// 是否是自己的方法
        /// </summary>
        public bool IsSelfFunction { get; set; } = true;

        public ListGraphics()
        {
            Width = Utils.MeasureTextWidth(Content);
            Height = 30;
            OriginId = Id;
            Id = OriginId + "-0";
        }

        /// <summary>
        /// 获取XElement
        /// </summary>
        /// <returns></returns>
        public override List<XElement> GetXElement()
        {
            var maxWidth = _items.Select(item => item.ContentWidth).Prepend(ContentWidth).Max();
            maxWidth = Math.Max(maxWidth, Width);
            foreach (var item in _items) item.Width = maxWidth;

            var result = new List<XElement>();
            var element = new XElement("mxCell",
                new XAttribute("id", Id),
                new XAttribute("value", Content),
                new XAttribute("type", "class"),
                new XElement("mxGeometry",
                    new XAttribute("x", X),
                    new XAttribute("y", Y),
                    new XAttribute("width", maxWidth),
                    new XAttribute("height", Height),
                    new XAttribute("as", "geometry")));
            var additionalStyle = "";
            if (FillColor != null)
                additionalStyle += "fillColor=" + FillColor + ";";
            if (StrokeColor != null)
                additionalStyle += "strokeColor=" + StrokeColor + ";";
            element.Add(new XAttribute("style", "swimlane;fontStyle=0;" +
                                                "childLayout=stackLayout;" +
                                                "horizontal=1;startSize=30;" +
                                                "horizontalStack=0;resizeParent=1;" +
                                                "resizeParentMax=0;resizeLast=0;" +
                                                "collapsible=1;marginBottom=0;" +
                                                "whiteSpace=wrap;html=1;" + additionalStyle));
            element.Add(new XAttribute("vertex", "1"));
            if (ParentId != null)
                element.Add(new XAttribute("parent", ParentId));
            result.Add(element);
            foreach (var connect in _connects) result.AddRange(connect.GetXElement());
            foreach (var item in _items) result.AddRange(item.GetXElement());
            return result;
        }

        /// <summary>
        /// 添加item图元
        /// </summary>
        /// <param name="listItemGraphics"></param>
        public void AddItem(ListItemGraphics listItemGraphics)
        {
            _count++;
            listItemGraphics.Id = OriginId + "-" + _count;
            listItemGraphics.ParentId = Id;
            listItemGraphics.Y = Height;
            Width = Math.Max(Width, listItemGraphics.ContentWidth);
            _items.Add(listItemGraphics);
            Height += listItemGraphics.Height;
        }

        /// <summary>
        /// 添加连接图元
        /// </summary>
        /// <param name="graphicsBase"></param>
        public void AddItem(ConnectGraphics graphicsBase)
        {
            _count++;
            graphicsBase.Id = OriginId + "-" + _count;
            graphicsBase.ParentId = Id;
            _connects.Add(graphicsBase);
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
                ? sourceY - 45
                : sourceY + 50;
        }

        public override (int, int) CalculateRightSourceConnectPoint()
        {
            var sourceX = X + Width;
            int sourceY;
            if (_items.Count > 0)
                sourceY = Y + _items[0].Height / 2 + 30;
            else
                sourceY = Y + 45;
            return (sourceX, sourceY);
        }
    }
}