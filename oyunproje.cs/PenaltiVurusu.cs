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
    public float hiz = 1000f; // Topun hýzý

    void Update()
    {
        if (Input.GetMouseButton(0)) // Sol týklama tuþuna basýlýysa
        {
            Ray fareIsin = Camera.main.ScreenPointToRay(Input.mousePosition); // Fare ýþýný oluþturulur
            RaycastHit temasBilgisi;

            if (Physics.Raycast(fareIsin, out temasBilgisi)) // Fare ýþýný bir nesneyle temas ederse
            {
                if (temasBilgisi.collider.CompareTag("Top")) // Temas eden nesne "Top" etiketine sahipse
                {
                    Vector3 yon = temasBilgisi.point - transform.position; // Topun hareket yönü belirlenir
                    //yon.z *= -1000;
                    Rigidbody topRigidbody = GetComponent<Rigidbody>();
                    topRigidbody.velocity = VurusYonuHesapla();// yon.normalized * hiz; // Topa hýz uygulanýr
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
