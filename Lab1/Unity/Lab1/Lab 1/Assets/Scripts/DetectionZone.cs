using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for detection
public class DetectionZone : MonoBehaviour
{
    public string tagEnemy = "enemy";
    public List<Collider2D> detectedObjs = new List<Collider2D>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagEnemy)
        {
            detectedObjs.Add(collision);
            Debug.Log("detection added");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagEnemy)
        {
            detectedObjs.Remove(collider);
            Debug.Log("detection removed");

        }
    }
}
