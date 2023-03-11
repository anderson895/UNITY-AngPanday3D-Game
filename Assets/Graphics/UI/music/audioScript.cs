using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    public AudioSource backgroundAudio;
    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio.Play();
    }

   
}
