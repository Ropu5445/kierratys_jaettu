using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("Car"))
        {
            audioSource.Play();
        }
    }
}