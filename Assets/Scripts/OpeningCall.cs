using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCall : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        if (_audioSource.isPlaying == false)
        {
            SceneManager.LoadScene("SleepMeter");
        }
    }
}