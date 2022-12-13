using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    Animator anim;
    void Start()
    {
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
        anim = GetComponent<Animator>();
    }
    public void die()
    {

        GetComponent<Animator>().enabled = false;

        setColliderState(true);
    }

    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        bool moving = false;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            die();
        }
        bool isWalking = anim.GetBool("iswalking");
        if (moving)
        {
            anim.SetBool("iswalking", true);
        }
        if (isWalking && !moving)
        {
            anim.SetBool("iswalking", false);
        }

    }
}
