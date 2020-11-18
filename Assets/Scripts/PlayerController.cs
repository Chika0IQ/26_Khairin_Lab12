using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;


    private int coinCount;
    private int totalCoin;
    public GameObject CoinCollected;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        //Winning Conditions
        if (coinCount == totalCoin)
        {
            SceneManager.LoadScene("WinScene");
        }

        //Losing Conditions
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void PlayerMovement()
    {
        //Forward Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Left Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        //Backward Movement
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Right Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinCount++;

            CoinCollected.GetComponent<Text>().text = "CoinCollected: " + coinCount;
            Destroy(other.gameObject);
        }
    }
}
