using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace planner
{
    class XmlAddRead
    {
        // Переменные для хранения данных из xml файла
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public string Id { get; set; }
        public static List<string> labels = new List<string>();
        public static List<string> contents = new List<string>();
        public static List<string> dates = new List<string>();
        public List<string> ids = new List<string>();
        public int CardsCount; // Кол-во записей

        // Функция для добавления данных в файл
        public void AddCard()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("./Resources/cards.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // создаем новый элемент user
            XmlElement noteElement = xDoc.CreateElement("note");
            // создаем атрибут name
            XmlAttribute noteAttribute = xDoc.CreateAttribute("title");
            XmlAttribute noteAttribute2 = xDoc.CreateAttribute("id");
            // создаем элементы company и age
            XmlElement contentElement = xDoc.CreateElement("content");
            XmlElement dateTimeElement = xDoc.CreateElement("dateTime");
            // создаем текстовые значения для элементов и атрибута
            XmlText titleText = xDoc.CreateTextNode(Title);
            ReadCards();
            XmlText idNum;
            if (ids.Count != 0)
                idNum = xDoc.CreateTextNode((Convert.ToInt32(ids[ids.Count() - 1]) + 1).ToString());
            else
                idNum = xDoc.CreateTextNode("0");
            XmlText contentText = xDoc.CreateTextNode(Content);
            XmlText dateTimeText = xDoc.CreateTextNode(DateTime);

            //добавляем узлы
            noteAttribute.AppendChild(titleText);
            noteAttribute2.AppendChild(idNum);
            contentElement.AppendChild(contentText);
            dateTimeElement.AppendChild(dateTimeText);
            noteElement.Attributes.Append(noteAttribute);
            noteElement.Attributes.Append(noteAttribute2);
            noteElement.AppendChild(contentElement);
            noteElement.AppendChild(dateTimeElement);
            xRoot.AppendChild(noteElement);
            xDoc.Save("./Resources/cards.xml");
        }

        // Функция для считавания данных из файла
        public void ReadCards()
        {
            labels.Clear();
            contents.Clear();
            dates.Clear();
            ids.Clear();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("./Resources/cards.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            int xmlLen = 0;

            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("title");
                    XmlNode attr2 = xnode.Attributes.GetNamedItem("id");
                    if (attr != null)
                        labels.Add(attr.Value);
                    if (attr2 != null)
                        ids.Add(attr2.Value);

                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "content")
                    {
                        contents.Add(childnode.InnerText);
                    }
                    // если узел age
                    if (childnode.Name == "dateTime")
                    {
                        dates.Add(childnode.InnerText);
                    }
                }

                xmlLen++;
            }

            CardsCount = xmlLen;
        }
        
        // Функция для удаления записи из файла
        public void DeleteCard(string id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./Resources/cards.xml");
            XmlNodeList nodes = doc.SelectNodes(String.Format("//note[@id='{0}']", id));
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save("./Resources/cards.xml");
        }
    }
}
