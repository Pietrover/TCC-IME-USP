using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

//Classe Respons�vel por controlar o volume da m�sica de fundo
public class VolumeControllerUI : MonoBehaviour
{
	public Slider slider;
	public AudioSource audioSource;

	void Start()
	{
		float volume = PlayerPrefs.GetFloat("sound");
		slider.value = volume;
		slider.interactable = true;
		audioSource.volume = volume;
		slider.onValueChanged.AddListener(OnSliderValueChanged);
	}

	//� acionado quando o slider for usado
	private void OnSliderValueChanged(float value)
	{
		PlayerPrefs.SetFloat("sound", value);
		audioSource.volume = value;
		
	}

}