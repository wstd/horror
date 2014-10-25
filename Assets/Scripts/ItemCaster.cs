using UnityEngine;
using System.Collections;

public class ItemCaster : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit[] hits = Physics.RaycastAll(transform.position,
		                                        transform.TransformDirection(Vector3.forward), 5, 1 << 8 );
		foreach (RaycastHit hit in hits)
		{
			VisibleQuestTrigger trigger = hit.collider.gameObject.GetComponent<VisibleQuestTrigger>();
			if (trigger != null)
			{
				trigger.InFocus = true;
			}
		}
	}
}
