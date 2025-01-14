namespace DrawioSharp.Graphics
{
    /// <summary>
    /// 连接目标图元
    /// </summary>
    public class ConnectTargetGraphics
    {
        public GraphicsBase Graphics { get; }
        public int X
        { 
            get; 
            set;
        }
        public int Y
        {
            get; 
            set; 
        }

        public ConnectTargetGraphics(GraphicsBase graphics, int x, int y)
        {
            Graphics = graphics;
            X = x;
            Y = y;
        }
    }
}