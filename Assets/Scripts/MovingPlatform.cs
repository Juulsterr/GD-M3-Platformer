using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] Points;
    private int i;
    void Start()
    {
        transform.position = Points[0].position;
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, Points[i].position);
       // Debug.Log(dist);
        if (dist < 0.01f)
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
    }
            private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
        
    }
}
