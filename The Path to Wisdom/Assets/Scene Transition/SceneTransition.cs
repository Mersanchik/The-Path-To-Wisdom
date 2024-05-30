using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Text LoadingPercentage;//процент того сколько сейчас загружено
    public Image LoadingProgressBar;//картинка загрузки

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;//если при следующем старте сцены нужно проиграть анимацию

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;//дл€ управлени€ сцены

    //метод который будет принимать им€ сцены и запускать всю анимацию переключени€
    public static void SwitchToScene(int sceneName)
    {
        instance.componentAnimator.SetTrigger("sceneOpening");//дл€ того чтобы начать анимацию
        instance.LoadingProgressBar.fillAmount = 1;

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);//загружает сцену на фоне

        //чтобы сцена не начала переключатьс€ пока играет анимаци€ opening
        instance.loadingSceneOperation.allowSceneActivation = false;

    }


    void Start()
    {
        instance = this;//каждый раз, когда какой нибудь объект будет стратовать, он будет записывать себ€ в эту переменную 
        componentAnimator = GetComponent<Animator>();//ссылка на компонент аниматора который на старте будем получать 
        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("sceneClosing");
            instance.LoadingProgressBar.fillAmount = 1;

            // „тобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию closing:
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

    public void OnAnimationOver()//метод дл€ окончании анимации
    {
        // „тобы при открытии сцены, куда мы переключаемс€, проигралась анимаци€ opening
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }
}
