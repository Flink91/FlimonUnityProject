using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
       FindObjectOfType<AudioManager>().Play("Music1");
       // StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("Music1"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
