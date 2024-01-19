using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe responsável por permitir a saída da cena de diálogo.
public class DialogScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Volta para cena anterior caso em caso de apertar "ESC"
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Savefile savefile = new Savefile();
            savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
	}
}
