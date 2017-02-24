using MindHunter.Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : PersistentSingleton<UIManager>
{
    private Animator _anim;

    public RawImage movieTexture;

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

    public void SetMovieTextureActive(bool active)
    {
        movieTexture = GetComponentInChildren<RawImage>();
        movieTexture.enabled = active;
    }
}
