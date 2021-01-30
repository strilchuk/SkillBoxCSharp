using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_Theme_03
{
    class Program
    {
        const byte GAME_MODE_SINGLE = 1;
        const byte GAME_MODE_MULTI = 2;

        const byte CHOICE_MAIN_EXIT = 0;
        const byte CHOICE_MAIN_OPTIONS = 3;

        const byte CHOICE_OPTIONS_BACK = 0;
        const byte CHOICE_OPTIONS_PLAYER_COUNT = 1;
        const byte CHOICE_OPTIONS_MAX_TRY = 2;
        const byte CHOICE_OPTIONS_MAX_GAME_NUMBER = 3;
        const byte CHOICE_OPTIONS_MIN_GAME_NUMBER = 4;

        static void Main(string[] args)
        {
            #region Текст задания
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
            #endregion

            byte GameMode = 0; // Текущий игровой режим
            byte PlayerCount = 2; // Количество игроков
            string[] NickNames = { }; // Множество имен игроков
            int gameNumberMin = 12; // Нижняя граница генерируемого числа для игры
            int gameNumberMax = 120; // Верхняя граница генерируемого числа для игры
            int gameNumber; // Игровоче число
            int userTryCountMax = -1; // Максимальное количество попыток
            byte[] userTryPossibles = { 1, 2, 3, 4 }; // Возможные варианты ходов 

            System.Random random = new System.Random();

            byte UserChoice = Utils.USER_INPUT_EMPTY;
            do
            {
                Console.Clear();

                if (UserChoice == Utils.USER_INPUT_EMPTY || UserChoice == Utils.USER_INPUT_ERROR) // 
                {
                    UserChoice = ShowMainMenu(); // Отображаем главное меню
                }
                else if (UserChoice == CHOICE_MAIN_EXIT) //В главном меню выбрали "Выход"
                {
                    Environment.Exit(0);
                }
                else if (UserChoice == CHOICE_MAIN_OPTIONS) //В главном меню выбрали "Опции"
                {
                    Console.Clear();
                    UserChoice = ShowOptionsMenu(); // Отображаем меню опций

                    if (UserChoice == CHOICE_OPTIONS_PLAYER_COUNT) // Установить количество игроков
                    {
                        PlayerCount = (byte)Utils.SetOptions("PlayerCount", PlayerCount, "Введите количество игроков:");
                        UserChoice = CHOICE_MAIN_OPTIONS;
                    }
                    else if (UserChoice == CHOICE_OPTIONS_MAX_TRY) // Установить максимальное количество попыток
                    {
                        userTryCountMax = Utils.SetOptions(
                            "userTryCountMax",
                            userTryCountMax,
                            "Введите количество попыток (-1 - нет ограничения):\n "
                            );
                        UserChoice = CHOICE_MAIN_OPTIONS;
                    }
                    else if (UserChoice == CHOICE_OPTIONS_MAX_GAME_NUMBER) // Установить верхнюю границу игрового числа
                    {
                        gameNumberMax = Utils.SetOptions(
                            "gameNumberMax",
                            gameNumberMax,
                            "Введите верхнюю границу игрового числа"
                            );
                        UserChoice = CHOICE_MAIN_OPTIONS;
                    }
                    else if (UserChoice == CHOICE_OPTIONS_MIN_GAME_NUMBER) // Установить нижнюю границу игрового числа
                    {
                        gameNumberMin = Utils.SetOptions(
                            "gameNumberMin",
                            gameNumberMin,
                            "Введите нижнюю границу игрового числа"
                            );
                        UserChoice = CHOICE_MAIN_OPTIONS;
                    }
                    else if (UserChoice == CHOICE_OPTIONS_BACK) // Выбрали "назад"
                    {
                        UserChoice = Utils.USER_INPUT_EMPTY;
                    }
                    else // Возвращаемся в меню опций
                    {
                        UserChoice = CHOICE_MAIN_OPTIONS;
                    }
                }
                else
                {
                    UserChoice = Utils.USER_INPUT_EMPTY;
                    Console.ReadKey();
                }

                if (UserChoice == GAME_MODE_SINGLE)
                {
                    Console.Clear();
                    NickNames = SetNickNames(1);
                    Console.Clear();
                    gameNumber = random.Next(gameNumberMin, gameNumberMax);
                    GameMode = GAME_MODE_SINGLE;
                    doGame(NickNames, GameMode, gameNumber, userTryCountMax, userTryPossibles);
                }

                if (UserChoice == GAME_MODE_MULTI)
                {
                    Console.Clear();
                    NickNames = SetNickNames(PlayerCount);
                    Console.Clear();
                    gameNumber = random.Next(gameNumberMin, gameNumberMax);
                    GameMode = GAME_MODE_MULTI;
                    doGame(NickNames, GameMode, gameNumber, userTryCountMax, userTryPossibles);
                }
            }
            while (true);

            Console.ReadKey();
        }

        public static void doGame(string[] NickNames, int GameMode, int gameNumber, int userTryCountMax, byte[] userTryPossibles)
        {
            string currentPlayer = "";
            System.Random random = new System.Random();

            if (GameMode == GAME_MODE_SINGLE) //Если игровой режим одиночный, то добавляем вторым игроком компьютер
            {
                List<string> NickNamesList = new List<string>();
                foreach (var item in NickNames)
                {
                    NickNamesList.Add(item);
                }
                NickNamesList.Add("Компьютер");
                NickNames = NickNamesList.ToArray();
            }

            int i = 0;
            while (gameNumber > 0)
            {
                currentPlayer = NickNames[i];
                byte currentTry = Utils.USER_INPUT_EMPTY;
                while (currentTry == Utils.USER_INPUT_EMPTY || currentTry == Utils.USER_INPUT_ERROR)
                {
                    string TryCountMaxString = userTryCountMax == -1 ? "" : $"Осталось попыток: {userTryCountMax.ToString()}";
                    Utils.WriteOnCenter($"Игровое число: {gameNumber} Ходит игрок: {currentPlayer} {TryCountMaxString}");
                    if (GameMode == GAME_MODE_SINGLE && currentPlayer == "Компьютер")
                    {
                        currentTry = userTryPossibles[random.Next(0, userTryPossibles.Count() - 1)];
                        Utils.WriteOnCenter("Компьютер ввел:" + currentTry);
                    }
                    else
                    {
                        currentTry = (byte)Utils.ReadInt();
                    }

                    if (!Array.Exists(userTryPossibles, element => element == currentTry))
                    {
                        Utils.WriteOnCenter("----------------");
                        Utils.WriteOnCenter("Вы ввели недопустимое значение.");
                        Utils.WriteOnCenter("Допустимые значения: " + string.Join(", ", userTryPossibles));
                        Utils.WriteOnCenter("----------------");
                        currentTry = Utils.USER_INPUT_EMPTY;
                    }
                }
                gameNumber -= currentTry;
                if (userTryCountMax == 0)
                {
                    break;
                }
                if (userTryCountMax != -1)
                {
                    userTryCountMax--;
                }
                i++;
                if (i == NickNames.Count())
                {
                    i = 0;
                }
            }

            if (userTryCountMax == 0 && gameNumber != 0)
            {
                Console.Clear();
                Utils.WriteOnCenter($"Количество попыток закончилось. Все проиграли...");
            }
            if (gameNumber <= 0)
            {
                Utils.WriteOnCenter($"Выйграл игрок {currentPlayer}");
            }

            Console.ReadKey();
        }


        /// <summary>
        /// Устанавливаем имена игрокам
        /// </summary>
        /// <param name="PlayerCount"></param>
        /// <returns></returns>
        public static string[] SetNickNames(byte PlayerCount)
        {
            string[] result = new string[PlayerCount];
            for (int i = 1; i <= PlayerCount; i++)
            {
                Utils.WriteOnCenter($"Введите имя игрока {i}");
                result[i - 1] = Console.ReadLine();
            }
            return result;
        }


        /// <summary>
        /// Отобразить меню опций
        /// </summary>
        /// <returns></returns>
        public static byte ShowOptionsMenu()
        {
            Utils.WriteOnCenter("Выбор режима игры");
            Utils.WriteOnCenter("1 Задать количество игроков");
            Utils.WriteOnCenter("2 Задать количество попыток ");
            Utils.WriteOnCenter("3 Задать верхнюю границу игрового числа");
            Utils.WriteOnCenter("4 Задать нижнюю границу игрового числа");
            Utils.WriteOnCenter("-----------------------");
            Utils.WriteOnCenter("0 Главное меню");

            return (byte)Utils.ReadInt();
        }

        /// <summary>
        /// Отобразить главное меню
        /// </summary>
        /// <returns></returns>
        public static byte ShowMainMenu()
        {
            Utils.WriteOnCenter("Настройки");
            Utils.WriteOnCenter("1 Одиночный");
            Utils.WriteOnCenter("2 Многопользовательский");
            Utils.WriteOnCenter("-----------------------");
            Utils.WriteOnCenter("3 Настройки");
            Utils.WriteOnCenter("0 Выход");

            return (byte)Utils.ReadInt();
        }


    }
}
