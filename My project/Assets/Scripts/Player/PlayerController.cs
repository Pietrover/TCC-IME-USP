using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

//Classe responsável por controlar a movimentação do jogador
public class PlayerController : MonoBehaviour
{
	public Animator playerAnimator; //Componente Animator
	float input_x = 0;
	float input_y = 0;
	bool isWalking = false;//bool indicando se o jogador está andando

	Rigidbody2D rb2D;// Componente RigidBody2D
	Savefile savefile = null;

	Vector2 movement = Vector2.zero;
	// Start is called before the first frame update
	void Start()
	{
		isWalking = false;
		rb2D = GetComponent<Rigidbody2D>();
		//atualiza a posiição para a última salva
		savefile = new Savefile();
		savefile = savefile.LoadFile();
		transform.position = new Vector3(savefile.positionX, savefile.positionY);

	}

	// Update is called once per frame
	void Update()
	{
		//atualiza a posição baseado no input 
		input_x = Input.GetAxisRaw("Horizontal");
		input_y = Input.GetAxisRaw("Vertical");
		isWalking = (input_x != 0 || input_y != 0);
		movement = new Vector2(input_x, input_y);

		if (isWalking)
		{
			playerAnimator.SetFloat("input_x", input_x);
			playerAnimator.SetFloat("input_y", input_y);
		}

		playerAnimator.SetBool("isWalking", isWalking);

		
	}


	private void FixedUpdate()
	{
		rb2D.MovePosition(rb2D.position + movement * 2f * Time.fixedDeltaTime);

	}
}
