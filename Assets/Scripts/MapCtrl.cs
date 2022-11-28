using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    public GameObject mapPool;
    public GameObject[] maps = new GameObject[9];
    private GameObject[] tmpMaps = new GameObject[9];
    private Transform currentMap;

    private void Start() {
        maps.CopyTo(tmpMaps, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != LayerMask.NameToLayer("Map"))
            return;
            
        currentMap = other.transform;
        maps.CopyTo(tmpMaps, 0);

        switch(other.transform.GetSiblingIndex()+1){
            case 1:
                tmpMaps[0] = maps[8];
                tmpMaps[1] = maps[5];
                tmpMaps[2] = maps[2];
                tmpMaps[3] = maps[7];
                tmpMaps[4] = maps[0];
                tmpMaps[5] = maps[1];
                tmpMaps[6] = maps[6];
                tmpMaps[7] = maps[3];
                tmpMaps[8] = maps[4];
                break;
            case 2:
                tmpMaps[0] = maps[6];
                tmpMaps[1] = maps[7];
                tmpMaps[2] = maps[8];
                tmpMaps[3] = maps[0];
                tmpMaps[4] = maps[1];
                tmpMaps[5] = maps[2];
                tmpMaps[6] = maps[3];
                tmpMaps[7] = maps[4];
                tmpMaps[8] = maps[5];
                break;
            case 3:
                tmpMaps[0] = maps[0];
                tmpMaps[1] = maps[3];
                tmpMaps[2] = maps[6];
                tmpMaps[3] = maps[1];
                tmpMaps[4] = maps[2];
                tmpMaps[5] = maps[7];
                tmpMaps[6] = maps[4];
                tmpMaps[7] = maps[5];
                tmpMaps[8] = maps[8];
                break;
            case 4:
                tmpMaps[0] = maps[2];
                tmpMaps[1] = maps[0];
                tmpMaps[2] = maps[1];
                tmpMaps[3] = maps[5];
                tmpMaps[4] = maps[3];
                tmpMaps[5] = maps[4];
                tmpMaps[6] = maps[8];
                tmpMaps[7] = maps[6];
                tmpMaps[8] = maps[7];
                break;
            case 5:
                break;
            case 6:
                tmpMaps[0] = maps[1];
                tmpMaps[1] = maps[2];
                tmpMaps[2] = maps[0];
                tmpMaps[3] = maps[4];
                tmpMaps[4] = maps[5];
                tmpMaps[5] = maps[3];
                tmpMaps[6] = maps[7];
                tmpMaps[7] = maps[8];
                tmpMaps[8] = maps[6];
                break;
            case 7:
                tmpMaps[0] = maps[0];
                tmpMaps[1] = maps[3];
                tmpMaps[2] = maps[4];
                tmpMaps[3] = maps[1];
                tmpMaps[4] = maps[6];
                tmpMaps[5] = maps[7];
                tmpMaps[6] = maps[2];
                tmpMaps[7] = maps[5];
                tmpMaps[8] = maps[8];
                break;
            case 8:
                tmpMaps[0] = maps[3];
                tmpMaps[1] = maps[4];
                tmpMaps[2] = maps[5];
                tmpMaps[3] = maps[6];
                tmpMaps[4] = maps[7];
                tmpMaps[5] = maps[8];
                tmpMaps[6] = maps[0];
                tmpMaps[7] = maps[1];
                tmpMaps[8] = maps[2];
                break;
            case 9:
                tmpMaps[0] = maps[4];
                tmpMaps[1] = maps[5];
                tmpMaps[2] = maps[2];
                tmpMaps[3] = maps[7];
                tmpMaps[4] = maps[8];
                tmpMaps[5] = maps[1];
                tmpMaps[6] = maps[6];
                tmpMaps[7] = maps[3];
                tmpMaps[8] = maps[0];
                break;
        }

        tmpMaps.CopyTo(maps, 0);
        //maps = (Transform[])tmpMaps.Clone();

        for(int i = 0; i < 9; i++){
            maps[i].transform.SetSiblingIndex(i);
        }

        maps[0].transform.position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z+100);
        maps[1].transform.position = new Vector3(currentMap.position.x, 0, currentMap.position.z+100);
        maps[2].transform.position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z+100);

        maps[3].transform.position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z);
        maps[5].transform.position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z);

        maps[6].transform.position = new Vector3(currentMap.position.x-100, 0, currentMap.position.z-100);
        maps[7].transform.position = new Vector3(currentMap.position.x, 0, currentMap.position.z-100);
        maps[8].transform.position = new Vector3(currentMap.position.x+100, 0, currentMap.position.z-100);
    }
}
