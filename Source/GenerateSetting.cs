namespace DrawioSharp
{
    public class GenerateSetting
    {
        public static GenerateSetting Instance { get; } = new GenerateSetting();

        /// <summary>
        /// 生成合并流程图
        /// </summary>
        public bool IsGenerateExFlowChart { get; set; } = true;

        /// <summary>
        /// 是否生成箭头图元
        /// </summary>
        public bool IsGenerateArrow { get; set; } = true;

        /// <summary>
        /// 是否生成指向方法体的箭头
        /// </summary>
        public bool IsGenerateFunctionBodyArrow { get; set; } = true;

        private GenerateSetting() { }
    }
}
