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
        XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
        FileStream fileStream = new FileStream(path, FileMode.Create);
        
        serializer.Serialize(fileStream, this);
        fileStream.Close();
    }

    public static TextFile LoadXml(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
        FileStream fileStream = new FileStream(path, FileMode.Open);
        TextFile temp = (TextFile)serializer.Deserialize(fileStream);

        fileStream.Close();
        return temp;
    }

    public void SaveBinary(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);
        
        binaryFormatter.Serialize(fileStream, this);
        fileStream.Close();
    }

    public static TextFile LoadBinary(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);
        TextFile temp = (TextFile)binaryFormatter.Deserialize(fileStream);

        fileStream.Close();
        return temp;
    }
}