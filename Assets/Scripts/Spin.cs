using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [Header("Rotation Settings & Cosmetics")]
    public Vector3 offsetFromPilot;
    public float spinSpeed = 100f;
    public float minRotateVelocity = 1f;
    public ParticleSystem playerCollectionEffect;
    public ParticleSystem bumpEffect;

    [Header("Collisions & Behaviors Settings")]
    public AnyPlayerBehavior pilot;
    public float collisionBounce = 0.8f;
    public float playerBumpingEnergyFactor = 1.2f;
    

    //optimization helper (Vector3.zero creates a new vector each time for some reason)
    private Vector3 zeroVector;

    // Start is called before the first frame update
    void Start()
    {
        zeroVector = Vector3.zero;
        pilot = this.transform.parent.GetComponent<AnyPlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * spinSpeed * Time.deltaTime * (pilot.player.velocity.magnitude + minRotateVelocity));
        transform.localPosition = offsetFromPilot;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Grass"))
        {
            //collect
            Destroy(other.gameObject);
            Debug.Log("Collected " + ++pilot.score + " points");
            //create a new grass to collect
            GoldenGrassBehavior grass = other.gameObject.GetComponent<GoldenGrassBehavior>();
            grass.creatNewGrass(other.gameObject);
            playerCollectionEffect.Play();
            pilot.OnTriggerEnter(other);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Boundary"))
        {
            //using reflection, as suggested by omer @discord
            pilot.player.velocity = Vector3.Reflect(pilot.player.velocity, other.contacts[0].normal) * collisionBounce;
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("enemy/player bump");
            //calculate reflection by giving both of the ships half of the total speed:
            Rigidbody enemyBody = other.gameObject.transform.parent.GetComponent<Rigidbody>();
            Vector3 connectedVelocity = enemyBody.velocity + pilot.player.velocity * playerBumpingEnergyFactor / 2;
            Vector3 newVelocity = Vector3.Reflect(connectedVelocity, other.contacts[0].normal) * collisionBounce;
            //zero out y speed - game does not have height dimension (small height differnces are for cosmetic reasons).
            pilot.player.velocity = new Vector3(newVelocity.x, 0, newVelocity.z);
            enemyBody.velocity = -pilot.player.velocity;
            other.gameObject.transform.parent.GetComponent<EnemyBehavior>().correctAfterCollision();
         }
        ParticleSystem bump = Instantiate(bumpEffect, other.contacts[0].point, Quaternion.identity);
        bump.transform.parent = bumpEffect.transform.parent;
        bump.Play();
    }

}
