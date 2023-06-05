using UnityEngine;

public class PenaltiVurusu : MonoBehaviour
{
    public float SutGucu = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //private void OnMouseDown()
    //{
    //    Vector3 vurusYonu = VurusYonuHesapla();
    //    rb.AddForce(vurusYonu * SutGucu, ForceMode.Impulse);
    //}
    public float hiz = 1000f; // Topun h�z�

    void Update()
    {
        if (Input.GetMouseButton(0)) // Sol t�klama tu�una bas�l�ysa
        {
            Ray fareIsin = Camera.main.ScreenPointToRay(Input.mousePosition); // Fare ���n� olu�turulur
            RaycastHit temasBilgisi;

            if (Physics.Raycast(fareIsin, out temasBilgisi)) // Fare ���n� bir nesneyle temas ederse
            {
                if (temasBilgisi.collider.CompareTag("Top")) // Temas eden nesne "Top" etiketine sahipse
                {
                    Vector3 yon = temasBilgisi.point - transform.position; // Topun hareket y�n� belirlenir
                    //yon.z *= -1000;
                    Rigidbody topRigidbody = GetComponent<Rigidbody>();
                    topRigidbody.velocity = VurusYonuHesapla();// yon.normalized * hiz; // Topa h�z uygulan�r
                    topRigidbody.AddForce(transform.forward*hiz);
                }
            }
        }
    }

    private Vector3 VurusYonuHesapla()
    {


        Vector3 farePozisyon = Input.mousePosition;
        farePozisyon.z = 1000f;
       // farePozisyon.y = 1000f;
       
        Vector3 genelPozisyon = Camera.main.ScreenToWorldPoint(farePozisyon);
        Vector3 sutYonu = (genelPozisyon - transform.position).normalized;

        return sutYonu;
    }
}
