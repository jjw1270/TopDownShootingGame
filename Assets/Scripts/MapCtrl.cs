using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapCtrl : MonoBehaviour
{
    public GameObject mapPool;
    private Transform[] maps = new Transform[10];
    private Transform[] tmpMaps = new Transform[10];
    private Transform currentMap;

    private void Start() {
        maps = mapPool.GetComponentsInChildren<Transform>();
        maps.CopyTo(tmpMaps, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != LayerMask.NameToLayer("Map"))
            return;
            
        currentMap = other.transform;
        maps.CopyTo(tmpMaps, 0);

        Debug.Log((other.transform.GetSiblingIndex()+1));

        switch(other.transform.GetSiblingIndex()+1){
            case 1:
                tmpMaps[1] = maps[9];
                tmpMaps[2] = maps[6];
                tmpMaps[3] = maps[3];
                tmpMaps[4] = maps[8];
                tmpMaps[5] = maps[1];
                tmpMaps[6] = maps[2];
                tmpMaps[7] = maps[7];
                tmpMaps[8] = maps[4];
                tmpMaps[9] = maps[5];
                break;
            case 2:
                tmpMaps[1] = maps[7];
                tmpMaps[2] = maps[8];
                tmpMaps[3] = maps[9];
                tmpMaps[4] = maps[1];
                tmpMaps[5] = maps[2];
                tmpMaps[6] = maps[3];
                tmpMaps[7] = maps[4];
                tmpMaps[8] = maps[5];
                tmpMaps[9] = maps[6];
                break;
            case 3:
                tmpMaps[1] = maps[1];
                tmpMaps[2] = maps[4];
                tmpMaps[3] = maps[7];
                tmpMaps[4] = maps[2];
                tmpMaps[5] = maps[3];
                tmpMaps[6] = maps[8];
                tmpMaps[7] = maps[5];
                tmpMaps[8] = maps[6];
                tmpMaps[9] = maps[9];
                break;
            case 4:
                tmpMaps[1] = maps[3];
                tmpMaps[2] = maps[1];
                tmpMaps[3] = maps[2];
                tmpMaps[4] = maps[6];
                tmpMaps[5] = maps[4];
                tmpMaps[6] = maps[5];
                tmpMaps[7] = maps[9];
                tmpMaps[8] = maps[7];
                tmpMaps[9] = maps[8];
                break;
            case 5:
                break;
            case 6:
                tmpMaps[1] = maps[2];
                tmpMaps[2] = maps[3];
                tmpMaps[3] = maps[1];
                tmpMaps[4] = maps[5];
                tmpMaps[5] = maps[6];
                tmpMaps[6] = maps[4];
                tmpMaps[7] = maps[8];
                tmpMaps[8] = maps[9];
                tmpMaps[9] = maps[7];
                break;
            case 7:
                tmpMaps[1] = maps[1];
                tmpMaps[2] = maps[4];
                tmpMaps[3] = maps[5];
                tmpMaps[4] = maps[2];
                tmpMaps[5] = maps[7];
                tmpMaps[6] = maps[8];
                tmpMaps[7] = maps[3];
                tmpMaps[8] = maps[6];
                tmpMaps[9] = maps[9];
                break;
            case 8:
                tmpMaps[1] = maps[4];
                tmpMaps[2] = maps[5];
                tmpMaps[3] = maps[6];
                tmpMaps[4] = maps[7];
                tmpMaps[5] = maps[8];
                tmpMaps[6] = maps[9];
                tmpMaps[7] = maps[1];
                tmpMaps[8] = maps[2];
                tmpMaps[9] = maps[3];
                break;
            case 9:
                tmpMaps[1] = maps[5];
                tmpMaps[2] = maps[6];
                tmpMaps[3] = maps[3];
                tmpMaps[4] = maps[8];
                tmpMaps[5] = maps[9];
                tmpMaps[6] = maps[2];
                tmpMaps[7] = maps[7];
                tmpMaps[8] = maps[4];
                tmpMaps[9] = maps[1];
                break;
        }

        maps = (Transform[])tmpMaps.Clone();

        for(int i = 1; i < 10; i++){
            maps[i].SetSiblingIndex(i);
        }

        maps[1].position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z+100);
        maps[2].position = new Vector3(currentMap.position.x, 0, currentMap.position.z+100);
        maps[3].position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z+100);

        maps[4].position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z);
        maps[6].position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z);

        maps[7].position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z-100);
        maps[8].position = new Vector3(currentMap.position.x, 0, currentMap.position.z-100);
        maps[9].position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z-100);
    }
}
