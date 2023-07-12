using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDistributor : MonoBehaviour
{
    public void UpdateInventorySlotText(string breadType, int amount)
    {
        Transform[] childTransforms = transform.GetComponentsInChildren<Transform>(true);
        
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.name == "InventorySlot" + breadType)
            {
                Text textComponent = childTransform.GetComponentInChildren<Text>();
                
                if (textComponent != null)
                {
                    textComponent.text = amount.ToString();
                    return;
                }
                else
                {
                    Debug.LogWarning("Text component not found in InventorySlot object: " + breadType);
                    return;
                }
            }
        }
        
        Debug.LogWarning("InventorySlot object not found for bread type: " + breadType);
    }
	

    private void Start()
    {
  	     	//string breadType = "Baguette";
	     	//int amount = 1;
        	//UpdateInventorySlotText(breadType, amount);
		    UpdateInventorySlotText("Bagel", StaticData.BagelNumber);
		    UpdateInventorySlotText("Baguette", StaticData.BaguetteNumber);
		    UpdateInventorySlotText("Hamburger", StaticData.BurgerbunNumber);
		    UpdateInventorySlotText("Breadstick", StaticData.BreadstickNumber);
		    UpdateInventorySlotText("Toast", StaticData.ToastNumber);
   }
}