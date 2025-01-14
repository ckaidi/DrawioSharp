using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    /// <summary>
    /// VerticalContainer图形
    /// 方法体语句图形
    /// </summary>
    public class VerticalContainerGraphics : GraphicsBase
    {
        public string FunctionName { get; }
        private int _count;

        /// <summary>
        /// 最大语句的宽度
        /// </summary>
        private int _maxStatementWidth;
        public string OriginId { get; set; }
        private readonly List<GraphicsBase> _items = new List<GraphicsBase>();

        /// <summary>
        /// 里面包含的item的数量
        /// </summary>
        public int Count => _items.Count;

        public List<VerticalContainerGraphics> VerticalContainers { get; } = new List<VerticalContainerGraphics>();

        /// <summary>
        /// 垂直箭头
        /// </summary>
        private readonly List<ConnectGraphics> _verticalConnects = new List<ConnectGraphics>();
        /// <summary>
        /// 水平箭头
        /// </summary>
        private readonly List<ConnectGraphics> _horizonConnects = new List<ConnectGraphics>();
        public int Deep { get; }

        /// <summary>
        /// 是否有结束标志
        /// </summary>
        public bool IsHasEnd { get; set; } = false;

        public VerticalContainerGraphics(string functionName, int deep)
        {
            OriginId = Id;
            FunctionName = functionName;
            Deep = deep;
        }

        /// <summary>
        /// 添加item图元
        /// </summary>
        /// <param name="graphics"></param>
        public void AddItem(GraphicsBase graphics)
        {
            _count++;
            graphics.ParentId = Id;
            _items.Add(graphics);
        }

        /// <summary>
        /// 添加item图元
        /// </summary>
        /// <param name="verticalContainer"></param>
        public void AddItem(VerticalContainerGraphics verticalContainer)
        {
            _count++;
            verticalContainer.ParentId = Id;
            VerticalContainers.Add(verticalContainer);
        }

        /// <summary>
        /// 添加垂直箭头
        /// </summary>
        /// <param name="connect"></param>
        public void AddHorizonConnect(ConnectGraphics connect)
        {
            _count++;
            connect.ParentId = Id;
            _horizonConnects.Add(connect); ;
        }

        /// <summary>
        /// 添加垂直箭头
        /// </summary>
        /// <param name="connect"></param>
        public void AddVerticalConnect(ConnectGraphics connect)
        {
            _count++;
            connect.ParentId = Id;
            _verticalConnects.Add(connect); ;
        }

        public override List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var element = new XElement("mxCell",
                new XAttribute("id", Id),
                new XAttribute("value", FunctionName),
                new XAttribute("type", "function-body"),
                new XAttribute("style", "swimlane;whiteSpace=wrap;html=1;"),
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
            foreach (var item in _items) result.AddRange(item.GetXElement());
            foreach (var item in VerticalContainers) result.AddRange(item.GetXElement());
            foreach (var item in _verticalConnects) result.AddRange(item.GetXElement());
            foreach (var item in _horizonConnects) result.AddRange(item.GetXElement());
            return result;
        }

        /// <summary>
        /// 重新计算所有item的相对位置
        /// </summary>
        public void CalculateItemsLocation()
        {
            _maxStatementWidth = Utils.MeasureTextWidth(FunctionName) + 20;
            foreach (var item in _items)
                _maxStatementWidth = Math.Max(_maxStatementWidth, item.Width + 20);

            foreach (var item in _items)
            {
                var interval = (_maxStatementWidth - item.Width) / 2;
                item.X = interval;
                item.Y = item.Y - Y;
            }
            foreach (var item in VerticalContainers)
            {
                item.X = _maxStatementWidth + 10;
                item.Y = item.Y - Y;
            }
            foreach (var item in _verticalConnects)
            {
                var interval = (_maxStatementWidth - item.Width) / 2;
                item.Source.X = interval + item.Width / 2;
                item.Target.X = item.Target.X - X;
                item.Source.Y = item.Source.Y - Y;
                item.Target.Y = item.Target.Y - Y;
            }
            foreach (var item in _horizonConnects)
            {
                var interval = (_maxStatementWidth - item.Width) / 2;
                item.Source.X = interval + item.Width / 2;
                item.Target.X = item.Target.X - X;
                item.Source.Y = item.Source.Y - Y;
                item.Target.Y = item.Target.Y - Y;
            }
        }

        public void RecalculateWidthAndHeight()
        {
            if (VerticalContainers.Count == 0)
            {
                Width = _maxStatementWidth;
                return;
            }
            var maxWidth = _maxStatementWidth;
            foreach (var item in VerticalContainers)
            {
                maxWidth = Math.Max(maxWidth, item.Width + item.X);
            }
            Width = maxWidth + 10;
            var maxHeight = Height;
            foreach (var item in VerticalContainers)
            {
                maxHeight = Math.Max(maxHeight, item.Height + item.Y);
            }
            Height = maxHeight + 10;
        }
    }
}
