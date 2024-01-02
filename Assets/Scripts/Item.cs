
using UnityEngine;


//Atribut per crear nou scriptable Object (item) desde l'editor
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

/*Clase Item que hereda d'scriptable object*/
public class Item : ScriptableObject 
{
	new public string name = "New Item";	//Nom de l'item
	public Sprite icon = null;				//Icona

	// Override quan clickem a l'inventari
	public virtual void Use ()
	{
		//Lògica quan usem l'objecte
		Debug.Log("Using " + name);
	}
	//Mètode per Eliminar item de l'inventari (List)
	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
}
