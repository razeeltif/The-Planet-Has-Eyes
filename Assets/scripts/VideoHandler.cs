using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
	VideoPlayer player;

	bool isSkiping;

    void Awake()
    {
		StartCoroutine(PlayIntro());
    }

	private void Update()
	{
		if(!isSkiping && (Input.GetKeyDown(KeyCode.Space)))
		{
			StartCoroutine(FadeOut());
		}
		else if (isSkiping)
		{
			player.SetDirectAudioVolume(0, player.GetDirectAudioVolume(0) - 0.02f);
		}
	}

	IEnumerator PlayIntro()
	{
		player.Play();
		yield return new WaitForSeconds(0.5f);
		yield return new WaitUntil(() => player.isPlaying == false);
		SceneManager.LoadScene(2);
	}

	IEnumerator FadeOut()
	{
		isSkiping = true;
		GetComponent<Animation>().Play();
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(() => GetComponent<Animation>().isPlaying == false);
		SceneManager.LoadScene(1);
	}
}
