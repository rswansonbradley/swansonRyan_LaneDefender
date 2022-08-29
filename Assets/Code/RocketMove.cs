using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public int speed = 10;
    public GameObject explosion;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Remove", 5);
        newPos = new Vector3(transform.position.x + .4f, transform.position.y + .2f, transform.position.z);
        Instantiate(explosion, newPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Remove()
    {
        Destroy(this.gameObject);
    }
}
