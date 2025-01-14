using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DrawioSharp.Graphics
{
    /// <summary>
    /// 所有draw.io图元的基类
    /// </summary>
    public abstract class GraphicsBase
    {
        public string Id { get; set; } = Utils.GenerateId();

        public int X { get; set; }

        public int Y { get; set; }

        public string ParentId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public abstract List<XElement> GetXElement();

        /// <summary>
        /// 计算目标图元连接点
        /// </summary>
        /// <returns></returns>
        public virtual (int, int) CalculateDownSourceConnectPoint()
        {
            var sourceX = X + Width / 2;
            var sourceY = Y + Height;
            return (sourceX, sourceY);
        }

        /// <summary>
        /// 计算目标右边图元连接点
        /// </summary>
        /// <returns></returns>
        public virtual (int, int) CalculateRightSourceConnectPoint()
        {
            var sourceX = X + Width;
            var sourceY = Y + Height / 2;
            return (sourceX, sourceY);
        }
    }
}