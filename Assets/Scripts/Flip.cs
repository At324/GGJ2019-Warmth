using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        if (Random.Range(0, 1) == 0)
        {
            renderer.flipX = true;
        }

    }

}
