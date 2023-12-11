using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Transform attackPoint;   // The point where the attack will originate.
    public LayerMask enemyLayer;    // The layer that represents enemies.
    public float attackRange = 1f;  // The range of the sword attack.
    public Animator animator;       // Reference to the animator for playing attack animations.
    public SpriteRenderer spriteRenderer;
  
    // Update is called once per frame
    void Update()
    {
        //// Check for player input to trigger the attack
        if (Input.GetMouseButtonDown(0))  // Assuming left mouse button for attack
        {
            // Determine the direction of the attack based on player's local scale
            if (!spriteRenderer.flipX)
            {
                // Player is facing right
                Attack(Vector2.right);
                //spriteRenderer.flipX = false;
            }
            else
            {
                // Player is facing left
                Attack(Vector2.left);
               // spriteRenderer.flipX = true;

            }
        }
    }

    void Attack(Vector2 direction)
    {
        // Play attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in the attack range using raycasting
        RaycastHit2D[] hits = Physics2D.RaycastAll(attackPoint.position, direction, attackRange, enemyLayer);

        // Process each hit
        foreach (RaycastHit2D hit in hits)
        {
            // Check if the hit object has an EnemyController component
            AIController enemy = hit.collider.GetComponent<AIController>();
            if (enemy != null)
            {
                //SoundManager.Instance.CoinSound();
                // UnlockCreature.Instance.Unlock(enemy.Index);
                enemy.UpdateHelath();
                //Destroy(hit.collider.gameObject);
                // Perform attack on the enemy (you can customize this based on your game's logic)
               // enemy.TakeDamage(1);  // Assuming enemies have a TakeDamage method
            }
        }
    }

    // You might want to visualize the attack range using Gizmos for debugging purposes
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        // Determine the direction of the attack based on player's local scale
        Vector2 direction = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;

        Gizmos.DrawRay(attackPoint.position, direction * attackRange);
    }
}
