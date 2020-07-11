using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class GInventory
    {
        public List<GameObject> items = new List<GameObject>();


        public void AddItem(GameObject i)
        {
            items.Add(i);
        }

        public GameObject FindItemWithTag(string tags)
        {
            foreach(GameObject i in items)
            {
                if(i.CompareTag(tags))
                {
                    return i;
                }
            }
            return null;
        }

        public void RemoveItem(GameObject i)
        {
            int indexToRemove = -1;
            foreach(GameObject g in items)
            {
                indexToRemove++;
                if (g == i)
                    break;
            }
            if (indexToRemove >= -1)
                items.RemoveAt(indexToRemove);
        }
    }
}
