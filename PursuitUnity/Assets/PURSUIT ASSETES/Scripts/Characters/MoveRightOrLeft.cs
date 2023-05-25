using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightOrLeft : MonoBehaviour, IDataPersistance
{
    public bool canMove = true;
    public float direction;
    bool facingRight = true;
    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
        if (canMove)
        {
            direction = Input.GetAxis("Horizontal");
        }

        if (direction < 0 && facingRight)
        {
            flip();
        }
        else if (direction > 0 && !facingRight)
        {
            flip();
        }

    }

    void CannotChangeDirection()
    {
        canMove =false;
    }
    void CanChangeDirection()
    {
        
        canMove = true;
    }

    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
    //    if (collision.tag == "FallPoint")
    //    {

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //        transform.position = respawnPoint;
    //    }
    //    if (collision.tag == "Checkpoint")
    //    {
    //        respawnPoint = transform.position;
    //    }
    //}

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

}
