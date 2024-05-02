using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public int enemiesKilled;
    private void Awake()
    {
        //Debug.Log("I have awaken");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        //transform.position = (new Vector3(transform.position.x + 556.0f, transform.position.y, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("poopoo peepee");
        //gameObject.transform.Rotate(new Vector3(5.0f, 5.0f));

        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        Debug.Log(horizontalDirection);
        Debug.Log(verticalDirection);
        transform.Translate(speed * Time.deltaTime * new Vector2(horizontalDirection, verticalDirection));
        //transform.position = (new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z));

        if (enemiesKilled >= 10)
        {
            SceneManager.LoadScene(2);
        }

    }
}
