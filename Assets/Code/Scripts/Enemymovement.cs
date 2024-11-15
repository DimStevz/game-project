using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is not attached to the GameObject.");
        }
        target = Levelmanager.main.path[pathIndex];
    }

    
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < 0.1f)
        {
            pathIndex++;
            if(pathIndex >= Levelmanager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }else
            {
                target = Levelmanager.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
}