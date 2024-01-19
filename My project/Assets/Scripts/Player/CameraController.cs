using UnityEngine;

//Classe responsável por fazer a câmera seguir o jogador
public class CameraController : MonoBehaviour
{
	public Transform target; // Referência ao objeto que a câmera irá seguir (o jogador nesse caso).
	public float smoothSpeed = 0.125f; // Velocidade de suavização para que a câmera siga o jogador de forma mais suave.

	void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPosition = target.position;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		smoothedPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
		transform.position = smoothedPosition;
	}
}

