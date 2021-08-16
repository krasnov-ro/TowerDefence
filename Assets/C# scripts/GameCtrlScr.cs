using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower
{
    public string Name, Text;
    public int type, Price;
    public float range, Cooldown, CurrCooldown = 0;
    public Sprite Spr;

    public Tower(string Name, string text, int type, int Price, float range, float cd, string sprPath)  
    {
        this.type = type;
        this.Name = Name;
        this.Text = text;
        this.range = range;
        this.Cooldown = cd;
        this.Price = Price;
        Spr = Resources.Load<Sprite>(sprPath);
    }

    public Tower(Tower other)
    {
        type = other.type;
        Name = other.Name;
        Text = other.Text;
        range = other.range;
        Cooldown = other.Cooldown;
        Price = other.Price;
        Spr = other.Spr;
    }
}

public class TowerProjectile
{
    public float speed;
    public int damage;

    public TowerProjectile(float speed, int dmg)
    {
        this.speed = speed;
        damage = dmg;
    }
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}

public class Enemy
{
    public float Health, Speed, StartSpeed;
    public Sprite Spr;

    public Enemy(float health,  float speed, string sprPath)
    {
        Health = health;
        StartSpeed = Speed = speed;
        Spr = Resources.Load<Sprite>(sprPath);
    }
    public Enemy(Enemy other)
    {
        Health = other.Health;
        StartSpeed = Speed = other.StartSpeed;
        Spr = other.Spr;
    }
}


public class GameCtrlScr : MonoBehaviour
{
    public List<Tower> AllTowers = new List<Tower>();
    public List<TowerProjectile> AllTowersProjectiles = new List<TowerProjectile>();
    public List<Enemy> AllEnemies = new List<Enemy>();

    private void Awake()
    {
        AllTowers.Add(new Tower("Замораживающая", "Эта башня замедляет врагов", 0, 100, 2, .3f, "TowerSprites/tower1_1lvl"));
        AllTowers.Add(new Tower("Мощная", "Эта башня бьет по области", 1, 200, 5, 1, "TowerSprites/tower2_1lvl"));

        AllTowersProjectiles.Add(new TowerProjectile(7, 10));
        AllTowersProjectiles.Add(new TowerProjectile(5, 30));

        AllEnemies.Add(new Enemy(20, 4, "EnemiesSprites/enemy_nofly"));
        AllEnemies.Add(new Enemy(80, 1, "EnemiesSprites/enemy_fly"));
    }
}
