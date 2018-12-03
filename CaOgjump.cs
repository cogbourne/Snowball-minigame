using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaOgjump : MonoBehaviour

{

    public AudioSource Jump;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump.Play();
    }
}

