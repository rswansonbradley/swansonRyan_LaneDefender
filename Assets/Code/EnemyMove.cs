using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int speed = 1;
    public int eHp = 1;
    bool isHit = false;
    public AudioClip dieAudio;
    public AudioClip hitAudio;
    public AudioSource gameSource;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eHp == 0)
        {
            gameSource.clip = dieAudio;
            gameSource.volume = .4f;
            gameSource.Play();
            isHit = true;
            eHp = -1;
            anim.SetTrigger("die");
            Invoke("Remove", 0.45f);
        }

        if (!isHit)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            float ha = transform.position.y;
        }

        if (GlobalHealth.gameHp < 1)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            eHp--;
            if (eHp == 0)
            {
                gameSource.clip = dieAudio;
                gameSource.volume = .4f;
                gameSource.Play();
            }
            else
            {
                anim.SetTrigger("gotHit");
                gameSource.clip = hitAudio;
                gameSource.volume = .4f;
                gameSource.Play();
            }
            isHit = true;
            Invoke("Stun", 0.4f);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    void Remove()
    {
        UI.currentPoint += 100;
        Destroy(this.gameObject);
    }

    void Stun()
    {
        if (eHp > 0)
        {
            isHit = false;
        }
    }

}
