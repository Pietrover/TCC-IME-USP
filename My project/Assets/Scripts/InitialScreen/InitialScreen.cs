using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe responsável por controlar o comportamento da tela inicial
public class InitialScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);

	}

    // Update is called once per frame
    void Update()
    {
        //Se apertar "X" inicia o jogo
        if (Input.GetKeyDown(KeyCode.X))
        {
            Savefile savefile = new Savefile();
            savefile = savefile.LoadFile();
            SceneManager.LoadScene(savefile.scene);
        }
        //Se apertar "ESC" fecha o jogo 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
			return;
#endif
        }
    }
}
