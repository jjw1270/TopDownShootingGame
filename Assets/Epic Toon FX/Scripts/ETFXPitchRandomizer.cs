using UnityEngine;
using System.Collections;

namespace EpicToonFX
{

	public class ETFXPitchRandomizer : MonoBehaviour
	{
		public AudioSource audioSource;
		public float randomPercent = 10;
	
		void Start ()
		{
        audioSource.pitch *= 1 + Random.Range(-randomPercent / 100, randomPercent / 100);
		}
	}
}