using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;

    public void PlaySpellAnimation(string name)
    {
        anim.CrossFade(name, 0.1f, 0);
    }
}
