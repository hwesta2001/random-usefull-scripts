using UnityEngine;

public class ScriptininAdi : MonoBehaviour
{

    public TextField textGirdiAlani;
    public RigidBody objeninRigidBodysi;
    
    public static ScritininAdi instance = null
    
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
        
        // asağıda cachlediğimiz bu componentleri (objelere eklenen scriptlere component deniyor aynı zamanda) başka scriptlerden direk çağırabiliriz.
        // mesela 5inci sahnede bu objenin textfieldine ulaşmak için başka bir scripte şunu yazman yeterli olur. "ScriptininAdi.instance.textGirdiAlani;"
        // yine mesela objenin rigidbodysine başka bir scriptle ulaşmak için her seferinde GetComponent<> yapmak yerine "ScriptininAdi.instance.objeninRigidBodysi;" ile ulaşabiliriz.
        textGirdiAlani = GetComponent<TextField>();
        objeninRigidBodysi = GetComponent<RigidBody>();
       
     }
}
