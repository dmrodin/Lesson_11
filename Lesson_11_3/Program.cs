using System;

namespace Lesson_11_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonsterBattle battle = new MonsterBattle();

            battle.FirstMonster = battle.GenerateMonster();
            battle.SecondMonster = battle.GenerateMonster();

            battle.StartBattle();
        }
    }
}
