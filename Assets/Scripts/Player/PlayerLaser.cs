using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    Player player;
    int damage = 50;
    [SerializeField] float projectileSpeed = 10f;
    GameObject projectileParent;
    const string PLAYER_PROJECTILES = "Player Projectiles";

    private void Start()
    {
        player = FindObjectOfType<Player>();
        damage = player.GetProjectileDamage();
        CreateProjectileParent();
        transform.parent = projectileParent.transform;
    }
    public int DealDamage()
    {
        Destroy(gameObject);
        return damage;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PLAYER_PROJECTILES);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PLAYER_PROJECTILES);
        }
    }
}
