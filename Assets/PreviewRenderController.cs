using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PreviewRenderController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> models;
    [SerializeField] private GameObject currentActiveModel;
    public List<GameObject> Models
    {
        get => models.Select(e => e).ToList();
    }
    void Start()
    {
        
    }
    public void Activate(GameObject activateModel)
    {
        if (currentActiveModel != activateModel)
        {
            DeactivateAll();
            activateModel.SetActive(true);
            currentActiveModel = activateModel;
        }
    }

    public void DeactivateAll()
    {
        models.ForEach(e => e.SetActive(false));
    }
    
}
