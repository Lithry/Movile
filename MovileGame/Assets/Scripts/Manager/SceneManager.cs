using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    static public SceneManager instance = null;
    private bool onGame;
    private float delay;
	// Use this for initialization
	void Awake() {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (!PlayerManager.instance.PlayerAlive() && onGame)
            delay += Time.deltaTime;

        if (delay > 3) {
            ZombieManager.instance.KillAll();
            CanvasManager.instance.ReturnToMenu();
        }
	}

    public void OnGame(bool state) {
        onGame = state;
        delay = 0;
    }
}
