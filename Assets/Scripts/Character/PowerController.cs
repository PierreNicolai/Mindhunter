using UnityEngine;
using MindHunter.Managers;

public class PowerController : MonoBehaviour
{

    public GameObject XRayScript;

    public int attentionTrigger;

    private GlowManager glowManager;
    private MindwaveInterface mindwaveInterface;

    bool xray;

    // Use this for initialization
    void Start()
    {
        glowManager = GlowManager.Instance;
        //mindwaveInterface = MindwaveInterface.Instance;
        xray = false;
        XRayScript.SetActive(xray);
        //InvokeRepeating("UpdateMindwavesValues", 0f, 3.0f);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            glowManager.canGlow = !glowManager.canGlow;
        }
    }

    private void UpdateMindwavesValues()
    {
        print("Current attention value = " + mindwaveInterface.attentionValue);
        if (MindwaveInterface.Instance.attentionValue >= attentionTrigger)
        {
            XRayScript.SetActive(true);
            xray = true;
            glowManager.canGlow = true;
        }
        else
        {
            XRayScript.SetActive(false);
            xray = false;
            glowManager.canGlow = false;
        }
    }
}
