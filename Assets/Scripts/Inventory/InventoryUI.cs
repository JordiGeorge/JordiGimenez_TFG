using UnityEngine;

//Classe per actualitzar la UI de l'inventari
public class InventoryUI : MonoBehaviour 
{
	public Transform itemsPanel;	//Gameobject pare 
	private Inventory _inventory;	//Variable d'Accés a l'inventari
	private InventorySlot[] _slots;	//Array d'slots d'inventari

	private void Start () 
	{
		_inventory = Inventory.instance; //Accedim a l'instancia amb el singleton
		_inventory.onItemChangedCallback += InventoryUpdate;	//Suscribim a delegate de Inventory
		
		_slots = itemsPanel.GetComponentsInChildren<InventorySlot>(); //Omplim array en base als fills de itemPanel amb InventorySlot component 
	}

	//Metode cridat amb el delegate de Inventory.
	private void InventoryUpdate()
	{
		//Mirem entre els components InventorySlots
		for (int i = 0; i < _slots.Length; i++)
		{
			if (i < _inventory.items.Count)
			{
				_slots[i].AddItem(_inventory.items[i]); //Afegim Item a slot si no hi ha cap
				
			} 
			else
			{
				//Neteja l'slot amb mètode de la clase
				_slots[i].ClearSlot();
			}
		}
	}
}
