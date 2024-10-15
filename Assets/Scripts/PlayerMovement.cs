using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rig;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;

    
    private Vector2 _direction;
    private bool _inRun;
    private bool _inRoll;

    public Vector2 direction
    {
        get {return _direction;}
        set {_direction = value;}
    }

    public bool inRun
    {
        get {return _inRun;}
        set {_inRun = value;}
    }

    public bool inRoll
    {
        get {return _inRoll;}
        set {_inRoll = value;}
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();        
        OnRun();
        OnRoll();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _inRun = true;
        } 

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _inRun = false;
        }   
    }

    void OnRoll()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed = runSpeed;
            _inRoll = true;            
        } 
        if(Input.GetKeyUp(KeyCode.Space))
        {
            speed = initialSpeed;
            _inRoll = false;            
        } 
        
         
    }
}
