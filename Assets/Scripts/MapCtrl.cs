using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    public GameObject map;
    public Transform currentMap;
    private Vector3 nextMapPos;
    public List<Transform> allMap = new List<Transform>();

    private void Start() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != LayerMask.NameToLayer("Map"))
            return;

        if(other.CompareTag("CurrentMap")){
            currentMap = other.transform.parent;

            if(allMap.Count == 0){
                Debug.Log("a");
                allMap.Add(currentMap);
                return;
            }
            return;
        }
        
        if(other.CompareTag("DeleteMap")){
            if(allMap.Count == 0)
                return;

            for(int i = allMap.Count - 1; i >= 0; i--){
                Debug.Log("aa");
                if(allMap[i] != currentMap){
                    Debug.Log("aaa");
                    Destroy(allMap[i].gameObject);
                    allMap.RemoveAt(i);
                }
            }
            return;
        }

        if(other.transform.parent != currentMap) return;

        switch(other.tag){
            case "Up":
                nextMapPos = new Vector3(currentMap.position.x, 0, currentMap.position.z+500);
                break;
            case "Down":
                nextMapPos = new Vector3(currentMap.position.x, 0, currentMap.position.z-500);
                break;
            case "Left":
                nextMapPos = new Vector3(currentMap.position.x-500, 0, currentMap.position.z);
                break;
            case "Right":
                nextMapPos = new Vector3(currentMap.position.x+500, 0, currentMap.position.z);
                break;
            case "UR":
                nextMapPos = new Vector3(currentMap.position.x+500, 0, currentMap.position.z+500);
                break;
            case "DR":
                nextMapPos = new Vector3(currentMap.position.x+500, 0, currentMap.position.z-500);
                break;
            case "UL":
                nextMapPos = new Vector3(currentMap.position.x-500, 0, currentMap.position.z+500);
                break;
            case "DL":
                nextMapPos = new Vector3(currentMap.position.x-500, 0, currentMap.position.z-500);
                break;
        }
        Transform nextMap = Instantiate(map, nextMapPos, Quaternion.identity).transform;
        allMap.Add(nextMap);
    }
}
