using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int ypos = 5;
    public GameObject rocketPrefab;
    bool canFire = true;
    public AudioClip lifeLostAudio;
    public AudioClip shootAudio;
    public AudioSource gameSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)||(Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if(ypos != 1)
            {
                Vector2 newpos = transform.position;
                newpos.y -= 1;
                transform.position = newpos;
                ypos -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (ypos != 5)
            {
                Vector2 newpos = transform.position;
                newpos.y += 1;
                transform.position = newpos;
                ypos += 1;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(canFire == true)
            {
                gameSource.clip = shootAudio;
                gameSource.volume = .4f;
                gameSource.Play();
                //Creates a rocket
                GameObject r = Instantiate(rocketPrefab) as GameObject;
                //Sets rocket position to player position
                r.transform.position = transform.position;
                canFire = false;
                Invoke("allowFire", 0.5f);
            }
            
        }
    }
    void allowFire()
    {
        canFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GlobalHealth.gameHp -= 1;
            gameSource.clip = lifeLostAudio;
            gameSource.volume = .4f;
            gameSource.Play();
        }
    }
}
