using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace planner
{
    class XmlAddRead
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public List<string> labels = new List<string>();
        public List<string> contents = new List<string>();
        public List<string> dates = new List<string>();
        public int CardsCount;

        public void AddCard()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("./Resources/cards.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // создаем новый элемент user
            XmlElement noteElement = xDoc.CreateElement("note");
            // создаем атрибут name
            XmlAttribute noteAttribute = xDoc.CreateAttribute("title");
            // создаем элементы company и age
            XmlElement contentElement = xDoc.CreateElement("content");
            XmlElement dateTimeElement = xDoc.CreateElement("dateTime");
            // создаем текстовые значения для элементов и атрибута
            XmlText titleText = xDoc.CreateTextNode(Title);
            XmlText contentText = xDoc.CreateTextNode(Content);
            XmlText dateTimeText = xDoc.CreateTextNode(DateTime);

            //добавляем узлы
            noteAttribute.AppendChild(titleText);
            contentElement.AppendChild(contentText);
            dateTimeElement.AppendChild(dateTimeText);
            noteElement.Attributes.Append(noteAttribute);
            noteElement.AppendChild(contentElement);
            noteElement.AppendChild(dateTimeElement);
            xRoot.AppendChild(noteElement);
            xDoc.Save("./Resources/cards.xml");
        }

        public void ReadCards()
        {
            labels.Clear();
            contents.Clear();
            dates.Clear();

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
                    if (attr != null)
                    {
                        labels.Add(attr.Value);
                    }    
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
    }
}
