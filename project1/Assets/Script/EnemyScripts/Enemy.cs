using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
        }

    }

    public void Knock(Rigidbody2D myRigid, float knockTime, float damage)
    {
        StartCoroutine(knockCo(myRigid, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator knockCo(Rigidbody2D myRigid, float knockTime)
    {
        if (myRigid != null )
        {
            yield return new WaitForSeconds(knockTime);
            myRigid.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigid.velocity = Vector2.zero;
        }

    }
}
