using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController : MonoBehaviour
{
    public float fallingSpeed = 2.0f;
    
    public float horizontalRangeMin = -9f;
    
    public float horizontalRangeMax = 9f;
    
    public float endZ = -10.0f;
    
    public Vector2 startLocation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //CheckRespawn();
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallingSpeed * Time.deltaTime));
    }

    private void CheckRespawn()
    {
        if (transform.position.y < endZ)
        {
            // Respawn at a random X
            float newX = Random.Range(horizontalRangeMin, horizontalRangeMax);
            transform.position = new Vector2(newX, startLocation.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collide");
        Debug.Log("hit");
        if (collision != null && collision.gameObject.CompareTag("Missile"))
        {
            //GameManager.Instance.SetPlayerPoints(1);
            GameObject.Find("Player").GetComponent<PlayerController>().enemiesKilled += 1;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }


}
