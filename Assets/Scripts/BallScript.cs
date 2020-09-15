using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 0f, -1 * speed * Time.deltaTime);
        if (transform.position.z < -13.0f)
        {
            //Debug.Log("Game Over");
            //Time.timeScale = 0;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Paddle"))
        {
            //Destroy(gameObject);
            speed *= -1; //弾性衝突で跳ね返す
            collision.gameObject.transform.localScale -= new Vector3(Random.Range(-1.0f, 1.0f), 0f, 0f);
            if(collision.gameObject.transform.localScale.x < 2.0f)
            {
                collision.gameObject.transform.localScale = new Vector3(2.0f, 1.0f, 1.0f);
            }
            if (collision.gameObject.transform.localScale.x > 5.0f)
            {
                collision.gameObject.transform.localScale = new Vector3(5.0f, 1.0f, 1.0f);
            }
        }

        if(collision.gameObject.CompareTag("ClearWall+"))
        {
            //Destroy(gameObject);
            transform.position += new Vector3(0f, -1 * speed * Time.deltaTime, 0f);
        }
        if (collision.gameObject.CompareTag("ClearWall-"))
        {
            //Destroy(gameObject);
            transform.position += new Vector3(0f, -1 * speed * Time.deltaTime, 0f);
        }

    }

}
