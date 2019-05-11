using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    const string PICK_UP_TAG = "Pick Up";
    public float speed;
    private int pickUpsCount;
    public Text pointsText;
    public Text winText;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickUpsCount = 0;
        foreach (GameObject pickUp in GameObject.FindGameObjectsWithTag(PICK_UP_TAG))
        {
            pickUpsCount += 1;
        }
        updatePointsText();
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        if (pickUpsCount == 0)
        {
            winText.gameObject.SetActive(true);
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
}
