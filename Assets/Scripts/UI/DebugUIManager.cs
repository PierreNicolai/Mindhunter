using UnityEngine;
using UnityEngine.UI;

public class DebugUIManager : MonoBehaviour {

    public Image fillImage;
    public Text meditationValue;

	// Use this for initialization
	void Start () {
        fillImage.fillAmount = 0.5f;
        meditationValue.text = "50";
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Mindwave value : " + MindwaveInterface.attentionValue);
        fillImage.fillAmount = (float)MindwaveInterface.attentionValue / 100;
        meditationValue.text = MindwaveInterface.attentionValue.ToString();
	}
}
