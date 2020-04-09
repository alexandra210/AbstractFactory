using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Армия
    abstract class Army
    {
        public abstract void Commandor(); //Главнокомандующий
        public abstract void General(); //Генерал
        public abstract void CommonSoldier(); //Рядовой
    }

    //Армия Эльфов
    class ElfsArmy : Army
    {
        public override void Commandor()
        {
            Console.WriteLine("Главнокомандующий-эльф отдает приказы эльфу-генералу");
        }

        public override void General()
        {
            Console.WriteLine("Эльф-генерал получает распоряжение от главнокомандующего-эльфа и руководит эльфами-солдатами");
        }

        public override void CommonSoldier()
        {
            Console.WriteLine("Эльфы-солдаты бесшумно бегут в бой");
        }
    }

    //Армия Орков
    class OrcsArmy : Army
    {
        public override void Commandor()
        {
            Console.WriteLine("Главнокомандующий орк отдает приказы орку-генералу");
        }

        public override void General()
        {
            Console.WriteLine("Орк-генерал получает распоряжение от главнокомандующего-орка и руководит орками-солдатами");
        }

        public override void CommonSoldier()
        {
            Console.WriteLine("Орки-солдаты несутся в бой");
        }
    }

    // Оружие
    abstract class Weapon
    {
        public abstract void ToStrike(); //Нанести удар
    }

    class Bow : Weapon //Класс лук со стрелами
    {
        public override void ToStrike()
        {
            Console.WriteLine("Стреляют из лука");
        }
    }

    class Ax : Weapon //Класс топор
    {
        public override void ToStrike()
        {
            Console.WriteLine("Рубят топором");
        }
    }

    // Абстрактная Фабрика
    abstract class CharacterFactory
    {
        public abstract Army CreateArmy(); //Создаем армию
        public abstract Weapon CreateWeapon(); //Создаем оружие
    }

    //Создание армии эльфов, которые стреляют из лука
    class Elfs : CharacterFactory
    {
        public override Army CreateArmy()
        {
            return new ElfsArmy();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }
    }

    //Создание армии окров, которые рубят топором
    class Orcs : CharacterFactory
    {
        public override Army CreateArmy()
        {
            return new OrcsArmy();
        }

        public override Weapon CreateWeapon()
        {
            return new Ax();
        }
    }

    //Создание персонажа
    class Character
    {
        private Weapon weapon;
        private Army commandor, general, soldier;

        public Character(CharacterFactory character)
        {
            commandor = character.CreateArmy();
            general = character.CreateArmy();
            soldier = character.CreateArmy();

            weapon = character.CreateWeapon();
        }

        public void Army()
        {
            commandor.Commandor();
            general.General();
            soldier.CommonSoldier();
        }

        public void ToStike()
        {
            weapon.ToStrike();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Character elfs = new Character(new Elfs());
            Console.WriteLine("Армия Эльфов: ");
            elfs.Army();
            Console.WriteLine("\nБоевые навыки: ");
            elfs.ToStike();

            Console.WriteLine("\n *** \n");

            Character orcs = new Character(new Orcs());
            Console.WriteLine("Армия Орков: ");
            orcs.Army();
            Console.WriteLine("\nБоевые навыки: ");
            orcs.ToStike();
            
            Console.ReadKey();        
        }
    }
}

