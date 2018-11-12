-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 192.168.0.105:3306
-- Время создания: Ноя 12 2018 г., 20:43
-- Версия сервера: 5.7.20-log
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `cdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `login` varchar(21) NOT NULL,
  `password` varchar(60) NOT NULL,
  `email` varchar(60) DEFAULT '',
  `fname` varchar(60) DEFAULT '',
  `lname` varchar(60) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`user_id`, `login`, `password`, `email`, `fname`, `lname`) VALUES
(2, 'admin1', '6c7ca345f63f835cb353ff15bd6c5e052ec08e7a', 'test2@mail.ru', 'Ormen', 'Zubenko'),
(3, 'rrt', 'f88cab68f1efa27b98d4e11181f13f03df24ac24', 'tsfddf@ssfdf.com', 'Fil', 'Fil'),
(4, 'qwe', '056eafe7cf52220de2df36845b8ed170c67e23e3', 'qwe@qweaw.com.ru', '13qwe', 'qwe'),
(5, '2wqeq', '269bb9969623061074473b3ccc1eba772ef567a9', 'qweq@qweq.ew.w.ee.w.w.com', 'qwe', 'qwe'),
(11, 'loishe', '3dbd8fdde83f1c2349d0ab1542be7a5643941d06', 'test22@mail.ru', 'Adsa', 'WQEdfs'),
(12, 'shet', 'c85b44db843d574bb19b2d5e018def3709ad7c42', 'ffffds@llokf.rambl.ru', 'Gog', 'Gog');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `login_UNIQUE` (`login`),
  ADD UNIQUE KEY `email_UNIQUE` (`email`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
