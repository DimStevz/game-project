using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor = Color.red;
    
    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        // Auto-get SpriteRenderer
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        startColor = sr.color;

        // Auto-fit collider to sprite
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        // Make collider match the sprite size
        if (sr != null && sr.sprite != null)
        {
            boxCollider.size = sr.sprite.bounds.size;
        }
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;
        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        if (towerToBuild == null) return;
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }

}