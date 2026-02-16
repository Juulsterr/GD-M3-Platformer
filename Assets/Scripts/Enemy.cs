using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] Points;
    private int i;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, Points[i].position);
       // Debug.Log(dist);
        if (dist < 0.25f)
        {
        // Debug.Log("moving to next point "+i);
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }

        // Debug.Log(" speed * Time.deltaTime "+ speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, Points[i].position, speed * Time.deltaTime);
            
            spriteRenderer.flipX = (transform.position.x - Points[i].position.x) < 0;
    }
}