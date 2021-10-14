using UnityEngine;

public class SabitleObjeAdi : MonoBehaviour
{
    public static SabitleObjeAdi instance = null
    
    void Awake()
    {
        //instance yani bu script önceden bir nesnede ekli mi bakacak
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            //Aşağıda Bu objeyi tüm sahnelerde sabit tut diyoruz.
            DontDestroyOnLoad(gameObject);
        }
        
        //eğer instance önceden varsa başka bir objede bu objeyi yok edeceğiz ki tek bir nesenemiz olsun
        else if (instance != this)
        {
           Destroy(gameObject);   
        }
       
     }
}
