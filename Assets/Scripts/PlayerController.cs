using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{   /**
     * Called before rendering a frame. Most of the game code is located here.
     */
    void Update()
    {

    }

    public float speed;
	public Text countText;
	public Text winText;

    private Rigidbody rb; // Create the variable to hold the reference
	private int count;

    /**
     * Setting the reference.  All the code here is called on the first frame the script is active.
     * Usually the first frame of the game.
     */
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
    }

    /**
     * Called before performing any Physics calculations. Physics code goes here.
     * (i.e. Moving the ball)
     */
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
        }
    }

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 11) {
			winText.text = "You Win!";
		}
	}
}

