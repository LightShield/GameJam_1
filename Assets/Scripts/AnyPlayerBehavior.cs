using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyPlayerBehavior: MonoBehaviour
{
    public float movmentSpeed = 1f;
    public float rotateSpeed = 100f;
    public Rigidbody player;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //used for overide (enable specific correction for player \ enemy)
    virtual public void OnTriggerEnter(Collider other){}
}
