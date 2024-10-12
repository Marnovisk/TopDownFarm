using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAnim : MonoBehaviour
{

    private PlayerMovement Movement;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("Transition", 1);
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if(Movement.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        if(Movement.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }
}
