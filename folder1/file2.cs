using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject fade = null;
    public GameObject[] buttons;
    public static int levels;
	private int[] epcnt = {10, 10, 15, 20};
    void Start()
    {
		int curE = PlayerPrefs.GetInt("curE", 1) - 1;
        if (!PlayerPrefs.HasKey("levels")) PlayerPrefs.SetInt("levels", 1);
        levels = PlayerPrefs.GetInt("levels"+(curE+1), 1);

         for (int i = levels; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
            buttons[i].GetComponent<Button>().interactable = false;
        }
		if (epcnt[curE] !=20) for (int i = epcnt[curE];i < buttons.Length; i++)  Destroy(buttons[i]);
    }

    public void loadLevel(int levelIndex)
    {
        if (fade != null) {fade.SetActive(true); fade.GetComponent<Animator>().SetTrigger("fade");}
        PlayerPrefs.SetInt("curL", levelIndex);
        Invoke("loadscene3", 2.5f);
    }

    public void loadscene3() {SceneManager.LoadScene(3);}
}

