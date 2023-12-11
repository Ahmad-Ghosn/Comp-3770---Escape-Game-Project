using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AIController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public Animator animator;
    public bool IsBoss;
    private float distance;
    public int attackcount = 1;
    public GameObject Key;
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= 0.15f)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsAttacking", true);
                SceneManager.LoadScene(0);
            }
            else
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalking", true);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
        if(distance<=0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void UpdateHelath()
    {
        attackcount--;
        if(attackcount<=0)
        {
            if(IsBoss)
            {
                Key.SetActive(true);

            }
            Destroy(this.gameObject);

        }
    }
    //public Transform[] waypoints;
    //public float moveSpeed = 2f;
    //public float idleTime = 2f;

    //private Animator animator;
    //private int currentWaypointIndex = 0;
    //private Vector3 currentTarget;
    //private bool isMoving = false;

    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    if (waypoints.Length > 0)
    //    {
    //        SetRandomWaypoint();
    //        isMoving = true;
    //    }
    //}

    //void Update()
    //{
    //    if (isMoving)
    //    {
    //        MoveTowardsWaypoint();
    //    }
    //}

    //void MoveTowardsWaypoint()
    //{
    //    Vector3 direction = (currentTarget - transform.position).normalized;
    //    transform.Translate(direction * moveSpeed * Time.deltaTime);

    //    if (direction != Vector3.zero)
    //    {
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    }

    //    animator.SetFloat("Speed", moveSpeed);

    //    if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
    //    {
    //        isMoving = false;
    //        animator.SetFloat("Speed", 0f);
    //        StartCoroutine(IdleAndSelectWaypoint());
    //    }
    //}

    //IEnumerator IdleAndSelectWaypoint()
    //{
    //    animator.SetBool("IsIdle", true);
    //    yield return new WaitForSeconds(idleTime);
    //    animator.SetBool("IsIdle", false);
    //    SetRandomWaypoint();
    //    isMoving = true;
    //}

    //void SetRandomWaypoint()
    //{
    //    int randomIndex = Random.Range(0, waypoints.Length);
    //    currentWaypointIndex = randomIndex;
    //    currentTarget = waypoints[currentWaypointIndex].position;
    //}
}
