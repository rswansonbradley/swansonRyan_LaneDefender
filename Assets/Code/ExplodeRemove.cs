using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Remove", .2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Remove()
    {
        Destroy(this.gameObject);
    }
}
