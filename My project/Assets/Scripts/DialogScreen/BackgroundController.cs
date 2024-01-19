using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

// Classe responsável por alterar o fundo da cena de diálogo.
public class BackgroundController : MonoBehaviour
{
	// Lista de fundos disponíveis para serem escolhidos.
	public List<Sprite> backgrounds;

	// Renderizador de Sprite para aplicar o fundo escolhido.
	private SpriteRenderer sr;

	private void Start()
	{
		// Inicializa o SpriteRenderer e escolhe o fundo com base no personagem escolhido.
		sr = GetComponent<SpriteRenderer>();
		int choice = PlayerPrefs.GetInt("npc");
		sr.sprite = backgrounds[choice];


		transform.position = Camera.main.transform.position;
		transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

		float cameraHeight = Camera.main.orthographicSize * 2.0f;
		float cameraWidth = cameraHeight * Camera.main.aspect;

		float spriteHeight = sr.sprite.bounds.size.y;
		float spriteWidth = sr.sprite.bounds.size.x;

		float scaleY = cameraHeight / spriteHeight;
		float scaleX = cameraWidth / spriteWidth;

		// ajusta para a imagem se adequar ao tamanho da camera.
		float scale = Mathf.Max(scaleX, scaleY);

		transform.localScale = new Vector3(scaleX, scaleY, 1);
	}
}




