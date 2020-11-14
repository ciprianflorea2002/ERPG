using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    private Dictionary<Vector3, GameObject> enemies;

    public GameObject mobObject;
    public GameObject bossObject;
    
    void Start(){
        gameController = this;
        enemies = new Dictionary<Vector3, GameObject>();
        
        new Map("default");
        
        foreach (var it in Map.map.mapData){
            if(it.Value == Map.CellType.Mob){
                var instance = Instantiate(mobObject, it.Key, Quaternion.identity);
                enemies.Add(it.Key, instance);
            }
            if(it.Value == Map.CellType.Boss){
                var instance = Instantiate(bossObject, it.Key, Quaternion.identity);
                enemies.Add(it.Key, instance);
            }
        }
    }

    public void StepOn(Vector2 pos){
        Destroy(enemies[pos]);
        enemies.Remove(pos);
        gameObject.SetActive(false);
        BattleController.battleController.StartBattle(Map.map.GetCell(pos) == Map.CellType.Boss);
        Map.map.mapData.Remove(pos);
    }

    public void EndBattle(bool alive){
        if(!alive || enemies.Count == 0)
            EndScreen.endScreen.End(alive);
        else
            gameObject.SetActive(true);
    }

}
