using UnityEngine;
using UnityEngine.UI;

//Classe que gestiona slots a UI
public class InventorySlot : MonoBehaviour 
{
	public Image icon;			//variable per asignar sprite desde Scriptable Object
	public Button removeButton;	//Botó per descartar objectes a l'inventari

	private Item _item;  //Assignem Item Corresponent si es objecte d'inventari

	//Actualitzam Slot en base a informació de l'escriptable object
	public void AddItem (Item newItem)
	{
		_item = newItem;

		icon.sprite = _item.icon;
		icon.color = Color.white;
        icon.enabled = true;
		removeButton.interactable = true;
	}

	//Reset del slot
	public void ClearSlot ()
	{
		_item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	//Mètode per borrar item de la llista de la classe inventory
	public void OnRemoveButton ()
	{
		Inventory.instance.Remove(_item);
	}

	//Mètode que comproba si es objecte de tipus item i crida a mètode de la seva classe (Funcionalitat Puzzle)
	public void UseItem ()
	{
		if (_item != null)
		{
			_item.Use();
		}
	}
}
