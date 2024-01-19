using UnityEngine;

//Classe respons�vel por fazer a c�mera seguir o jogador
public class CameraController : MonoBehaviour
{
	public Transform target; // Refer�ncia ao objeto que a c�mera ir� seguir (o jogador nesse caso).
	public float smoothSpeed = 0.125f; // Velocidade de suaviza��o para que a c�mera siga o jogador de forma mais suave.

	void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPosition = target.position;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		smoothedPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
		transform.position = smoothedPosition;
	}
}

