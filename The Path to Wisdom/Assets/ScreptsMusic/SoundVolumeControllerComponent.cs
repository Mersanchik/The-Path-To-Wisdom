using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControllerComponent : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Audio Source Does �ot Connect Automatically")]
    [SerializeField] public AudioSource audio;//�������� �� ����������� ������
    [Tooltip("Slider Search Using A Tag")]
    [SerializeField] public Slider slider;//������, � ������� �������� ������������ ���������
    [Tooltip("Text Search Using A Tag")]
    [SerializeField] public Text text;//����������� ��������� ���������

    [Header("Keys")]
    [Tooltip("Save Data PlayerPrefs Key")]
    [SerializeField] public string saveVolumeKey;//��� ���������� ���������� ���������

    [Header("Tags")]
    [Tooltip("Volume Control Slider Tag")]
    [SerializeField] public string sliderTag;//��� �������� ����������� ���������
    [Tooltip("Volume Control Text Tag")]
    [SerializeField] public string textVolumeTag;//��������� ��� ��� ����������� ���������

    [Header("Parameters")]
    [Tooltip("Sound Volume Value")]
    [SerializeField][Range(0.0f, 1.0f)] public float volume;//�������� ��������� �����

    public void Awake()
    {
        //���������, �������� �� ���������� � �������.
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            //����� � ����������� ��������.
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        else
        {
            //��������� ��������� �� ���������.
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }

    public void LateUpdate()
    {
        //����� � ����������� ��������.
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if (sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            //��������� ���, �������� �� �� � �������, ���� �� �������.
            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }

            //��������� ����� � ��������� ����� ��� ���������� ������ ������.
            GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
            if (textObj != null)
            {
                this.text = textObj.GetComponent<Text>();

                this.text.text = Mathf.Round(this.volume * 100) + "%"; //�������������� �������� ������ � ��������� (�� 0% �� 100%)
            }
        }

        this.audio.volume = this.volume;

        
    }

    private void FixedUpdate()//��� ���������� ����������� ������
    {
        if(!audio.isPlaying)
        {
            audio.Play();
        }
    }
}

