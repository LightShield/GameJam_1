using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 100f;
    private Vector3 zeroVector;
    public PlayerControls pilot;
    public float collisionBounce = 0.8f;
    public Vector3 offsetFromPilot;
    // Start is called before the first frame update
    void Start()
    {
        zeroVector = Vector3.zero;
        offsetFromPilot = new Vector3(0f, 0f, -10f);
        pilot = this.transform.parent.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
        transform.localPosition = offsetFromPilot;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Grass"))
        {
            Destroy(other.gameObject);
            Debug.Log("Collected " + ++pilot.score + " points");
            //create a new grass to collect
            other.gameObject.GetComponent<GoldenGrassBehavior>().creatNewGrass(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("point of collision: " + other.contacts[0].point);

        if (other.gameObject.tag.Equals("Boundary"))
        {
            Debug.Log("velocity : " + pilot.player.velocity); 
            //using reflection, as suggested by omer @discord
            pilot.player.velocity = Vector3.Reflect(pilot.player.velocity, other.contacts[0].normal) * collisionBounce;
        }
    }

}
