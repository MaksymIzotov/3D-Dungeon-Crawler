using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;

    public void PlayPlayerAnimation(string name)
    {
        anim.Play(name);
    }
}
