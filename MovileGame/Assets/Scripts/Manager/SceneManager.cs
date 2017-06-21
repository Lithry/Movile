using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    static public SceneManager instance = null;
    public GameObject[] components;
    private bool onGame;
    private float delay;

	void Awake() {
        instance = this;
        for (int i = 0; i < components.Length; i++)
        {
            Instantiate(components[i]);
        }
    }
	
	void Update () {
        if (!PlayerManager.instance.PlayerAlive() && onGame)
            delay += Time.deltaTime;

        if (delay > 3) {
            ZombieManager.instance.RecycleAll();
            CanvasManager.instance.ReturnToMenu();
        }
	}

    public void OnGame(bool state) {
        onGame = state;
        delay = 0;
    }
}
