using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
        if (other.gameObject.tag == "Shot")
        {
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        
	}
}