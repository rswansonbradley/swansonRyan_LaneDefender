using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHealth : MonoBehaviour
{
    public static int gameHp = 3;
    public AudioClip lifeLostAudio;
    public AudioSource gameSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            gameHp = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameHp -= 1;
            gameSource.clip = lifeLostAudio;
            gameSource.volume = .4f;
            gameSource.Play();
        }
    }
}
