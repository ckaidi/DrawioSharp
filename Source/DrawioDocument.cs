using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using DrawioSharp.Graphics;

namespace DrawioSharp
{
    public class DrawioDocument
    {
        private List<XElement> _xelements = new List<XElement>();

        public void Save(string path)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false), // 使用无 BOM 的 UTF-8 编码
                Indent = true // 如果需要的话，添加缩进以增强可读性
            };

            using (var writer = XmlWriter.Create(path, settings))
            {
                var doc = new XDocument(GetXElement());
                doc.Save(writer);
            }
        }

        public void Add(XElement xElement) => _xelements.Add(xElement);

        public List<XElement> GetXElement()
        {
            var result = new List<XElement>();
            var docElement = new XElement("mxfile",
                new XAttribute("host", "Electron"),
                new XAttribute("modified", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")),
                new XAttribute("agent",
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) draw.io/24.6.4 Chrome/124.0.6367.207 Electron/30.0.6 Safari/537.36"),
                new XAttribute("etag", "LTQFhk5pbIBi7Ej9MxMX"),
                new XAttribute("version", "24.6.4"),
                new XAttribute("type", "device"),
                _xelements
            );
            result.Add(docElement);
            return result;
        }
    }
}
