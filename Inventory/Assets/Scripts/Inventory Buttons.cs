using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryButtons : MonoBehaviour
{
    public GameObject equipmentPanel;
    public GameObject armorPanel;
    public GameObject usablePanel;

   public void equipmentTab()
   {
        equipmentPanel.SetActive(true);
        armorPanel.SetActive(false);
        usablePanel.SetActive(false);
   }
   public void armorTab()
   {
        armorPanel.SetActive(true);
        equipmentPanel.SetActive(false);
        usablePanel.SetActive(false);
   }
   public void usableTab()
   {
        usablePanel.SetActive(true);
        armorPanel.SetActive(false);
        equipmentPanel.SetActive(false);
   }
   public void exit()
   {
        equipmentPanel.SetActive(false);
        armorPanel.SetActive(false);
        usablePanel.SetActive(false);
   }
}
