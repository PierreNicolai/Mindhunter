using MindHunter.Managers;
using UnityEngine;

public class UIManager : PersistentSingleton<UIManager>
{
    private Animator _anim;

    public GameObject RawImage;

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

    public void SetRawPanelActive(bool active)
    {
        RawImage.SetActive(active);
    }
}
