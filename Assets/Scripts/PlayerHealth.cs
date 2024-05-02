using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = health - 1;
        healthText.text = health.ToString();

    }

    public int GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collide");
        if (collision != null && collision.gameObject.CompareTag("Enemy"))
        {

            //Destroy(this.gameObject);
            //Destroy(collision.gameObject);
            SceneManager.LoadScene(2);


        }


    }


}
