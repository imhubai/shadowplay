using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    private Rigidbody2D Boat;
    public float walk_Speed = 10f;
    public float z_Speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Boat = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boat.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * (walk_Speed) * Time.deltaTime,
                                          Input.GetAxisRaw("Vertical") * (z_Speed) * Time.deltaTime, 0);
    }
}
