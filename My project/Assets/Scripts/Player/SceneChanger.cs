using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe responsável por controlar a troca de cenas do jogador
public class SceneChanger : MonoBehaviour
{
	Savefile savefile = null;
	int dialogo = -1;//Indica o personagem de quem o jogador esta proximo
	// Start is called before the first frame update
	void Start()
    {
		savefile = new Savefile();
		savefile = savefile.LoadFile();
	}

    // Update is called once per frame
    void Update()
    {
		//engatilha o fim do jogo
		if (savefile.objectives[2].status == true)
		{

			SceneManager.LoadScene("Ending");
		}

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		//caso o jogador escolha falar com o personagem
		if (Input.GetKeyDown(KeyCode.X) && dialogo > -1)
		{
			savefile = new Savefile();
			savefile.UpdateLocation(sceneName, transform.position.x, transform.position.y);
			PlayerPrefs.SetInt("npc", dialogo);
			SceneManager.LoadScene("Dialog");
		}
		// caso o jogador deseje sair do jogo
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			savefile = new Savefile();
			savefile.UpdateLocation(sceneName, transform.position.x, transform.position.y);
			SceneManager.LoadScene("Opening");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Verifica se o objeto que o jogador toca é uma saida de mapa
		if (other.CompareTag("castle-home"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("castle", (float)-0.59, (float)-3);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("home"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("home", (float)-0.32, (float)2.5);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("castle-sea"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("castle", (float)-6.6, (float)0.6);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("castle-sky"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("castle", (float)6.6, (float)0.6);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("castle-desert"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("castle", (float)6.6, (float)3);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("castle-snow"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("castle", (float)-6.6, (float)3);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("sea"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("sea", (float)6, (float)0);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("sky"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("sky", (float)-6, (float)1);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("desert"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("desert", (float)4, (float)0);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		else if (other.CompareTag("snow"))
		{
			savefile = new Savefile();
			savefile.UpdateLocation("snow", (float)4, (float)0.5);
			savefile = savefile.LoadFile();
			SceneManager.LoadScene(savefile.scene);
		}
		// Verifica se o objeto que o jogador toca é uma area de falar com o personagem
		dialogo = -1;
		if (other.CompareTag("Mom"))
		{
			dialogo = 0;
		}
		else if (other.CompareTag("King"))
		{
			dialogo = 1;
		}
		else if (other.CompareTag("Princess"))
		{
			dialogo = 2;
		}
		else if (other.CompareTag("Raccoon1"))
		{
			dialogo = 3;
		}
		else if (other.CompareTag("Raccoon2"))
		{
			dialogo = 4;
		}
		else if (other.CompareTag("Raccoon3"))
		{
			dialogo = 5;
		}
		else if (other.CompareTag("Raccoon4"))
		{
			dialogo = 6;
		}
		else if (other.CompareTag("Raccoon5"))
		{
			dialogo = 7;
		}
		else if (other.CompareTag("Bird1"))
		{
			dialogo = 8;
		}
		else if (other.CompareTag("Bird2"))
		{
			dialogo = 9;
		}
		else if (other.CompareTag("Bird3"))
		{
			dialogo = 10;
		}
		else if (other.CompareTag("Bird4"))
		{
			dialogo = 11;
		}
		else if (other.CompareTag("Bird5"))
		{
			dialogo = 12;
		}
		else if (other.CompareTag("Cat1"))
		{
			dialogo = 13;
		}
		else if (other.CompareTag("Cat2"))
		{
			dialogo = 14;
		}
		else if (other.CompareTag("Cat3"))
		{
			dialogo = 15;
		}
		else if (other.CompareTag("Cat4"))
		{
			dialogo = 16;
		}
		else if (other.CompareTag("Cat5"))
		{
			dialogo = 17;
		}
		else if (other.CompareTag("Fox1"))
		{
			dialogo = 18;
		}
		else if (other.CompareTag("Fox2"))
		{
			dialogo = 19;
		}
		else if (other.CompareTag("Fox3"))
		{
			dialogo = 20;
		}
		else if (other.CompareTag("Fox4"))
		{
			dialogo = 21;
		}
		else if (other.CompareTag("Fox5"))
		{
			dialogo = 22;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//atualiza caso o jogador se afaste
		dialogo = -1;
		if (other.CompareTag("Mom"))
		{
			dialogo = 0;
		}
		else if (other.CompareTag("King"))
		{
			dialogo = 1;
		}
		else if (other.CompareTag("Princess"))
		{
			dialogo = 2;
		}
		else if (other.CompareTag("Raccoon1"))
		{
			dialogo = 3;
		}
		else if (other.CompareTag("Raccoon2"))
		{
			dialogo = 4;
		}
		else if (other.CompareTag("Raccoon3"))
		{
			dialogo = 5;
		}
		else if (other.CompareTag("Raccoon4"))
		{
			dialogo = 6;
		}
		else if (other.CompareTag("Raccoon5"))
		{
			dialogo = 7;
		}
		else if (other.CompareTag("Bird1"))
		{
			dialogo = 8;
		}
		else if (other.CompareTag("Bird2"))
		{
			dialogo = 9;
		}
		else if (other.CompareTag("Bird3"))
		{
			dialogo = 10;
		}
		else if (other.CompareTag("Bird4"))
		{
			dialogo = 11;
		}
		else if (other.CompareTag("Bird5"))
		{
			dialogo = 12;
		}
		else if (other.CompareTag("Cat1"))
		{
			dialogo = 13;
		}
		else if (other.CompareTag("Cat2"))
		{
			dialogo = 14;
		}
		else if (other.CompareTag("Cat3"))
		{
			dialogo = 15;
		}
		else if (other.CompareTag("Cat4"))
		{
			dialogo = 16;
		}
		else if (other.CompareTag("Cat5"))
		{
			dialogo = 17;
		}
		else if (other.CompareTag("Fox1"))
		{
			dialogo = 18;
		}
		else if (other.CompareTag("Fox2"))
		{
			dialogo = 19;
		}
		else if (other.CompareTag("Fox3"))
		{
			dialogo = 20;
		}
		else if (other.CompareTag("Fox4"))
		{
			dialogo = 21;
		}
		else if (other.CompareTag("Fox5"))
		{
			dialogo = 22;
		}
	}
}
