using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Lesson_11_3
{
    class MonsterBattle
    {
        private Monster firstMonster;
        private Monster secondMonster;
        

        public Monster FirstMonster { set { firstMonster = value; } }
        public Monster SecondMonster { set { secondMonster = value; } }
        public MonsterBattle(Monster firstMonster, Monster secondMonster)
        {
            this.firstMonster = firstMonster;
            this.secondMonster = secondMonster;
        }

        public MonsterBattle()
        {

        }

        public void StartBattle()
        {
            PrintBattleMessage($"На арене:\n {firstMonster.ToString()}");
            Console.WriteLine("----------------------");
            PrintBattleMessage($"Против:\n {secondMonster.ToString()}");
            Console.WriteLine("----------------------");

            PrintBattleMessage($"{firstMonster.Name} рычит");
            PrintBattleMessage($"{secondMonster.Name} рычит");

            Random rnd = new Random();

            while (true)
            {
                if (IsFinallHit(firstMonster, secondMonster, firstMonster.GetAttack(rnd.Next(0, 10)))) break;
                if (IsFinallHit(secondMonster, firstMonster, secondMonster.GetAttack(rnd.Next(0, 10)))) break;
            }
        }
        public Monster GenerateMonster()
        {
            Monster monster = new()
            {
                Name = GetMonsterName(),
                Type = GetMonsterType(),
                HP = 200,
                MaxHP = 200,
                MinAttack = GetRandomInt(1, 10),
                MaxAttack = GetRandomInt(20, 100),
                WarCry = GetMonsterWarCry(),
                DieCry = GetMonsterDieCry()
            };

            return monster;
        }
        private bool IsFinallHit(Monster firstMonster, Monster secondMonster, int damage)
        {
            PrintBattleMessage($"{firstMonster.Name} наносит удар {damage} единиц");

            secondMonster.Wounds(damage);

            if (secondMonster.IsDie)
            {
                PrintBattleMessage($"{secondMonster.Name} трагически погибает с предсмертным криком: {secondMonster.DieCry}");
                PrintBattleMessage($"{firstMonster.Name} празднует победу боевым ревом: {firstMonster.WarCry}");
                return true;
            }

            return false;
        }

        private void PrintBattleMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
        }
        private string GetMonsterName()
        {
            return GetValueFromText(Properties.Resources.MonsterNames, ','); 
        }
        private MonsterType GetMonsterType()
        {
            return (MonsterType)Enum.GetValues(typeof(MonsterType)).GetValue(GetRandomInt(8));
        }
        private string GetMonsterWarCry()
        {
            return GetValueFromText(Properties.Resources.WarCry, ';');
        }
        private string GetMonsterDieCry()
        {
            return GetValueFromText(Properties.Resources.DieCry, ';');
        }
        private string GetValueFromText(string text, char separator)
        {
            string[] array = text.Split(separator);

            return array[GetRandomInt(array.Length - 1)];
        }
        private int GetRandomInt(int maxValue)
        {
            Random rnd = new Random();

            return rnd.Next(maxValue);
        }
        private int GetRandomInt(int minValue, int maxValue)
        {
            Random rnd = new Random();

            return rnd.Next(minValue, maxValue);
        }
    }
}
