using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControllerComponent : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Audio Source Does Тot Connect Automatically")]
    [SerializeField] public AudioSource audio;//отвечает за музыкальный ресурс
    [Tooltip("Slider Search Using A Tag")]
    [SerializeField] public Slider slider;//слидер, с помощью которого регулируется громкость
    [Tooltip("Text Search Using A Tag")]
    [SerializeField] public Text text;//отображение процентов громкости

    [Header("Keys")]
    [Tooltip("Save Data PlayerPrefs Key")]
    [SerializeField] public string saveVolumeKey;//для сохранения параметров громкости

    [Header("Tags")]
    [Tooltip("Volume Control Slider Tag")]
    [SerializeField] public string sliderTag;//Тег ползунка регулировки громкости
    [Tooltip("Volume Control Text Tag")]
    [SerializeField] public string textVolumeTag;//Текстовый тег для регулировки громкости

    [Header("Parameters")]
    [Tooltip("Sound Volume Value")]
    [SerializeField][Range(0.0f, 1.0f)] public float volume;//Значение громкости звука

    public void Awake()
    {
        //Проверяет, доступно ли сохранение в реестре.
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            //Поиск и подключение ползунка.
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        else
        {
            //Установка громкости по умолчанию.
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }

    public void LateUpdate()
    {
        //Поиск и подключение ползунка.
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if (sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            //Проверяет том, сохранен ли он в реестре, есть ли отличие.
            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }

            //Выполняет поиск и соединяет текст для увеличения объема вывода.
            GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
            if (textObj != null)
            {
                this.text = textObj.GetComponent<Text>();

                this.text.text = Mathf.Round(this.volume * 100) + "%"; //Преобразование значения объема в процентах (от 0% до 100%)
            }
        }

        this.audio.volume = this.volume;

        
    }

    private void FixedUpdate()//При кокончании проигрывать заново
    {
        if(!audio.isPlaying)
        {
            audio.Play();
        }
    }
}

