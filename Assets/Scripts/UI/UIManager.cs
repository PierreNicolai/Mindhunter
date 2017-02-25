using MindHunter.Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : PersistentSingleton<UIManager>
{
    private Animator _anim;

    public Image fillBar;
    public GameObject Sight;
   
    void Start()
    {
        _anim = GetComponent<Animator>();
        InvokeRepeating("UpdateMindwaveUI", 0f, 3f);
    }

    void Update()
    {
        float scale = 0.05f * MindwaveInterface.Instance.attentionValue;
        Sight.GetComponent<RectTransform>().transform.localScale = new Vector3(scale, scale, scale);
        Color currentSightColor = Sight.GetComponent<Image>().color;
        float alpha = MindwaveInterface.Instance.attentionValue * (7 / 1000) + 0.3f;
        Color newColor = new Color(1f, 1f, 1f, alpha);
        currentSightColor = newColor;
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
