using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OyunYoneticisi : MonoBehaviour
{
    public  TMP_Text SkorText;
    private int skor = 0;

    private void Start()
    {
        SkoruGuncelle();
    }

    private void Tetikleme(Collider girdi)
    {
        if (girdi.CompareTag("Gol"))
        {
            SkoruArttir();
        }
    }

    private void SkoruArttir()
    {
        skor++;
        SkoruGuncelle();
    }

    private void SkoruGuncelle()
    {
        SkorText.text = "Skor: " + skor;
    }
}
