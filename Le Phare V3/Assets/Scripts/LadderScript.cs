using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LadderScript : MonoBehaviour
{
    public Button arrowRight;
    float duration = 2;
    //public float screenTop;
    //float rotation = 0f;
    //GameObject ladder;
    Tween ladderTween;

    public CameraScript cameraScript;

    public void PlayLadderTween()
    {

        //ladderTween?.Kill();
        //ladderTween = transform.DOLocalMoveY(screenTop, duration)
        //    .SetEase(Ease.OutCubic)
        //    .OnComplete(() =>
        //    {

        //    });


        cameraScript.ButtonRight();

        ladderTween = transform.DOLocalRotate(
            new Vector3(0f, transform.localEulerAngles.y, transform.localEulerAngles.z),
            duration,
            RotateMode.Fast
        ).SetEase(Ease.OutBounce);
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("03 - Lighthouse2");
    }
}
