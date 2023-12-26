using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    [SerializeField] Bullet bullet;
    public FixedJoystick J;
    public GameObject P;



    void Update()
    {
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Translate(Vector3.left * Speed * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.Translate(Vector3.up * Speed * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     transform.Translate(Vector3.down * Speed * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Translate(Vector3.right * Speed * Time.deltaTime);
        // }
        // if (Input.GetMouseButton(0))
        // {
        //     Vector3 mousePosition = Input.mousePosition;
        //     mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //     Vector3 direction = new Vector3(mousePosition.x, mousePosition.y);
        //     transform.up = direction;
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Instantiate(bullet, transform.position, transform.rotation);
        // }
        //
        Move();
        Drag();

    }


    //Joystick
    public void Move()
    {
        if (J.Horizontal != 0 && J.Vertical != 0)
        {
            float Jx = J.Horizontal;
            float Jy = J.Vertical;

            Vector2 dir = new Vector2(Jx, Jy);
            P.transform.Translate(dir * Time.deltaTime * Speed);

        }
    }
    public void Drag()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 direction = touchPosition - (Vector2)transform.position;
            transform.up = direction;
        }

    }
    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

}
