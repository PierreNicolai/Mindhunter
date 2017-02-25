using MindHunter.Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : PersistentSingleton<UIManager>
{
    private Animator _anim;

    public Image fillBar;
   
    void Start()
    {
        _anim = GetComponent<Animator>();
        InvokeRepeating("UpdateMindwaveUI", 0f, 3f);
    }
    
    public void UpdateMindwaveUI()
    {
        int MindwaweTrigger = Player.Instance.GetComponent<PowerController>().attentionTrigger;
        int currentMindwaveValue = MindwaveInterface.Instance.attentionValue;

        float attentionPercentage = (100 * currentMindwaveValue) / MindwaweTrigger;
        fillBar.fillAmount = attentionPercentage / 100;
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
