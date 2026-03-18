using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace InputOutput
{
    [Serializable]
    public class TextFile
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public TextFile()
        {
            Name = "";
            Content = "";
        }

        public TextFile(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public Memento CreateMemento()
        {
            return new Memento(Content);
        }

        public void Restore(Memento memento)
        {
            Content = memento.SavedContent;
        }

        public class Memento
        {
            public string SavedContent { get; }
            public Memento(string content)
            {
                SavedContent = content;
            }
        }

        public void SaveXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
            FileStream fileStream = new FileStream(path, FileMode.Create);

            serializer.Serialize(fileStream, this);
            fileStream.Close();

            Console.WriteLine("Save in XML complete. Press any key...");
            Console.ReadKey();
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

            Console.WriteLine("Save in Binary complete. Press any key...");
            Console.ReadKey();
        }

        public static TextFile LoadBinary(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            TextFile temp = (TextFile)binaryFormatter.Deserialize(fileStream);

            fileStream.Close();
            return temp;
        }

        public void SaveAsText(string path)
        {
            File.WriteAllText(path, Content);
            Console.WriteLine("Save in TXT complete. Press any key...");
            Console.ReadKey();
        }
    }
}