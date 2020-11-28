using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource moo;
    public AudioSource baa;
    public AudioSource bumpShips;
    public AudioSource bumpBoundary;
    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMoo()
    {
        moo.Play();
    }
    public void playBaa()
    {
        baa.Play();
    }
    public void playBumpShips()
    {
        bumpShips.Play();
    }
    public void playBumpBoundary()
    {
        bumpBoundary.Play();
    }
}
