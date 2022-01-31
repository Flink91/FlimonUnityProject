using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{

    public Animation camIntroAnimation;
    public GameObject ui;

    private bool animEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        camIntroAnimation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroEndEvent()
    {
        animEnded = true;
        ui.SetActive(true);
    }
}
