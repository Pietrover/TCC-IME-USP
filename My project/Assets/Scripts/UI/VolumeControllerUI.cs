using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

//Classe Responsável por controlar o volume da música de fundo
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

	//É acionado quando o slider for usado
	private void OnSliderValueChanged(float value)
	{
		PlayerPrefs.SetFloat("sound", value);
		audioSource.volume = value;
		
	}

}