using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject three, two, one, maincam, gamecam, countdownsound;
    public AudioSource Tracksound;
    public int st = 0;

    public virtual IEnumerator Start()
    {

        gamecam.SetActive(false);
        maincam.SetActive(true);
        yield return new WaitForSeconds(3);

        Tracksound.GetComponent<AudioSource>().enabled = false;
        countdownsound.SetActive(true);
        three.SetActive(true);
        yield return new WaitForSeconds(1);
        three.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(1);
        two.SetActive(false);
        one.SetActive(true);
        yield return new WaitForSeconds(1);
        one.SetActive(false);
        //go.SetActive(true);
        //yield return new WaitForSeconds(1);
        //go.SetActive(false);
        st = st + 1;
        countdownsound.SetActive(false);
        yield return new WaitForSeconds(0);

        maincam.SetActive(false);
        gamecam.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
