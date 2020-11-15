using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour {
    private static List<PlayerAnimator> players;

    private int[] animation;

    public static int[] sideAnimation = {0, 1, 2, 3};
    public static int[] upwardsAnimation = {4};
    public static int[] downwardsAnimation = {5};
    public static int[] dyingAnimation = {5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7,7,7,7,7,7,7};

    private static Sprite[] frames;
    private float fps = 2.0f;

    private SpriteRenderer renderer;

    void Start () {
        if(players == null) {
            players = new List<PlayerAnimator>();
            frames = Resources.LoadAll<Sprite>("Characters/Player/");
        }
        players.Add(this);

        renderer = (SpriteRenderer) GetComponent<SpriteRenderer> ();
        animation = downwardsAnimation;
    }

    void FixedUpdate () {
        int index = (int)(Time.time * fps);
        index = index % animation.Length;
        renderer.sprite = frames[animation[index]];
    }

    public static void TurnTo(Movement.Direction dir){
        switch(dir) {
            case Movement.Direction.Up:
                SetAnimation(upwardsAnimation); break;
            case Movement.Direction.Down:
                SetAnimation(downwardsAnimation); break;
            case Movement.Direction.Left:
                SetAnimation(sideAnimation); SetFlip(false); break;
            case Movement.Direction.Right:
                SetAnimation(sideAnimation); SetFlip(true); break;
        }
    }

    public static void SetAnimation(int[] anim){
        foreach(var it in players)
            it.animation = anim;
    }
    public static void SetFlip(bool flip){
        foreach(var it in players)
            it.renderer.flipX = flip;
    }
}