using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public Text endText;
    public Text countText;
    public Text winText;
    
    //This handles an internal timer
    private float timer;
    private int wholetime;
    private int count;
    private Rigidbody2D rb2d;

    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        //Initialize count to zero.
        count = 0;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        winText.text = "";
        endText.text = "";

        //Call our SetCountText function which will update the text with the current value for count.
        SetCountText();

    }

    void FixedUpdate()
    {

        //This does a timer before ending the game after 10 seconds.
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Win! :)";
            StartCoroutine(ByeAfterDelay(2));

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            // add a point to the game
            // GameLoader.AddScore(1);

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }
    }
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
          countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 1)
        {
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));



        }
    }
        IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        //GameLoader.gameOn = false;
    }
}
