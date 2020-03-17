using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to control standard enemies
public class EnemyController : PoolObject
{
    [SerializeField]
    private float downwardSpeed = 1;    // speed modifier accessible in inspector

    // called before first frame update
    void Start(){
        
    }

    // movedown each frame (fixed update is exactly 60 fps)
    private void FixedUpdate() {
        MoveDown();
    }

    // translate downwards
    void MoveDown(){
        transform.Translate(Vector3.down*Time.deltaTime*downwardSpeed, Space.World);
    }

    // handle collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        // collides with player
        if (other.gameObject.CompareTag("Player")){
            HandlePlayerCollision();
        }
    }

    // do on collision with player
    private void HandlePlayerCollision(){
        // play particle effect

        this.Destroy();
    }

    public override void OnObjectReuse(){
        // do nothing for now
    }
}
