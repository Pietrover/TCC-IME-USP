using Assets.Scripts.OpenAIAPI;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using Assets.Scripts;

// Classe responsável por controlar o input do jogador e a resposta ao input
public class DialogController : MonoBehaviour
{
	//Entrada do jogador
	public TMP_InputField inputField;
	//Saída do personagem
	public TMP_Text textOutput;
	//Arquivo com as informações do personagem
	public string file = "";
	// Lista com os diálogos da cena
	public List<GPTMessage> messages = new List<GPTMessage>();
	// Mensagem que seta o personagem
	public GPTMessage systemMessage = new GPTMessage();
	//Client da API do ChatGPT
	public OpenAIAPIClient client = new OpenAIAPIClient();
	public Savefile savefile = new Savefile();
	public int npcId = 0;

	private void Start()
	{
        inputField.onSubmit.AddListener(OnInputEnd);
		npcId = PlayerPrefs.GetInt("npc");
		//Atualiza os objetivos caso a condição seja cumprida
		if(npcId == 0 || npcId == 1)
		{
			savefile.UpdateObjective(npcId);
		}
		//Define o personagem, pega suas informações e insere no início do diálogo
		SelectCharacter(npcId);
		systemMessage = systemMessage.MakeMessageFromFile(file);
		messages.Add(systemMessage);
	}

	// Este código é chamado quando o jogador pressiona Enter. E 'text' contém o texto que o jogador digitou.
	void OnInputEnd(string text)
	{
		if (text != "")
		{
			//Atualiza o objetivo de endgame caso a condição seja cumprida
			if (npcId == 2 && text.ToLower().Contains("união") && text.ToLower().Contains("reconciliação") && text.ToLower().Contains("legado") && text.ToLower().Contains("conclusão"))
			{
				savefile.UpdateObjective(2);
			}
			//Pode apenas falar com a princesa caso certa condição seja cumprida
			if (npcId == 2 && savefile.LoadFile().objectives[2].status == false)
			{
				textOutput.text = "[A PRINCESA ESTÁ MUDA]";
				Debug.Log("Jogador digitou: " + text);
				messages.Add(systemMessage.MakeMessageFromInput(text));
				inputField.text = "";
			}
			else
			{
				//Adiciona a mensagem do jogador e envia para a API
				Debug.Log("Jogador digitou: " + text);
				messages.Add(systemMessage.MakeMessageFromInput(text));
				StartCoroutine("ApiCallCoroutineAsync");
				inputField.text = "";
			}
		}
	}
	//Pega o arquivo com as informações do personagem baseado no id
	private void SelectCharacter(int id)
	{
		
		switch(id)
		{
			case 0: 
				file ="Mom.txt";
				break;
			case 1:
				file = "King.txt";
				break;
			case 2:
				file = "Princess.txt";
				break;
			case 3:
				file = "Akira.txt";
				break;
			case 4:
				file = "Yuki.txt";
				break;
			case 5:
				file = "Sakura.txt";
				break;
			case 6:
				file = "Haru.txt";
				break;
			case 7:
				file = "Nagi.txt";
				break;
			case 8:
				file = "Rodrick.txt";
				break;
			case 13:
				file = "Cleo.txt";
				break;
			case 14:
				file = "Tuta.txt";
				break;
			case 15:
				file = "Ramses.txt";
				break;
			case 16:
				file = "Amon.txt";
				break;
			case 18:
				file = "Vail.txt";
				break;
			case 19:
				file = "Eldric.txt";
				break;
			case 20:
				file = "Aellis.txt";
				break;
			case 22:
				file = "Caiden.txt";
				break;


		}
	}

	//Chama a API e tenta obter uma resposta
	async Task ApiCallCoroutineAsync()
	{
		int attempts = 0;
		while (true)
		{
			try
			{
				textOutput.text = "Loading...";
				var answer = await client.SendPrompt(messages);
				textOutput.text = answer.content;
				messages.Add(answer);
				Debug.Log(answer.content);
				break;
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
				if (attempts++ > 5)
				{
					textOutput.text = "Erro! tente novamente mais tarde";
					break;
				}

			}
		}
	}
}


