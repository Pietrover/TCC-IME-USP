using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControllerUI : MonoBehaviour
{
	public Slider slider;
	public AudioSource audioSource;

	void Start()
	{
		float volume = PlayerPrefs.GetFloat("sound");
		slider.value = volume;
		audioSource.volume = volume;
		slider.onValueChanged.AddListener(OnSliderValueChanged);
	}

	private void OnSliderValueChanged(float value)
	{
		PlayerPrefs.SetFloat("sound", value);
		audioSource.volume = value;
		
	}

}