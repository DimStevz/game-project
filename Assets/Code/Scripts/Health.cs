using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int coinValue = 10;

    private bool isDestroyed = false;

    public void TakeDamage(int damage){
        hitPoints -= damage;

        if(hitPoints <= 0 && !isDestroyed){
            EnemySpawner.onEnemyDestroy.Invoke();
            Levelmanager.main.IncreaseCoin(coinValue);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
