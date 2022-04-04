using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_3
{
    enum MonsterType { Dragon, Orc, Undead, Construct, Demon, Mutant, Animal, Human, Unidentified }
    class Monster
    {
        private string name;
        private int hp;
        private int maxHP;
        private int minAttack;
        private int maxAttack;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty) throw new Exception("Имя обзятальное поле");
                else name = value;
            }
        }
        public MonsterType Type { get; set; }
        public int HP
        {
            get { return hp; }
            set
            {
                if (value < 0 || value > 500) throw new Exception("Не валидное значение");
                else hp = value;
            }
        }
        public int MaxHP
        {
            get { return maxHP; }
            set
            {
                if (value < 0 || value > 500) throw new Exception("Не валидное значение");
                else maxHP = value;
            }
        }
        public int MinAttack
        {
            get { return minAttack; }
            set
            {
                if (value < 1 || value > 10) throw new Exception("Не валидное значение");
                else minAttack = value;
            }
        }
        public int MaxAttack
        {
            get { return maxAttack; }
            set
            {
                if (value < 20 || value > 100) throw new Exception("Не валидное значение");
                else maxAttack = value;
            }
        }
        public string WarCry { get; set; }
        public string DieCry { get; set; }
        public string TypeText
        {
            get
            {
                return GetMonsterTypeName(Type);
            }
        }
        public bool IsDie
        {
            get { return !(HP > 0); }
        }

        #region Constructors
        public Monster()
        {
            Name = "Безымянный";
            Type = MonsterType.Unidentified;
            HP = 0;
            MaxHP = 500;
            MinAttack = 1;
            MaxAttack = 100;
        }

        public Monster(string name, MonsterType type, int hp) :this()
        {
            Name = name;
            Type = type;
            HP = hp;
        }

        public Monster(string name, MonsterType type, int hp, int maxHP, int minAttack, int maxAttack) :this(name, type, hp)
        {
            MaxHP = maxHP;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
        }
        #endregion

        #region PublicMethods

        public override string ToString()
        {
            return $"Имя: {Name} \n" +
                   $"Тип: {TypeText} \n" +
                   $"HP: {HP} \n" +
                   $"Атака: {MinAttack} - {MaxAttack}";
        }

        public int GetAttack(int bonus)
        {
            Random rnd = new Random();

            return rnd.Next(MinAttack, MaxAttack) + bonus;
        }

        public void Wounds(int damage)
        {
            if (HP - damage < 0) HP = 0;
            else HP -= damage;
        }

        public void Heal()
        {
            HP = MaxHP;
        }

        #endregion

        #region PrivateMethods

        private string GetMonsterTypeName(MonsterType monsterType)
        {
            switch (monsterType)
            {
                case MonsterType.Dragon: return "Дракон"; break;
                case MonsterType.Orc: return "Орк"; break;
                case MonsterType.Undead: return "Нежить";
                case MonsterType.Construct: return "Механизм"; break;
                case MonsterType.Demon: return "Демон"; break;
                case MonsterType.Mutant: return "Мутант"; break;
                case MonsterType.Animal: return "Животное"; break;
                case MonsterType.Human: return "Человек"; break;
            }
            return "Неопознанный";
        }
        

        #endregion

    }
}
