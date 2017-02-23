using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MindHunter.Managers;

public class GlowManager : PersistentSingleton<GlowManager>
{
    private List<GlowObject> glowObjects = new List<GlowObject>();
    private List<GlowObject> realtimeList = new List<GlowObject>();

    private bool lastGlowValue;

    public bool canGlow { get; set; }

    // Use this for initialization
    void Start()
    {
        lastGlowValue = false;
        Reload();
    }

    public void Reload()
    {
        glowObjects = FindObjectsOfType<GlowObject>().ToList();
        glowObjects.ForEach(g => g.UnGlow());
        canGlow = lastGlowValue;
    }

    // Update is called once per frame
    void Update()
    {
        lastGlowValue = canGlow;
        if (canGlow)
        {
            realtimeList = UpdateGlowList();
            List<GlowObject> tmpList = new List<GlowObject>();
            foreach (GlowObject g in realtimeList)
            {
                if (g.roomIndex == Player.Instance.CurrentRoom)
                    g.Glow();
                else
                    g.UnGlow();
            }
        }
        else
        {
            realtimeList = UpdateGlowList();
            realtimeList.ForEach(g => g.UnGlow());
        }
    }

    private List<GlowObject> UpdateGlowList()
    {
        List<GlowObject> tempList = new List<GlowObject>();

        foreach (GlowObject g in glowObjects)
        {
            if (g != null)
                tempList.Add(g);
        }
        return tempList;
    }
}
