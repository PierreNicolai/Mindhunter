using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MindHunter.Managers
{
    public class PlatesRiddleController : PersistentSingleton<PlatesRiddleController>
    {
        public GameObject[] PlatesOrder;

        private List<GameObject> GoodPlatesList;
        
        public void Start()
        {
            GoodPlatesList = PlatesOrder.ToList();
        }
       
        public void PlateTriggered(GameObject plate)
        {
            if (!GoodPlatesList.Contains(plate))
            {
                plate.GetComponent<PlateTrigger>().DestroyPlate();
            }
        }
    }
}