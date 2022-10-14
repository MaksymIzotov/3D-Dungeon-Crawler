using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;

    public void PlaySpellAnimation(string name)
    {
        anim.Play(name);
    }
}
