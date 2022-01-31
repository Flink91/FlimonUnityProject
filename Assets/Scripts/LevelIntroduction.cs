using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelIntroduction : MonoBehaviour
{

    public Animation camIntroAnimation;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        camIntroAnimation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CamIntroEnd()
    {
    }
}
