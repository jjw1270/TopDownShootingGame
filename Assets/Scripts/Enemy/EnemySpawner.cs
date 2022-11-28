using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BoxCollider[] SpawnRange = new BoxCollider[4];
    int playTimeMin = 0;
    const string Beholder = "Beholder";
    const string Spider = "Spider";
    const string Goblin = "Goblin";
    const string Mushroom = "Mushroom";
    const string Slime = "Slime";
    const string TurtleShell = "TurtleShell";
    const string Chest = "Chest";

    const string FireElemental_Boss = "FireElemental_Boss";
    const string Golem_Boss = "Golem_Boss";

    Coroutine SlimeCoroutine;
    Coroutine TurtleShellCoroutine;
    Coroutine SpiderCoroutine;
    Coroutine BeholderCoroutine;
    Coroutine MushroomCoroutine;
    Coroutine ChestCoroutine;
    Coroutine GoblinCoroutine;
    Coroutine FireElemental_BossCoroutine;
    Coroutine Golem_BossCoroutine;

    void Start()
    {
        StartCoroutine(MinTimer());
    }
    IEnumerator MinTimer(){
        while(true){
            if(playTimeMin == 0){
                yield return new WaitForSecondsRealtime(1f);
                TurtleShellCoroutine = StartCoroutine(Spawn(TurtleShell, 1, 5));
            }
            else if(playTimeMin == 1){
                Debug.Log("A");
                SlimeCoroutine = StartCoroutine(Spawn(Slime, 2, 4));
            }
            else if(playTimeMin == 3){
                Debug.Log("A");
                SpiderCoroutine = StartCoroutine(Spawn(Spider, 10, 15));
            }
            else if(playTimeMin == 5){
                Debug.Log("A");
                StopCoroutine(TurtleShellCoroutine);
                MushroomCoroutine = StartCoroutine(Spawn(Mushroom, 4, 3));
            }
            else if(playTimeMin == 7){
                Debug.Log("A");
                StopCoroutine(SlimeCoroutine);
                ChestCoroutine = StartCoroutine(Spawn(Chest, 2, 1));
            }
            else if(playTimeMin == 10){
                Debug.Log("A");
                Golem_BossCoroutine = StartCoroutine(Spawn(Golem_Boss, 1, 90));
            }
            else if(playTimeMin == 13){
                Debug.Log("A");
                GoblinCoroutine = StartCoroutine(Spawn(Goblin, 3, 5));
            }
            else if(playTimeMin == 15){
                Debug.Log("A");
                StopCoroutine(SpiderCoroutine);
                BeholderCoroutine = StartCoroutine(Spawn(Beholder, 20, 10));
            }
            else if(playTimeMin == 17){
                Debug.Log("A");
                SlimeCoroutine = StartCoroutine(Spawn(Slime, 2, 2));
                FireElemental_BossCoroutine = StartCoroutine(Spawn(FireElemental_Boss, 20, 6));
            }
            else if(playTimeMin == 20){
                StopCoroutine(SlimeCoroutine);
                StopCoroutine(BeholderCoroutine);
                StopCoroutine(MushroomCoroutine);
                StopCoroutine(ChestCoroutine);
                StopCoroutine(GoblinCoroutine);
                StopCoroutine(FireElemental_BossCoroutine);
                StopCoroutine(Golem_BossCoroutine);

                StopCoroutine(MinTimer());
            }

            yield return new WaitForSecondsRealtime(60f);
            playTimeMin += 1;
        }
    }

    IEnumerator Spawn(string enemyTag, int enemyCount, int timeInterval){
        while(true){
            SpwanEnemies(enemyTag, enemyCount);
            yield return new WaitForSecondsRealtime(timeInterval);
        }
    }

    private void SpwanEnemies(string enemyTag, int enemyCount){
        int index = Random.Range(0,4);

        if(enemyTag == Beholder || enemyTag == Spider){
            Vector3 randomPos = RandomPos(index);
            for(int i = 0; i < enemyCount; i++){
                if(i % 2 == 0)
                    randomPos = new Vector3(randomPos.x, 0, randomPos.z-1);
                else
                    randomPos = new Vector3(randomPos.x+2f, 0, randomPos.z+2f);

                GameObject enemy = ObjectPooler.SpawnFromPool(enemyTag, randomPos);
            }
            return;
        }

        for(int i = 0; i < enemyCount; i++){
            GameObject enemy = ObjectPooler.SpawnFromPool(enemyTag, RandomPos(index));
        }
    }
    private Vector3 RandomPos(int index){
        Vector3 originPosition = SpawnRange[index].transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = SpawnRange[index].bounds.size.x;
        float range_Z = SpawnRange[index].bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
