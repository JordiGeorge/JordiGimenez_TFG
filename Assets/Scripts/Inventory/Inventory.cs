using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	//Prova de Singleton Pattern per evitar duplicats d'inventari
	#region Singleton

	public static Inventory instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("Més d'una instància d'inventari a l'ecena!!");
			return;
		}

		instance = this;
	}

	#endregion

	// Delegate on ens podem suscriure desde altres mètodes
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int inventoryCapacity = 8; //Capacitat d'items de l'inventari

	//LLista de tipus Item per a fer l'inventari
	public List<Item> items = new List<Item>();

	// Afegeix item si l'invenmtari no està ple
	public void Add (Item item)
	{
		// Check if out of space
			if (items.Count >= inventoryCapacity)
			{
				Debug.Log("Inventari ple!!");
			}
			else if (items.Count < inventoryCapacity) items.Add(item);	//Afegeix item a la llista

			// Crida a Delegate
			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
	}
	public void Remove (Item item)
	{
		items.Remove(item);	//Mètode per treure item de la llista

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
