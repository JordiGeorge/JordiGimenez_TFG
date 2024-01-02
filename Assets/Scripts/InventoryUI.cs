using UnityEngine;

//Classe per actualitzar la UI de l'inventari
public class InventoryUI : MonoBehaviour 
{
	public Transform itemsPanel;	//Gameobject pare 
	public GameObject inventoryUI;	// The entire UI

	private Inventory inventory;	//Variable d'Accés a l'inventari
	private InventorySlot[] slots;	//Array d'slots d'inventari

	private void Start () 
	{
		inventory = Inventory.instance; //Accedim a l'instancia amb el singleton
		inventory.onItemChangedCallback += InventoryUpdate;	//Suscribim a delegate de Inventory
		
		slots = itemsPanel.GetComponentsInChildren<InventorySlot>(); //Omplim array en base als fills de itemPanel amb InventorySlot component 
	}

	//Metode cridat amb el delegate de Inventory.
	private void InventoryUpdate()
	{
		//Mirem entre els components InventorySlots
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]); //Afegim Item a slot si no hi ha cap
				
			} else
			{
				//Neteja l'slot amb mètode de la clase
				slots[i].ClearSlot();
			}
		}
	}
}
