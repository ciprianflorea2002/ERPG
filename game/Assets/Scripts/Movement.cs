using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1;

    private bool moving = false;
    private Direction facing; 

    public enum Direction{
        Up, 
        Down,
        Right,
        Left,
        None
    }

    void Start (){
        facing = Direction.Up;
    }

    void Update()
    {
        Direction dir = Direction.None;
        if (Input.GetKey(KeyCode.UpArrow))
            dir = Direction.Up;
        if (Input.GetKey(KeyCode.DownArrow))
            dir = Direction.Down;
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Direction.Right;
        if (Input.GetKey(KeyCode.LeftArrow)) 
            dir = Direction.Left;

        if(dir == Direction.None)
            return;
        
        if(!moving && CanMoveIn(dir)) 
            StartCoroutine(Move(dir));
        

    }

    private IEnumerator Move(Direction dir)
    {
        moving = true;
        if(facing != dir)
            TurnTo(dir);
        gameObject.transform.position += dir.ToVector3();
        yield return new WaitForSeconds( 1 / speed );
        if(Map.map.GetCell(gameObject.transform.position) != Map.CellType.Empty)
            GameController.gameController.StepOn(gameObject.transform.position);   
        moving = false;
    }

    private void TurnTo(Direction dir){
        facing = dir;
    }

    private bool CanMoveIn(Direction dir){
        Map.CellType cell = Map.map.GetCell(transform.position + dir.ToVector3());
        return cell != Map.CellType.Wall;
    }
    
}