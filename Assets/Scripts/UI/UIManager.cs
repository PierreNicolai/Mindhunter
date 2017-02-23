using MindHunter.Managers;
using UnityEngine;

public class UIManager : PersistentSingleton<UIManager>
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void UIFadeIn()
    {
        _anim.Play("FadeIn");
    }

    public void UIFadeOut()
    {
        _anim.Play("FadeOut");
    }
}
