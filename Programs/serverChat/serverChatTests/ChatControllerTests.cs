using Microsoft.VisualStudio.TestTools.UnitTesting;
using serverChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverChat.Tests
{
    [TestClass()]
    public class ChatControllerTests
    {
        /// <summary>
        /// Проверка функции получения всех сообщений из списка для отправки их клиенту
        /// </summary>
        [TestMethod()]
        public void GetChatTest()
        {
            // Создаём имитацию приходящего сообщения от пользователя
            string nickname = "TESTUSER";
            string msg = "Привет Мир!";
            // Добавляем её в список сообщений через структуру
            ChatController.message fullMsg = new ChatController.message(nickname, msg);
            ChatController.Chat.Add(fullMsg);
            // Проверяем добавилось ли сообщение в список
            Assert.IsNotNull(ChatController.Chat);
        }
    }
}