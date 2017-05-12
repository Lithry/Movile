using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    static public CanvasManager instance = null;
    public GameObject onMenu;
    public GameObject onGame;
    public Text scoreText;
    public Image reloadWeapon;
    private float reloadWeaponTime;
    private float timeOfShoot;

    void Start() {
        instance = this;

        onMenu.SetActive(true);
        onGame.SetActive(false);
    }
	
    // On Game
	void Update () {
        if (onGame.activeSelf) {
            scoreText.text = ScoreManager.instance.GetScore().ToString();
        }

        reloadWeapon.fillAmount = ((Time.time - timeOfShoot) / reloadWeaponTime);
	}

    public void TimeOfShoot(float time) {
        timeOfShoot = time;
    }

    public void WeaponReloadTime(float time) {
        reloadWeaponTime = time;
    }

    public void ReturnToMenu() {
        onMenu.SetActive(true);
        onGame.SetActive(false);
        SceneManager.instance.OnGame(false);
    }
    
    // On Menu
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
