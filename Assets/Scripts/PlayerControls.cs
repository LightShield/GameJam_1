using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
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
        //roate
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        //move forward\backwards - a bit off because of blender axis problem, but i can't fix it in bleneder because i don't have it
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.AddForce(-transform.up * movmentSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player.AddForce(transform.up * movmentSpeed);
        }
        //slowing down  - using drag
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Grass"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Collected " + ++score + " points");
        }
    }
}