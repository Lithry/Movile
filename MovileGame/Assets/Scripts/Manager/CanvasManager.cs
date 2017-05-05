using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    static public CanvasManager instance = null;
    public GameObject onMenu;
    public GameObject onGame;
    public Text scoreText;

    void Start() {
        instance = this;

        onMenu.SetActive(true);
        onGame.SetActive(false);
    }
	
	void Update () {
        if (onGame.activeSelf) {
            scoreText.text = ScoreManager.instance.GetScore().ToString();
        }
	}

    public void ReturnToMenu() {
        onMenu.SetActive(true);
        onGame.SetActive(false);
        SceneManager.instance.OnGame(false);
    }


    public void Play() {
        onMenu.SetActive(false);
        onGame.SetActive(true);
        SceneManager.instance.OnGame(true);
        ScoreManager.instance.ResetScore();
        PlayerManager.instance.NewPlayer();
    }

    public void Quit() {
        Application.Quit();
    }
}
