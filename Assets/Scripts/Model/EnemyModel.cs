using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class EnemyModel : MonoBehaviour
{
    public AIPath aiPath;    

    [SerializeField] protected float cooldown;

    protected int health = 3;

    public bool isStunned = false;
    public bool isHitted = false;

    public abstract void DisableMovement();
    public abstract void EnableMovement();

    protected abstract void OnCollisionEnter2D(Collision2D collision);
    protected abstract void OnTriggerEnter2D(Collider2D other);
    protected abstract void OnTriggerExit2D(Collider2D other);

    public abstract void DecreaseHealthPoints();

    protected abstract IEnumerator AttackCooldown();
    protected abstract IEnumerator StunCoroutine();
}
