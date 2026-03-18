using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class TextFile
{
    public string Name { get; set; }
    public string Content { get; set; }

    public TextFile() { }

    public TextFile(string name, string content)
    {
        Name = name;
        Content = content;
    }

    public void SaveXml(string path)
    {
        XmlSerializer serializer = new XmlSerializer(this.GetType());
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(fs, this);
        }
    }




}