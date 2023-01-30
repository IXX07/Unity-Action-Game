using UnityEngine;

public class CHARACTER_MOVEMENT : MonoBehaviour
{
    public float speed, gravity, sprintMp;

    internal CharacterController cc;

    private CHARACTER_ANIMATOR cAnimator;
    private float currentGravity;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        cAnimator = GetComponent<CHARACTER_ANIMATOR>();
    }

    private void Update()
    {
        var sprint = Input.GetKey(KeyCode.LeftShift);
        var movement = transform.forward * Input.GetAxis("Vertical") * speed;
        
        cAnimator.SetMovement(movement != Vector3.zero, sprint ? sprintMp : 1);

        if (sprint) movement *= sprintMp;
        movement += ApplyGravity();

        cc.Move(movement * Time.deltaTime);
    }

    private Vector3 ApplyGravity()
    {
        var movement = new Vector3(0, -currentGravity, 0);
        currentGravity += gravity * Time.deltaTime;

        if (cc.isGrounded && currentGravity > 1) currentGravity = 1;
        return movement;
    }
}