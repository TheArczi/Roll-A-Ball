using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    const string PICK_UP_TAG = "Pick Up";
    public float speed;
    public Text pointsText;
    public Text centerText;
    public GameObject background;
    private Rigidbody rb;
    private Transform playerTransform;
    private int pickUpsCount;
    private GameObject[] pickUpObjects;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        pickUpsCount = 0;
        pickUpObjects = GameObject.FindGameObjectsWithTag(PICK_UP_TAG);
        foreach (GameObject pickUp in pickUpObjects)
        {
            pickUpsCount += 1;
        }
        updatePointsText();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            restartGame();
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        if (pickUpsCount == 0)
        {
            background.gameObject.SetActive(true);
            centerText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickUpsCount -= 1;
            updatePointsText();
        }
    }

    private void updatePointsText()
    {
        pointsText.text = pickUpsCount.ToString();
    }

    private void restartGame()
    {
        playerTransform.position = new Vector3(0.0f, 0.5f, 0.0f);
        pickUpsCount = 0;
        foreach (GameObject pickUp in pickUpObjects)
        {
            pickUpsCount += 1;
            pickUp.gameObject.SetActive(true);
        }
        background.gameObject.SetActive(false);
        centerText.gameObject.SetActive(false);
        updatePointsText();
    }
}
