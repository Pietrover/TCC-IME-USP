using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.OpenAIAPI
{
	// Classe com o objeto das mensagens da API do ChatGPT
	public class GPTMessage
	{
		//Identifica se é uma mensagem da API, do usuário ou do sistema 
		public string role { get; set; }

		//A mensagem
		public string content { get; set; }

		//Faz uma mensagem a partir do texto do file
		public GPTMessage MakeMessageFromFile(string file)
		{
			//Gera o path para o arquivo
			string pathToCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string pathToFile = Application.streamingAssetsPath + "/CharactersBackground/" + file;

			//Lê o arquivo e faz a mensagem
			string fileContent;
			fileContent = File.ReadAllText(pathToFile);
			GPTMessage message = new GPTMessage
			{
				content = fileContent,
				role = "system"
			};
			return message;
		}

		//Faz uma mensagem a partir do input
		public GPTMessage MakeMessageFromInput(string input)
		{
			GPTMessage message = new GPTMessage
			{
				content = input,
				role = "user"
			};
			return message;
		}
	}
	
	
}
