using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FullTextRPG
{
    enum Race { Human = 1, Elf, Dwarf }

    abstract class Item
    {
        public string Name;
    }

    class Weapon : Item
    {
        public int AttackBonus;
        public Weapon(string name, int bonus) { Name = name; AttackBonus = bonus; }
    }

    class Armor : Item
    {
        public int DefenseBonus;
        public Armor(string name, int bonus) { Name = name; DefenseBonus = bonus; }
    }

    class Potion : Item
    {
        public int HealAmount;
        public Potion(string name, int heal) { Name = name; HealAmount = heal; }
    }

    class Coin : Item
    {
        public int Amount;
        public Coin(int amount) { Name = $"{amount} монет"; Amount = amount; }
    }

    class Character
    {
        public string Name;
        public Race Race;
        public int Level = 1;
        public int Exp = 0;
        public int ExpToLevel = 100;
        public int MaxHP;
        public int HP;
        public int Attack;
        public int Defense;
        public int Agility;
        public int Height;
        public int Weight;
        public int StatPoints = 0;

        public Weapon EquippedWeapon = null;
        public Armor EquippedArmor = null;
        public List<Item> Inventory = new List<Item>();

        private static Random rand = new Random();

        public void GenerateStats()
        {
            switch (Race)
            {
                case Race.Human:
                    MaxHP = HP = rand.Next(80, 101);
                    Attack = rand.Next(10, 16);
                    Defense = rand.Next(5, 11);
                    Agility = rand.Next(10, 16);
                    Height = rand.Next(165, 191);
                    Weight = rand.Next(60, 91);
                    break;
                case Race.Elf:
                    MaxHP = HP = rand.Next(60, 81);
                    Attack = rand.Next(12, 18);
                    Defense = rand.Next(4, 9);
                    Agility = rand.Next(14, 21);
                    Height = rand.Next(160, 181);
                    Weight = rand.Next(50, 76);
                    break;
                case Race.Dwarf:
                    MaxHP = HP = rand.Next(90, 121);
                    Attack = rand.Next(14, 20);
                    Defense = rand.Next(8, 14);
                    Agility = rand.Next(6, 12);
                    Height = rand.Next(140, 161);
                    Weight = rand.Next(70, 101);
                    break;
            }
        }

        public void GainExp(int amount)
        {
            Exp += amount;
            Console.WriteLine($"Вы получили {amount} опыта!");
            while (Exp >= ExpToLevel)
            {
                Exp -= ExpToLevel;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            StatPoints += 5;
            ExpToLevel = (int)(ExpToLevel * 1.2);
            Console.WriteLine($"\nПоздравляем! Вы достигли уровня {Level}.");
            Console.WriteLine($"У вас {StatPoints} очков характеристик для распределения.");
            DistributeStatPoints();
        }

        public void ShowStats()
        {
            Console.WriteLine($"\n{Name} - Уровень {Level}");
            Console.WriteLine($"HP: {HP}/{MaxHP}  ATK: {Attack}  DEF: {Defense}  AGI: {Agility}");
            Console.WriteLine($"Рост: {Height} см  Вес: {Weight} кг");
            Console.WriteLine($"Оружие: {(EquippedWeapon != null ? EquippedWeapon.Name : "Нет")}");
            Console.WriteLine($"Броня: {(EquippedArmor != null ? EquippedArmor.Name : "Нет")}");
        }

        public void DistributeStatPoints()
        {
            while (StatPoints > 0)
            {
                ShowStats();
                Console.WriteLine($"\nОчки для распределения: {StatPoints}");
                Console.WriteLine("1-HP (+5 HP), 2-ATK (+1 ATK), 3-DEF (+1 DEF), 4-AGI (+1 AGI)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": MaxHP += 5; HP += 5; StatPoints--; break;
                    case "2": Attack += 1; StatPoints--; break;
                    case "3": Defense += 1; StatPoints--; break;
                    case "4": Agility += 1; StatPoints--; break;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\nИнвентарь:");
            if (Inventory.Count == 0) { Console.WriteLine("Пусто."); return; }
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Inventory[i].Name}");
            }
            Console.WriteLine("Введите номер предмета для использования/экипировки, или 0 для выхода.");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Inventory.Count)
            {
                Item item = Inventory[choice - 1];
                if (item is Potion)
                {
                    Potion p = item as Potion;
                    HP = Math.Min(MaxHP, HP + p.HealAmount);
                    Console.WriteLine($"Вы использовали {p.Name} и восстановили {p.HealAmount} HP.");
                    Inventory.Remove(p);
                }
                else if (item is Weapon) { EquippedWeapon = item as Weapon; Console.WriteLine($"Вы экипировали {item.Name}"); }
                else if (item is Armor) { EquippedArmor = item as Armor; Console.WriteLine($"Вы экипировали {item.Name}"); }
                else if (item is Coin) Console.WriteLine("Монеты нельзя экипировать.");
            }
        }
    }

    class Enemy
    {
        public string Name;
        public int HP;
        public int Attack;
        public int Defense;
        private static Random rand = new Random();

        public Enemy(int level)
        {
            string[] names = { "Гоблин", "Скелет", "Тролль", "Разбойник" };
            Name = names[rand.Next(names.Length)];
            HP = rand.Next(20, 31) + level * 5;
            Attack = rand.Next(5, 11) + level * 2;
            Defense = rand.Next(2, 6) + level;
        }
    }

    class Program
    {
        static Random rand = new Random();
        static int floor = 1;

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в текстовую RPG!");
            Character player = CreateCharacter();
            Console.WriteLine("\nВаш персонаж создан!");
            player.ShowStats();

            int roomNumber = 1;
            while (true)
            {
                Console.WriteLine($"\nЭтаж {floor}, комната {roomNumber}");
                string leftRoom = GenerateRoom();
                string rightRoom = GenerateRoom();

                string leftDesc = rand.Next(0, 2) == 0 ? "???" : leftRoom;
                string rightDesc = rand.Next(0, 2) == 0 ? "???" : rightRoom;
                Console.WriteLine($"(1) Слева: {leftDesc}");
                Console.WriteLine($"(2) Справа: {rightDesc}");
                Console.WriteLine("Куда пойти? 1-налево, 2-направо");

                string choice = Console.ReadLine();
                string roomType = choice == "1" ? leftRoom : rightRoom;

                HandleRoom(roomType, player);

                // Каждый N комнат поднимаем этаж
                if (roomNumber % 5 == 0) { floor++; Console.WriteLine($"\nВы поднимаетесь на этаж {floor}! Сложность увеличилась."); }

                Console.WriteLine("\nПродолжить исследование? (да/нет/инвентарь)");
                string cont = Console.ReadLine().ToLower();
                if (cont == "инвентарь") { player.ShowInventory(); continue; }
                if (cont != "да") break;

                roomNumber++;
            }

            Console.WriteLine("\nИгра завершена. Спасибо за игру!");
            SaveGame(player);
        }

        static Character CreateCharacter()
        {
            Console.WriteLine("Выберите расу:");
            Console.WriteLine("1 - Человек, 2 - Эльф, 3 - Дворф");
            Race race;
            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "1") { race = Race.Human; break; }
                if (choice == "2") { race = Race.Elf; break; }
                if (choice == "3") { race = Race.Dwarf; break; }
                Console.WriteLine("Неверный выбор, попробуйте снова.");
            }
            Character player = new Character { Race = race, Name = race.ToString() };
            player.GenerateStats();
            return player;
        }

        static string GenerateRoom()
        {
            int r = rand.Next(1, 4); // 1-бой, 2-отдых, 3-сундук
            switch (r)
            {
                case 1: return "battle";
                case 2: return "rest";
                case 3: return "chest";
            }
            return "rest";
        }

        static void HandleRoom(string type, Character player)
        {
            switch (type)
            {
                case "battle":
                    Enemy enemy = new Enemy(player.Level);
                    Console.WriteLine($"Вы встретили {enemy.Name}!");
                    Battle(player, enemy);
                    break;
                case "rest":
                    int heal = rand.Next(10, 21);
                    player.HP = Math.Min(player.MaxHP, player.HP + heal);
                    Console.WriteLine($"Комната отдыха. Восстановлено {heal} HP.");
                    if (player.StatPoints > 0) player.DistributeStatPoints();
                    break;
                case "chest":
                    int itemType = rand.Next(0, 4);
                    if (itemType == 0)
                    {
                        Weapon w = new Weapon("Меч", rand.Next(2, 6));
                        player.Inventory.Add(w);
                        Console.WriteLine($"Вы нашли оружие: {w.Name} (+{w.AttackBonus} ATK)");
                    }
                    else if (itemType == 1)
                    {
                        Armor a = new Armor("Кираса", rand.Next(1, 4));
                        player.Inventory.Add(a);
                        Console.WriteLine($"Вы нашли броню: {a.Name} (+{a.DefenseBonus} DEF)");
                    }
                    else if (itemType == 2)
                    {
                        Potion p = new Potion("Зелье", 20);
                        player.Inventory.Add(p);
                        Console.WriteLine($"Вы нашли зелье на {p.HealAmount} HP");
                    }
                    else
                    {
                        Coin c = new Coin(rand.Next(5, 21));
                        player.Inventory.Add(c);
                        Console.WriteLine($"Вы нашли {c.Amount} монет!");
                    }
                    break;
            }
        }

        static void Battle(Character player, Enemy enemy)
        {
            while (player.HP > 0 && enemy.HP > 0)
            {
                Console.WriteLine($"\nВаш HP: {player.HP}/{player.MaxHP} | {enemy.Name} HP: {enemy.HP}");
                Console.WriteLine("1-Атаковать, 2-Использовать зелье, 3-Уклонение, 4-Инвентарь");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        int crit = rand.Next(0, 100) < 10 ? 2 : 1; // 10% шанс крита
                        int dmg = Math.Max(0, (player.Attack + (player.EquippedWeapon?.AttackBonus ?? 0)) * crit - enemy.Defense);
                        enemy.HP -= dmg;
                        Console.WriteLine($"Вы нанесли {dmg} урона {(crit == 2 ? "(Крит!)" : "")}.");
                        break;
                    case "2":
                        Potion potion = null;
                        foreach (var item in player.Inventory)
                            if (item is Potion) { potion = item as Potion; break; }
                        if (potion != null)
                        {
                            player.HP = Math.Min(player.MaxHP, player.HP + potion.HealAmount);
                            Console.WriteLine($"Вы использовали {potion.Name} и восстановили {potion.HealAmount} HP");
                            player.Inventory.Remove(potion);
                        }
                        else { Console.WriteLine("Зелий нет!"); continue; }
                        break;
                    case "3":
                        int evade = player.Agility * 2 - enemy.Attack;
                        if (rand.Next(0, 100) < evade) { Console.WriteLine("Уклонение успешно!"); continue; }
                        else Console.WriteLine("Уклонение не удалось."); break;
                    case "4": player.ShowInventory(); continue;
                    default: Console.WriteLine("Неверное действие"); continue;
                }

                if (enemy.HP > 0)
                {
                    int enemyDmg = Math.Max(0, enemy.Attack - player.Defense - (player.EquippedArmor?.DefenseBonus ?? 0));
                    player.HP -= enemyDmg;
                    Console.WriteLine($"{enemy.Name} атакует и наносит {enemyDmg} урона!");
                }
            }

            if (player.HP <= 0)
            {
                Console.WriteLine("Вы погибли...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Вы победили {enemy.Name}!");
                player.GainExp(50);
            }
        }

        static void SaveGame(Character player)
        {
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("savegame.json", json);
            Console.WriteLine("Игра сохранена в savegame.json");
        }
    }
}
