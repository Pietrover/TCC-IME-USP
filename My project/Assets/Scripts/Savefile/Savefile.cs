using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
	// Classe responsável por controlar os arquvios de save.
	public class Savefile
	{
		//Última cena onde o jogo foi salvo
		public string scene { get; set; }

		//Última posição do jogador no eixo x onde o jogo foi salvo
		public float positionX { get; set; }

		//Última posição do jogador no eixo y onde o jogo foi salvo
		public float positionY { get; set; }

		//Lista de objetivos do jogo
		public class Objective
		{
			//Descrição do objetivo
			public string description { get; set; }
			// Número do objetivo
			public int number { get; set; }
			//Status do objetivo, ficando true caso seja atingido
			public bool status { get; set; }
		}
		public List<Objective> objectives { get; set; }

		//Carrega o arquivo de save
		public Savefile LoadFile()
		{
			try
			{
				string filePath = Application.persistentDataPath + "/savefile.json";
				Debug.Log(filePath);
				//Cria o arquivo se ele não existe
				if (!File.Exists(filePath))
				{
					Debug.Log("Arquivo não existe");
					Savefile newsave = NewSavefile();
					string saveJson = JsonConvert.SerializeObject(newsave);
					System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", saveJson);
				}
				string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/savefile.json");
				Savefile data = JsonConvert.DeserializeObject<Savefile>(json);
				return data;
			}
			catch(Exception ex)
			{
				Debug.LogError(ex.Message);
				DeleteFile();
				return NewSavefile();
			}
		}
		//Cria o arquivo de save inicial
		public Savefile NewSavefile() {
			Savefile save = new Savefile() {
				scene = "Home",
				positionX = (float)0.812,
				positionY = (float)-2.298,
				objectives = new List<Objective>()
			};
			save.objectives.Add(new Objective { description = "FALE COM SUA MÃE", number = 0, status = false });
			save.objectives.Add(new Objective { description = "FALE COM O REI ABEL", number = 1, status = false });
			save.objectives.Add(new Objective { description = "DESCUBRA AS 4 PALAVRAS MÁGICAS E SALVE A PRINCESA AMÁLIA", number = 2, status = false });
			return save;
		}

		//Deleta o arquivo de save
		public void DeleteFile()
		{
			string filePath = Application.persistentDataPath + "/savefile.json";

			if (File.Exists(filePath))
			{	
				File.Delete(filePath);
			}
		}
		//Atualiza a localização do personagem no arquivo de save
		public void UpdateLocation(string scene , float positionX, float positionY)
		{
			Savefile data = LoadFile();
			data.positionX = positionX;
			data.positionY = positionY;
			data.scene = scene;
			
			string json = JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

		}
		//Atualiza o objetivo do number para ter status true
		public void UpdateObjective(int number)
		{
			Savefile data = LoadFile();
			data.objectives.Find(objectives => objectives.number == number).status = true;
			string json = JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
		}

	}

}
