using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MusicSet : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }
 
    
}