using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    AudioSource m_audioSource;
    // Start is called before the first frame update
    private static AudioControl instance = null;

    public static AudioControl Instance
    {
        get { return instance; }
    }

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (instance != null) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    public void OnValueChanged(Slider slider)
    {
        m_audioSource.volume = slider.value / 10.0f;
    }
}
