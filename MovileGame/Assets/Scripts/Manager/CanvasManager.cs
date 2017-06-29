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
    public Image ammo;
    public Text levelDisplay;
    private float reloadWeaponTime;
    private float timeOfShoot;
    private float fullAmmo;
    private float currentAmmo;

    void Start() {
        instance = this;

        onMenu.SetActive(true);
        onGame.SetActive(false);

        timeOfShoot = 0;
        reloadWeaponTime = 0;
    }
	
    // On Game
	void Update () {
        if (onGame.activeSelf) {
            scoreText.text = ScoreManager.instance.GetScore().ToString();
        }

        levelDisplay.text = "Lv: " + PlayerManager.instance.Level().ToString();

        reloadWeapon.fillAmount = ((Time.time - timeOfShoot) / (reloadWeaponTime / PlayerManager.instance.GetPlussFromLv()));
        ammo.fillAmount = currentAmmo / fullAmmo;

    }

    public void TimeOfShoot(float time) {
        timeOfShoot = time;
    }

    public void WeaponReloadTime(float time) {
        reloadWeaponTime = time;
    }

    public void SetAmmo(int ammo) {
        fullAmmo = ammo;
    }

    public void SetCurrentAmmo(int ammo) {
        currentAmmo = ammo;
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
        PlayerManager.instance.ResetLv();
        PlayerManager.instance.NewPlayer();
    }

    public void Quit() {
        Application.Quit();
    }
}
