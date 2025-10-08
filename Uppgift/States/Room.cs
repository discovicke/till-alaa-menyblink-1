namespace Uppgift;

using System;
using System.Collections.Generic;

public class Room
{
    public string roomName;
    public string? roomDescription;
    public IEntitet? enemy;     // can be null if the room is empty
    public string? puzzle;      // can be null if no puzzle exists

    private static Random rand = new Random();

    public Room(string name, string? description = null, IEntitet? enemy = null, string? puzzle = null)
    {
        roomName = name;
        roomDescription = description;
        this.enemy = enemy;
        this.puzzle = puzzle;
    }

    public void Enter(Character playerCharacter)
    {
        Console.WriteLine($"\n--- Du går in i {roomName} ---");
        if (!string.IsNullOrEmpty(roomDescription))
        {
            Console.WriteLine(roomDescription);
        }

        if (enemy != null)
        {
            // Enemy could be Enemy, Rogue, etc.
            string enemyName;
            if (this.enemy is Enemy enemy)
            {
                enemyName = enemy.name;
            }
            else if (this.enemy is Character existingCharacter)
            {
                enemyName = existingCharacter.characterName ?? "Okänd";
            }
            else
            {
                enemyName = "Okänd fiende";
            }
            Console.WriteLine($"⚔️ En {enemyName} dyker upp!");
            StartCombat(playerCharacter, this.enemy);
        }
        else if (puzzle != null)
        {
            Console.WriteLine($"🧩 Du stöter på en gåta: {puzzle}");
            SolvePuzzle(playerCharacter);
        }
        else
        {
            Console.WriteLine("Rummet verkar tomt...");
        }
    }

    private void StartCombat(Character playerCharacter, IEntitet enemy)
    {
        Console.WriteLine("Strid startar!");

        // Get health and names
        int playerHP = playerCharacter.hitPoints;
        // Sätt spelarens namn, eller "Spelare" om det saknas
        string playerName = playerCharacter.characterName ?? "Spelare";

        // Kolla vilket typ av objekt 'enemy' är och hämta rätt HP
        int enemyHP;
        if (enemy is Enemy en)
        {
            enemyHP = en.health;
        }
        else if (enemy is Character ch)
        {
            enemyHP = ch.hitPoints;
        }
        else
        {
            enemyHP = 10; // standardvärde
        }

        // Kolla vilket typ av objekt 'enemy' är och hämta rätt namn
        string enemyName;
        if (enemy is Enemy en2)
        {
            enemyName = en2.name;
        }
        else if (enemy is Character ch2)
        {
            enemyName = ch2.characterName ?? "Okänd";
        }
        else
        {
            enemyName = "Okänd fiende";
        }

        while (playerHP > 0 && enemyHP > 0)
        {
            // Player attacks
            int playerDamage = 1;
            if (playerCharacter.equippedWeapon != null)
            {
                playerDamage = playerCharacter.equippedWeapon.RollDamage();
            }
            
            enemyHP -= playerDamage;
            Console.WriteLine($"{playerName} gör {playerDamage} skada!");

            if (enemyHP <= 0)
            {
                Console.WriteLine($"{enemyName} besegrades!");
                break;
            }

            // Enemy attacks
            int enemyDamage = 1;
            if (enemy is Enemy en3 && en3.equippedWeapon != null)
            {
                enemyDamage = en3.equippedWeapon.RollDamage();
            }
            else if (enemy is Character ch3 && ch3.equippedWeapon != null)
            {
                enemyDamage = ch3.equippedWeapon.RollDamage();
            }

            playerHP -= enemyDamage;
            Console.WriteLine($"{enemyName} gör {enemyDamage} skada!");

            if (playerHP <= 0)
            {
                Console.WriteLine("Du har dött!");
            }
        }

        // Update actual hitpoints if needed
        playerCharacter.hitPoints = playerHP;
        if (enemy is Enemy en4) en4.health = enemyHP;
        if (enemy is Character ch4) ch4.hitPoints = enemyHP;
    }

    
    private void SolvePuzzle(Character playerCharacter)
    {
        //TODO Skapa en pussel-klass
        Console.WriteLine("Tyvärr, gåtor är inte implementerade än – men du känner dig lite smartare!");
    }

    public static Room GenerateRandomRoom(List<string> names, List<IEntitet> possibleEnemies, List<string> puzzles)
    {
        //TODO generera nya rum.
        string name = names[rand.Next(names.Count)];

        bool hasEnemy = rand.NextDouble() < 0.5;
        bool hasPuzzle = !hasEnemy && rand.NextDouble() < 0.3;

        IEntitet? enemy = hasEnemy ? possibleEnemies[rand.Next(possibleEnemies.Count)] : null;
        string? puzzle = hasPuzzle ? puzzles[rand.Next(puzzles.Count)] : null;

        string description = $"Du känner en konstig stämning i {name}.";

        return new Room(name, description, enemy, puzzle);
    }
}

