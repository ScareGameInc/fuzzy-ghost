using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour {
	
	// Attributes
	private Component[] renderers; // Renderer (Texturen)
	
	public void makeTransparent (float duration) {
		makeTransparent(0.25f, duration);
	}
	
	public void makeTransparent (float transparency, float duration) {
		makeTransparent(transparency, duration, 0f);
	}
	
	public void makeTransparent (float transparency, float duration, float delay) {
		Hashtable ht = new Hashtable();
		ht.Add("alpha", transparency);
		ht.Add("time", duration);
		ht.Add("delay", delay);
		iTween.FadeTo(gameObject, ht);
	}
	
	public void show (float duration) {
		show(duration, 0);
	}
	
	/// 
	/// Zeigt das Objekt komplett
	/// Ist von aussen per Message benutzbar
	/// @param duration		Dauer des Sichtbarkeitsvorgangs
	/// @param delay		Verzögerung des Sichtbarmachens
	/// 
	public void show (float duration, float delay) {
		gameObject.SetActive(true);
		makeTransparent(1f, duration, delay);
	}
		
	/// 
	/// Versteckt das Objekt komplett mit deaktivierung
	/// Ist von aussen per Message benutzbar
	/// @param duration		Dauer des Versteckvorgangs
	/// @param delay		Verzögerung des Versteckens
	/// 
	public void hide (float duration, float delay) {
		Hashtable ht = new Hashtable();
		ht.Add("alpha", 0);
		ht.Add("time", duration);
		ht.Add("delay", delay);
		ht.Add("onComplete", "deactivate");
		iTween.FadeTo(gameObject, ht);
	}
	
	public void hide (float duration) {
		hide(duration, 0f);
	}
	
	
	/// 
	/// Versteckt das Objekt komplett ohne deaktivierung
	/// Ist von aussen per Message benutzbar
	/// @param duration				Dauer des Versteckvorgangs
	/// 
	public void makeInvisible (float duration) {
		Hashtable ht = new Hashtable();
		ht.Add("alpha", 0);
		ht.Add ("time", duration);
		iTween.FadeTo(gameObject, ht);
	}
	
	void deactivate () {
		gameObject.SetActive(false);
	}
	
	/// 
	/// Blendet Objekt aus und zerstört es
	/// Ist von aussen per Message benutzbar
	/// @param duration				Dauer des Ausblendvorgangs
	/// 
	public void fadeoutDestroy (float duration) {
		Hashtable ht = new Hashtable();
		ht.Add("alpha", 0);
		ht.Add ("time", duration);
		ht.Add("onComplete", "destroy");
		iTween.FadeTo(gameObject, ht);
	}
	
	private void destroy () {
		Destroy(gameObject);
	}
	
	
}
