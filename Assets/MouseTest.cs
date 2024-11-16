using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        
        // Debug component setup
        Debug.Log("SpriteRenderer exists: " + (spriteRenderer != null));
        Debug.Log("BoxCollider2D exists: " + (boxCollider2D != null));
    }

    void Update()
    {
        // Convert mouse position to world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        // Cast a ray from mouse position
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        
        if (hit.collider != null)
        {
            Debug.Log("Hit something: " + hit.collider.gameObject.name);
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        // Debug mouse position
        Debug.Log("Mouse World Position: " + mousePos);
    }
}