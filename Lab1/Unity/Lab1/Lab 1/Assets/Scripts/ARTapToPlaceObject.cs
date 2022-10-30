using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{

    public GameObject playerGameObjectToInstantiate;
    public GameObject enemyGameObjectToInstantiate;


    private GameObject playerSpawnedObject;
    private GameObject enemySpawnedObject;

    private ARRaycastManager _arRaycastManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (enemySpawnedObject == null)
            {
                enemySpawnedObject = Instantiate(enemyGameObjectToInstantiate, hitPose.position, hitPose.rotation);
                enemySpawnedObject.tag = "enemy";

                Debug.Log("Enemy tag: " + enemySpawnedObject.tag);
            }

            if (enemySpawnedObject != null && playerSpawnedObject == null)
            {
                playerSpawnedObject = Instantiate(playerGameObjectToInstantiate, hitPose.position, hitPose.rotation);
                playerSpawnedObject.tag = "Player";
            }
            else
            {
                playerSpawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
