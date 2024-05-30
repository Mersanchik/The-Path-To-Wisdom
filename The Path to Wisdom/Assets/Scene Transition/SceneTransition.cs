using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Text LoadingPercentage;//������� ���� ������� ������ ���������
    public Image LoadingProgressBar;//�������� ��������

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;//���� ��� ��������� ������ ����� ����� ��������� ��������

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;//��� ���������� �����

    //����� ������� ����� ��������� ��� ����� � ��������� ��� �������� ������������
    public static void SwitchToScene(int sceneName)
    {
        instance.componentAnimator.SetTrigger("sceneOpening");//��� ���� ����� ������ ��������
        instance.LoadingProgressBar.fillAmount = 1;

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);//��������� ����� �� ����

        //����� ����� �� ������ ������������� ���� ������ �������� opening
        instance.loadingSceneOperation.allowSceneActivation = false;

    }


    void Start()
    {
        instance = this;//������ ���, ����� ����� ������ ������ ����� ����������, �� ����� ���������� ���� � ��� ���������� 
        componentAnimator = GetComponent<Animator>();//������ �� ��������� ��������� ������� �� ������ ����� �������� 
        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("sceneClosing");
            instance.LoadingProgressBar.fillAmount = 1;

            // ����� ���� ��������� ������� ����� ������� SceneManager.LoadScene, �� ����������� �������� closing:
            shouldPlayOpeningAnimation = false;
        }

    }

    void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()//����� ��� ��������� ��������
    {
        // ����� ��� �������� �����, ���� �� �������������, ����������� �������� opening
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }
}
