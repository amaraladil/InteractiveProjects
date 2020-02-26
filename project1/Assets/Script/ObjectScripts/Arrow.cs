using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidBody;
    public float lifeTime;
    private float lifeTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {//COMPARETAG(PLAYER) MIGHT BREAK IF ROOM COLIDER IS SET, MAKE A NEW LAYER FOR ROOMS AND MAKE THEM NOT INTERACTABLE WITH RANGED PROJECTILE
        //if (other.gameObject.CompareTag("enemy"))
        //{
            Destroy(this.gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if(lifeTimeCounter <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
