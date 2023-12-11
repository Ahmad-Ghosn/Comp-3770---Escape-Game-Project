using System.Collections;
using UnityEngine;

public class RandomMovementAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -5f; // Adjust these values based on your bounding area
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private Rigidbody2D rb;
    public bool isFacingRight = true;

    public int Index;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveRandomly();
    }

    void MoveRandomly()
    {
        Vector2 randomTarget = GetRandomPosition();

        StartCoroutine(MoveToTarget(randomTarget));
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    IEnumerator MoveToTarget(Vector2 target)
    {
        // Determine whether to flip based on the movement direction
        if ((target.x < rb.position.x && isFacingRight) || (target.x > rb.position.x && !isFacingRight))
        {
            Flip();
        }

        while (Vector2.Distance(rb.position, target) > 0.1f)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime));
            yield return null;
        }

        // Wait for a short time before picking the next random target
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        // Get a new random target and continue moving
        MoveRandomly();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
