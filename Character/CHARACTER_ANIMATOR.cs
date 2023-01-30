using UnityEngine;

public class CHARACTER_ANIMATOR : MonoBehaviour
{
    private Animator animator;
    public AnimationClip movement, breathing;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    internal void SetMovement(bool cond, float speedMp)
    {
        animator.SetBool("movement", cond);
        animator.SetFloat("speedMp", speedMp);
    }
}