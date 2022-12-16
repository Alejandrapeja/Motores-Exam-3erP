using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    [SerializeField] private Transform target;
    private Animator anim;
    [Range(0, 1)]
    [SerializeField] private float weight;

    void Start()
    {
        GetComponent<Animator>().enabled = true;
        anim = GetComponent<Animator>();
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
    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
    }
}
