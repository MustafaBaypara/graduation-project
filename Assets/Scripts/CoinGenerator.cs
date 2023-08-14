using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject prefab; // Kopyalanacak nesnenin prefabı

    // Kopyalanacak nesnenin konum aralıkları
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 5f;
    public float minZ = -10f;
    public float maxZ = 10f;

    private void Start()
    {
        // İşlemi oyun ile beraber başlat
        StartCoroutine(CoinGenerate());
    }

    // Rastgele bir konum oluşturmak için kullanılacak fonksiyon
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);
        return new Vector3(x, y, z);
    }


    // Belirli bir süre aralığında kopyalama işlemini gerçekleştirecek fonksiyon
    private IEnumerator CoinGenerate()
    {
        while (true)
        {
            // İşlemi gerçekleştir
                        // Yeni bir kopya oluşturmak için Instantiate kullanımı
            GameObject newObject = Instantiate(prefab);

            // Kopya nesneyi sahnede istediğiniz konuma yerleştirme
            newObject.transform.position = GetRandomPosition();

            // Belirli bir süre bekle
            yield return new WaitForSeconds(3f);
            Destroy(newObject);
        }
    }


}
