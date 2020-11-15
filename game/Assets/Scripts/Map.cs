using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public static Map map;

    public enum CellType{
        Empty,
        Mob,
        Boss,
        Wall
    }

    public int minX = 1; 
    public int maxX = 30;
    public int minY = 0;
    public int maxY = 28;
    
    public Dictionary<Vector2, CellType> mapData;

    public Map(string name) {
        map = this;
        LoadMap(name);
    }

    public CellType GetCell(Vector2 pos){
        Debug.Log(pos);
        if(pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
            return CellType.Wall;
        Debug.Log("a");
        CellType type;
        if(mapData.TryGetValue(pos, out type))
            return type;
        Debug.Log("b");
        return CellType.Empty;
    }

    private void LoadMap(string mapName){
        switch(mapName){
            case "default":
                mapData = defaultMap; break;
            
        }
    }

    private Dictionary<Vector2, CellType> defaultMap = 
        new Dictionary<Vector2, CellType>() {
            {new Vector2(14,14), CellType.Mob},
            {new Vector2(24,16), CellType.Mob},
            {new Vector2(13,26), CellType.Mob},
            {new Vector2(6,26), CellType.Boss},
            {new Vector2(2,0), CellType.Wall},
            {new Vector2(2,1), CellType.Wall},
            {new Vector2(2,2), CellType.Wall},
            {new Vector2(2,3), CellType.Wall},
            {new Vector2(2,4), CellType.Wall},
            {new Vector2(2,5), CellType.Wall},
            {new Vector2(2,6), CellType.Wall},
            {new Vector2(2,7), CellType.Wall},
            {new Vector2(2,8), CellType.Wall},
            {new Vector2(2,9), CellType.Wall},
            {new Vector2(2,10), CellType.Wall},
            {new Vector2(2,11), CellType.Wall},
            {new Vector2(1,11), CellType.Wall},
            {new Vector2(0,12), CellType.Wall},
            {new Vector2(0,13), CellType.Wall},
            {new Vector2(1,14), CellType.Wall},
            {new Vector2(1,15), CellType.Wall},
            {new Vector2(2,16), CellType.Wall},
            {new Vector2(3,16), CellType.Wall},
            {new Vector2(4,16), CellType.Wall},
            {new Vector2(5,16), CellType.Wall},
            {new Vector2(6,16), CellType.Wall},
            {new Vector2(7,16), CellType.Wall},
            {new Vector2(8,16), CellType.Wall},
            {new Vector2(9,16), CellType.Wall},
            {new Vector2(10,16), CellType.Wall},
            {new Vector2(11,16), CellType.Wall},
            {new Vector2(12,16), CellType.Wall},
            {new Vector2(13,16), CellType.Wall},
            {new Vector2(14,16), CellType.Wall},
            {new Vector2(15,15), CellType.Wall},
            {new Vector2(16,14), CellType.Wall},
            {new Vector2(16,13), CellType.Wall},
            {new Vector2(16,12), CellType.Wall},
            {new Vector2(16,11), CellType.Wall},
            {new Vector2(16,10), CellType.Wall},
            {new Vector2(17,10), CellType.Wall},
            {new Vector2(18,10), CellType.Wall},
            {new Vector2(18,11), CellType.Wall},
            {new Vector2(19,12), CellType.Wall},
            {new Vector2(20,12), CellType.Wall},
            {new Vector2(21,12), CellType.Wall},
            {new Vector2(22,12), CellType.Wall},
            {new Vector2(22,13), CellType.Wall},
            {new Vector2(23,14), CellType.Wall},
            {new Vector2(23,15), CellType.Wall},
            {new Vector2(22,16), CellType.Wall},
            {new Vector2(22,17), CellType.Wall},
            {new Vector2(22,18), CellType.Wall},
            {new Vector2(23,19), CellType.Wall},
            {new Vector2(22,20), CellType.Wall},
            {new Vector2(23,21), CellType.Wall},
            {new Vector2(23,22), CellType.Wall},
            {new Vector2(22,23), CellType.Wall},
            {new Vector2(22,24), CellType.Wall},
            {new Vector2(22,25), CellType.Wall},
            {new Vector2(21,25), CellType.Wall},
            {new Vector2(20,25), CellType.Wall},
            {new Vector2(19,25), CellType.Wall},
            {new Vector2(18,25), CellType.Wall},
            {new Vector2(17,25), CellType.Wall},
            {new Vector2(16,26), CellType.Wall},
            {new Vector2(15,25), CellType.Wall},
            {new Vector2(14,25), CellType.Wall},
            {new Vector2(13,25), CellType.Wall},
            {new Vector2(12,25), CellType.Wall},
            {new Vector2(11,25), CellType.Wall},
            {new Vector2(10,25), CellType.Wall},
            {new Vector2(10,24), CellType.Wall},
            {new Vector2(9,23), CellType.Wall},
            {new Vector2(8,23), CellType.Wall},
            {new Vector2(7,23), CellType.Wall},
            {new Vector2(6,23), CellType.Wall},
            {new Vector2(5,23), CellType.Wall},
            {new Vector2(4,23), CellType.Wall},
            {new Vector2(3,24), CellType.Wall},
            {new Vector2(3,25), CellType.Wall},
            {new Vector2(3,26), CellType.Wall},
            {new Vector2(3,27), CellType.Wall},
            {new Vector2(3,28), CellType.Wall},
            {new Vector2(4,29), CellType.Wall},
            {new Vector2(5,29), CellType.Wall},
            {new Vector2(6,29), CellType.Wall},
            {new Vector2(7,29), CellType.Wall},
            {new Vector2(8,28), CellType.Wall},
            {new Vector2(9,28), CellType.Wall},
            {new Vector2(10,28), CellType.Wall},
            {new Vector2(11,28), CellType.Wall},
            {new Vector2(12,27), CellType.Wall},
            {new Vector2(13,28), CellType.Wall},
            {new Vector2(14,28), CellType.Wall},
            {new Vector2(15,28), CellType.Wall},
            {new Vector2(16,28), CellType.Wall},
            {new Vector2(17,28), CellType.Wall},
            {new Vector2(18,28), CellType.Wall},
            {new Vector2(19,28), CellType.Wall},
            {new Vector2(20,28), CellType.Wall},
            {new Vector2(21,28), CellType.Wall},
            {new Vector2(22,28), CellType.Wall},
            {new Vector2(23,28), CellType.Wall},
            {new Vector2(24,28), CellType.Wall},
            {new Vector2(25,28), CellType.Wall},
            {new Vector2(26,27), CellType.Wall},
            {new Vector2(26,26), CellType.Wall},
            {new Vector2(26,25), CellType.Wall},
            {new Vector2(26,24), CellType.Wall},
            {new Vector2(26,23), CellType.Wall},
            {new Vector2(26,22), CellType.Wall},
            {new Vector2(26,21), CellType.Wall},
            {new Vector2(26,20), CellType.Wall},
            {new Vector2(26,19), CellType.Wall},
            {new Vector2(26,18), CellType.Wall},
            {new Vector2(25,17), CellType.Wall},
            {new Vector2(26,16), CellType.Wall},
            {new Vector2(26,15), CellType.Wall},
            {new Vector2(26,14), CellType.Wall},
            {new Vector2(26,13), CellType.Wall},
            {new Vector2(26,12), CellType.Wall},
            {new Vector2(27,12), CellType.Wall},
            {new Vector2(28,12), CellType.Wall},
            {new Vector2(29,11), CellType.Wall},
            {new Vector2(29,10), CellType.Wall},
            {new Vector2(30,10), CellType.Wall},
            {new Vector2(30,2), CellType.Wall},
            {new Vector2(29,2), CellType.Wall},
            {new Vector2(28,2), CellType.Wall},
            {new Vector2(28,1), CellType.Wall},
            {new Vector2(27,0), CellType.Wall},
            {new Vector2(26,0), CellType.Wall},
            {new Vector2(25,0), CellType.Wall},
            {new Vector2(24,0), CellType.Wall},
            {new Vector2(23,0), CellType.Wall},
            {new Vector2(22,0), CellType.Wall},
            {new Vector2(21,0), CellType.Wall},
            {new Vector2(20,0), CellType.Wall},
            {new Vector2(19,0), CellType.Wall},
            {new Vector2(18,1), CellType.Wall},
            {new Vector2(18,2), CellType.Wall},
            {new Vector2(18,3), CellType.Wall},
            {new Vector2(18,4), CellType.Wall},
            {new Vector2(19,5), CellType.Wall},
            {new Vector2(20,5), CellType.Wall},
            {new Vector2(20,6), CellType.Wall},
            {new Vector2(19,6), CellType.Wall},
            {new Vector2(18,6), CellType.Wall},
            {new Vector2(17,6), CellType.Wall},
            {new Vector2(16,6), CellType.Wall},
            {new Vector2(15,6), CellType.Wall},
            {new Vector2(14,7), CellType.Wall},
            {new Vector2(13,8), CellType.Wall},
            {new Vector2(13,9), CellType.Wall},
            {new Vector2(13,10), CellType.Wall},
            {new Vector2(13,11), CellType.Wall},
            {new Vector2(13,12), CellType.Wall},
            {new Vector2(13,13), CellType.Wall},
            {new Vector2(12,13), CellType.Wall},
            {new Vector2(11,13), CellType.Wall},
            {new Vector2(10,13), CellType.Wall},
            {new Vector2(9,13), CellType.Wall},
            {new Vector2(8,13), CellType.Wall},
            {new Vector2(8,12), CellType.Wall},
            {new Vector2(8,11), CellType.Wall},
            {new Vector2(7,10), CellType.Wall},
            {new Vector2(6,11), CellType.Wall},
            {new Vector2(5,11), CellType.Wall},
            {new Vector2(5,10), CellType.Wall},
            {new Vector2(5,9), CellType.Wall},
            {new Vector2(5,8), CellType.Wall},
            {new Vector2(5,7), CellType.Wall},
            {new Vector2(5,6), CellType.Wall},
            {new Vector2(5,5), CellType.Wall},
            {new Vector2(5,4), CellType.Wall},
            {new Vector2(5,3), CellType.Wall},
            {new Vector2(5,2), CellType.Wall},
            {new Vector2(5,1), CellType.Wall},
            {new Vector2(5,0), CellType.Wall}
        };
}
