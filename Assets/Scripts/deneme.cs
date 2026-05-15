using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ChainDistanceConstraint : MonoBehaviour
{
    [Header("Chain setup")]
    public List<Rigidbody2D> links;      // zincir halkalarý, sýrayla (0 = kök / üst)
    public float maxDistance = 1f;       // max izin verilen mesafe (senin istediðin: 1)
    [Range(1, 10)]
    public int solverIterations = 4;     // daha yüksek = daha stabil ama maliyetli

    void FixedUpdate()
    {
        if (links == null || links.Count < 2) return;

        // Ýteratif düzeltiler — her iterasyonda komþularý eþit düzelt
        for (int it = 0; it < solverIterations; it++)
        {
            for (int i = 1; i < links.Count; i++)
            {
                Rigidbody2D a = links[i - 1];
                Rigidbody2D b = links[i];

                Vector2 posA = a.position;
                Vector2 posB = b.position;

                Vector2 delta = posB - posA;
                float dist = delta.magnitude;

                if (dist == 0f) continue;

                if (dist > maxDistance)
                {
                    float error = dist - maxDistance;
                    Vector2 correctionDir = delta / dist;

                    // Eþit paylaþým: her iki cismi yarý yarýya düzelt
                    // Dinamik kütle etkisi istersen burada a.mass/b.mass kullanabilirsin
                    Vector2 corr = correctionDir * (error * 0.5f);

                    // MovePosition kullanarak fizik motoruyla uyumlu taþýma
                    // Önce hedef pozisyonlarý hesapla
                    Vector2 newA = posA + corr;
                    Vector2 newB = posB - corr;

                    // Uygula
                    a.MovePosition(newA);
                    b.MovePosition(newB);
                }
            }
        }
    }
}
