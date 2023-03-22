using System;
using UnityEngine;

[Serializable]
public class Character
{
    public GameObject prefab;

    public string name;
    public GameObject mouse;
    public int maxHealth;
    public int curHealth;
    public int score = 0;
    public HealthBar healthBar;
}
